using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UndoMethods
{
    /// <summary>
    /// This is a singleton class which stores undo/redo records and executes the undo/redo operations specified in these records
    /// 실행 취소 / 다시 실행 레코드를 저장하고이 레코드에 지정된 실행 취소 / 다시 실행 작업을 실행하는 싱글 톤 클래스입니다.
    /// </summary>
    public class UndoRedoManager
    {
        public delegate void OnStackStatusChanged(bool hasItems);

        /// <summary>
        /// Stores undo records
        /// 실행 취소 레코드를 저장합니다
        /// </summary>
        private List<IUndoRedoRecord> _undoStack = new List<IUndoRedoRecord>();

        /// <summary>
        /// Stores redo records 
        /// 리두 레코드 저장
        /// </summary>
        private List<IUndoRedoRecord> _redoStack = new List<IUndoRedoRecord>();

        /// <summary>
        /// This is used to determine if an undo operation is going on
        /// 실행 취소 작업이 진행 중인지 확인하는 데 사용됩니다.
        /// </summary>
        private bool _undoGoingOn = false;

        /// <summary>
        /// This is used to determine if a redo operation is going on
        /// 재실행 작업이 진행 중인지 확인하는 데 사용됩니다.
        /// </summary>
        private bool _redoGoingOn = false;

        /// <summary>
        /// Is fired when the undo stack status is changed
        /// 실행 취소 스택 상태가 변경되면 시작됩니다.
        /// </summary>
        public event OnStackStatusChanged UndoStackStatusChanged;

        /// <summary>
        /// Is fired when the redo stack status is changed
        /// 리두 스택 상태가 변경되면 시작됩니다
        /// </summary>
        public event OnStackStatusChanged RedoStackStatusChanged;

        /// <summary>
        /// Stores instance of this singleton object
        /// </summary>
        private static volatile UndoRedoManager _thisObject = new UndoRedoManager();

        /// <summary>
        /// Maximum items to store in undo redo stack
        /// 실행 취소 재실행 스택에 저장할 최대 항목
        /// </summary>
        protected int _maxItems = 10;

        /// <summary>
        /// stores the transaction (if any) under which the current undo/redo operation(s) are occuring.
        /// 현재 실행 취소 / 다시 실행 작업이 발생하는 트랜잭션 (있는 경우)을 저장합니다.
        /// </summary>
        private UndoTransaction _curTran;

        /// <summary>
        /// Returns instance of this singleton object
        /// </summary>
        /// <returns></returns>
        public static UndoRedoManager Instance()
        {
            return _thisObject;
        }
        /// <summary>
        /// Sets/gets maximum items to be stored in the stack. Note that the change takes effect the next time an item is added to the undo/redo stack
        /// 스택에 저장할 최대 항목을 설정 / 가져옵니다.다음에 항목을 실행 취소 / 다시 실행 스택에 추가 할 때 변경 사항이 적용됩니다
        /// </summary>
        public int MaxItems
        {
            get { return _maxItems; }
            set
            {
                if (_maxItems <= 0)
                {
                    throw new ArgumentOutOfRangeException("Max items can't be <= 0");
                }

                _maxItems = value;
            }
        }

        /// <summary>
        /// Starts a transaction under which all undo redo operations take place
        /// 모든 실행 취소 재실행 작업이 발생하는 트랜잭션을 시작합니다
        /// </summary>
        /// <param name="tran"></param>
        public void StartTransaction(UndoTransaction tran)
        {
            if (_curTran == null)
            {
                _curTran = tran;
                ///push an empty undo operation
                _undoStack.Push(new UndoTransaction(tran.Name));
                _redoStack.Push(new UndoTransaction(tran.Name));
            }
        }

        /// <summary>
        /// Ends the transaction under which all undo/redo operations take place
        /// </summary>
        /// <param name="tran"></param>
        public void EndTransaction(UndoTransaction tran)
        {
            if (_curTran == tran)
            {
                _curTran = null;
                ///now we might have had no items added to undo and redo stack as a part of this transaction. Check empty transaction at top and remove them
                if (_undoStack.Count > 0)
                {
                    UndoTransaction t = _undoStack[0] as UndoTransaction;
                    if (t != null && t.OperationsCount == 0)
                    {
                        _undoStack.Pop();
                    }
                }

                if (_redoStack.Count > 0)
                {
                    UndoTransaction t = _redoStack[0] as UndoTransaction;
                    if (t != null && t.OperationsCount == 0)
                    {
                        _redoStack.Pop();
                    }
                }
            }
        }

        /// <summary>
        /// Pushes an item onto the undo/redo stack. 
        /// 1) If this is called outside the context of a undo/redo operation, the item is added to the undo stack.
        /// 이를 실행 취소 / 다시 실행 조작의 컨텍스트 외부에서 호출하면 항목이 실행 취소 스택에 추가됩니다.

        /// 2) If this is called in the context of an undo operation, the item is added to redo stack.
        /// 실행 취소 작업의 컨텍스트에서이 항목을 호출하면 항목이 다시 실행 스택에 추가됩니다.
        /// 
        /// 3) If this is called in context of an redo operation, item is added to undo stack.
        /// 이 작업을 다시 실행 작업의 컨텍스트에서 호출하면 항목이 실행 취소 스택에 추가됩니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="undoOperation"></param>
        /// <param name="undoData"></param>
        /// <param name="description"></param>
        public void Push<T>(UndoRedoOperation<T> undoOperation, T undoData, string description = "")
        {
            Debug.Assert(null != undoOperation);

            List<IUndoRedoRecord> stack = null;
            Action eventToFire;

            ///Determien the stack to which this operation will be added
            if (_undoGoingOn)
            {
                Trace.TraceInformation("Adding to redo stack {0} with data {1}", undoOperation.Method.Name, undoData);
                stack = _redoStack;
                eventToFire = new Action(FireRedoStackStatusChanged);
            }
            else
            {
                Trace.TraceInformation("Adding to undo stack {0} with data {1}", undoOperation.Method.Name, undoData);
                stack = _undoStack;
                eventToFire = new Action(FireUndoStackStatusChanged);
            }

            if( (!_undoGoingOn) && (!_redoGoingOn))
            {//if someone added an item to undo stack while there are items in redo stack.. clear the redo stack
                _redoStack.Clear();
                FireRedoStackStatusChanged();
            }
            ///If a transaction is going on, add the operation as a entry to the transaction operation
            if (_curTran == null)
            {
                stack.Push(new UndoRedoRecord<T>(undoOperation, undoData, description));
            }
            else
            {
                (stack[0] as UndoTransaction).AddUndoRedoOperation(new UndoRedoRecord<T>(undoOperation, undoData,
                                                                                       description));
            }

            //If the stack count exceeds maximum allowed items
            if (stack.Count > MaxItems)
            {
                object o = stack[stack.Count - 1];
                Trace.TraceInformation("Removing item {0}", o);
                stack.RemoveRange(MaxItems-1, stack.Count-MaxItems);
            }
            //Fire event to inform consumers that the stack size has changed
            eventToFire();
        }

        private void FireUndoStackStatusChanged()
        {
            if (null != UndoStackStatusChanged)
                UndoStackStatusChanged(HasUndoOperations);
        }

        private void FireRedoStackStatusChanged()
        {
            if (null != RedoStackStatusChanged)
                RedoStackStatusChanged(HasRedoOperations);
        }

        public int UndoOperationCount
        {
            get { return _undoStack.Count; }
        }

        public int RedoOperationCount
        {
            get { return _redoStack.Count; }
        }

        public bool HasUndoOperations
        {
            get { return _undoStack.Count != 0; }
        }

        public bool HasRedoOperations
        {
            get { return _redoStack.Count != 0; }
        }

        /// <summary>
        /// Performs an undo operation
        /// </summary>
        public void Undo()
        {
            try
            {
              
                _undoGoingOn = true;

                if (_undoStack.Count == 0)
                {
                    throw new InvalidOperationException("Nothing in the undo stack");
                }
                object oUndoData = _undoStack.Pop();

                Type undoDataType = oUndoData.GetType();

                ///If the stored operation was a transaction, perform the undo as a transaction too.
                if (typeof (UndoTransaction).Equals(undoDataType))
                {
                    StartTransaction(oUndoData as UndoTransaction);
                }

                undoDataType.InvokeMember("Execute", BindingFlags.InvokeMethod, null, oUndoData, null);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
            finally
            {
                _undoGoingOn = false;

                EndTransaction(_curTran);

                FireUndoStackStatusChanged();
            }
        }

        /// <summary>
        /// Performs a redo operation
        /// </summary>
        public void Redo()
        {
            try
            {
                _redoGoingOn = true;
                if (_redoStack.Count == 0)
                {
                    throw new InvalidOperationException("Nothing in the redo stack");
                }
                object oUndoData = _redoStack.Pop();

                Type undoDataType = oUndoData.GetType();

                ///If the stored operation was a transaction, perform the redo as a transaction too.
                ///저장된 작업이 트랜잭션 인 경우 다시 실행도 트랜잭션으로 수행하십시오.
                if (typeof (UndoTransaction).Equals(undoDataType))
                {
                    StartTransaction(oUndoData as UndoTransaction);
                }

                undoDataType.InvokeMember("Execute", BindingFlags.InvokeMethod, null, oUndoData, null);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
            finally
            {
                _redoGoingOn = false;
                EndTransaction(_curTran);

                FireRedoStackStatusChanged();
            }
        }

        /// <summary>
        /// Clears all undo/redo operations from the stack
        /// </summary>
        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
            FireUndoStackStatusChanged();
            FireRedoStackStatusChanged();
        }

        /// <summary>
        /// Returns a list containing description of all undo stack records
        /// </summary>
        /// <returns></returns>
        public IList<string> GetUndoStackInformation()
        {
            return _undoStack.ConvertAll( (input)=>input.Name==null ? "" : input.Name);
        }

        /// <summary>
        /// Returns a list containing description of all redo stack records
        /// </summary>
        /// <returns></returns>
        public IList<string> GetRedoStackInformation()
        {
            return _redoStack.ConvertAll((input) => input.Name == null ? "" : input.Name);
        }
    }
}