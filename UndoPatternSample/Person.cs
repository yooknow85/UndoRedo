using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace UndoMethods
{
    public class Person : INotifyPropertyChanged
    {
        public  Person()
        {
            _id = Guid.NewGuid().ToString();
        }

        private string _id;

        public string ID
        {
            get { return _id; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }

            set
            {
                //push the undo operation into stack. 
                UndoRedoManager.Instance().Push(a=> Age = a, _age, "Change age"); 
                
                _age = value; 
                NotifyPropertyChanged("Age");
            }
        }   

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                Trace.TraceInformation("Changing name from {0} to {1}", _name, value);
                UndoRedoManager.Instance().Push((x) => this.Name = x, _name, "Change name");

                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public void ReverseName()
        {
            using (UndoTransaction tran = new UndoTransaction("Reverse name"))
            {
                Name = new string(_name.Reverse().ToArray());
            }
        }

        
            


        #region Implementation of INotifyPropertyChanged
            
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
}
