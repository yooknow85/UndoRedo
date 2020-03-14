using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UndoMethods;

namespace UndoPatternSample
{
    public partial class UndoRedoStackViewer : UserControl
    {
        public UndoRedoStackViewer()
        {
            InitializeComponent();
        }

        private void UndoRedoStackViewer_Load(object sender, EventArgs e)
        {
            UndoRedoManager.Instance().RedoStackStatusChanged += new UndoRedoManager.OnStackStatusChanged(UndoRedoStackViewer_RedoStackStatusChanged);
            UndoRedoManager.Instance().UndoStackStatusChanged += new UndoRedoManager.OnStackStatusChanged(UndoRedoStackViewer_UndoStackStatusChanged);
        }

        void UndoRedoStackViewer_UndoStackStatusChanged(bool hasItems)
        {
           
            lbUndoStack.DataSource = UndoRedoManager.Instance().GetUndoStackInformation(); 
            
        }

        void UndoRedoStackViewer_RedoStackStatusChanged(bool hasItems)
        {
            lbRedoStack.DataSource   = UndoRedoManager.Instance().GetRedoStackInformation();
        }
    }
}
