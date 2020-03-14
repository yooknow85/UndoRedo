namespace UndoMethods
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbPeople = new System.Windows.Forms.ListBox();
            this.personListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRandomizeNameAndAge = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddAndRandomize = new System.Windows.Forms.Button();
            this.undoRedoStackViewer1 = new UndoPatternSample.UndoRedoStackViewer();
            this.btnAddTran = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.personListBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPeople
            // 
            this.lbPeople.DataSource = this.personListBindingSource;
            this.lbPeople.FormattingEnabled = true;
            this.lbPeople.ItemHeight = 15;
            this.lbPeople.Location = new System.Drawing.Point(41, 42);
            this.lbPeople.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbPeople.Name = "lbPeople";
            this.lbPeople.Size = new System.Drawing.Size(329, 349);
            this.lbPeople.TabIndex = 0;
            // 
            // personListBindingSource
            // 
            this.personListBindingSource.CurrentChanged += new System.EventHandler(this.personListBindingSource_CurrentChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRandomizeNameAndAge);
            this.groupBox1.Controls.Add(this.btnReverse);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(380, 40);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(429, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // btnRandomizeNameAndAge
            // 
            this.btnRandomizeNameAndAge.Location = new System.Drawing.Point(71, 202);
            this.btnRandomizeNameAndAge.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRandomizeNameAndAge.Name = "btnRandomizeNameAndAge";
            this.btnRandomizeNameAndAge.Size = new System.Drawing.Size(223, 27);
            this.btnRandomizeNameAndAge.TabIndex = 5;
            this.btnRandomizeNameAndAge.Text = "Randomize Name and Age";
            this.btnRandomizeNameAndAge.UseVisualStyleBackColor = true;
            this.btnRandomizeNameAndAge.Click += new System.EventHandler(this.btnRandomizeNameAndAge_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(71, 158);
            this.btnReverse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(223, 27);
            this.btnReverse.TabIndex = 4;
            this.btnReverse.Text = "Reverse Name";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // txtAge
            // 
            this.txtAge.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "Age", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.txtAge.Location = new System.Drawing.Point(160, 99);
            this.txtAge.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(132, 25);
            this.txtAge.TabIndex = 3;
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(UndoMethods.Person);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Age";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(160, 39);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(249, 25);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(55, 399);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(123, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add(No tran)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(272, 400);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 27);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1415, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // btnAddAndRandomize
            // 
            this.btnAddAndRandomize.Location = new System.Drawing.Point(272, 434);
            this.btnAddAndRandomize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddAndRandomize.Name = "btnAddAndRandomize";
            this.btnAddAndRandomize.Size = new System.Drawing.Size(260, 27);
            this.btnAddAndRandomize.TabIndex = 5;
            this.btnAddAndRandomize.Text = "Add person and randomize data";
            this.btnAddAndRandomize.UseVisualStyleBackColor = true;
            this.btnAddAndRandomize.Click += new System.EventHandler(this.btnAddAndRandomize_Click);
            // 
            // undoRedoStackViewer1
            // 
            this.undoRedoStackViewer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.undoRedoStackViewer1.Location = new System.Drawing.Point(818, 42);
            this.undoRedoStackViewer1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.undoRedoStackViewer1.Name = "undoRedoStackViewer1";
            this.undoRedoStackViewer1.Size = new System.Drawing.Size(536, 367);
            this.undoRedoStackViewer1.TabIndex = 6;
            // 
            // btnAddTran
            // 
            this.btnAddTran.Location = new System.Drawing.Point(55, 434);
            this.btnAddTran.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddTran.Name = "btnAddTran";
            this.btnAddTran.Size = new System.Drawing.Size(123, 27);
            this.btnAddTran.TabIndex = 7;
            this.btnAddTran.Text = "Add(tran)";
            this.btnAddTran.UseVisualStyleBackColor = true;
            this.btnAddTran.Click += new System.EventHandler(this.btnAddTran_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 480);
            this.Controls.Add(this.btnAddTran);
            this.Controls.Add(this.undoRedoStackViewer1);
            this.Controls.Add(this.btnAddAndRandomize);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbPeople);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Undo/Redo sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.personListBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPeople;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.BindingSource personListBindingSource;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnRandomizeNameAndAge;
        private System.Windows.Forms.Button btnAddAndRandomize;
        private UndoPatternSample.UndoRedoStackViewer undoRedoStackViewer1;
        private System.Windows.Forms.Button btnAddTran;
    }
}

