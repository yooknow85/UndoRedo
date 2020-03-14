using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UndoMethods
{
    /// <summary>
    /// This acts as a container for multiple undo/redo records.
    /// 여러 실행 취소 / 다시 실행 레코드의 컨테이너 역할을합니다.
    /// </summary>
    public class UndoTransaction : IDisposable, IUndoRedoRecord
    {
        private string _name;
        private List<IUndoRedoRecord> _undoRedoOperations = new List<IUndoRedoRecord>();
        public UndoTransaction(string name="")
        {
            _name = name;
            UndoRedoManager.Instance().StartTransaction(this);
        }


        public string Name
        {
            get { return _name; }
        }

        public void Dispose()
        {
            UndoRedoManager.Instance().EndTransaction(this);
        }

         public void AddUndoRedoOperation(IUndoRedoRecord operation)
         {
             _undoRedoOperations.Insert(0, operation);
         }

        public int OperationsCount
        {
            get { return _undoRedoOperations.Count; }
        }

        #region Implementation of IUndoRedoRecord

        public void Execute()
        {
            _undoRedoOperations.ForEach((a)=>a.Execute());
        }



        #endregion
    }
}
