namespace UndoPatternSample
{
    partial class UndoRedoStackViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbRedoStack = new System.Windows.Forms.ListBox();
            this.lbUndoStack = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbRedoStack
            // 
            this.lbRedoStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRedoStack.FormattingEnabled = true;
            this.lbRedoStack.Location = new System.Drawing.Point(216, 27);
            this.lbRedoStack.Name = "lbRedoStack";
            this.lbRedoStack.Size = new System.Drawing.Size(204, 264);
            this.lbRedoStack.TabIndex = 9;
            // 
            // lbUndoStack
            // 
            this.lbUndoStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUndoStack.FormattingEnabled = true;
            this.lbUndoStack.Location = new System.Drawing.Point(3, 27);
            this.lbUndoStack.Name = "lbUndoStack";
            this.lbUndoStack.Size = new System.Drawing.Size(182, 264);
            this.lbUndoStack.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Undo stack";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Redo stack";
            // 
            // UndoRedoStackViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRedoStack);
            this.Controls.Add(this.lbUndoStack);
            this.Name = "UndoRedoStackViewer";
            this.Size = new System.Drawing.Size(423, 318);
            this.Load += new System.EventHandler(this.UndoRedoStackViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRedoStack;
        private System.Windows.Forms.ListBox lbUndoStack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
