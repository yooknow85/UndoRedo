using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UndoMethods
{
    public partial class MainForm : Form
    {
        private List<Person> _personList = new List<Person>();

        public MainForm()
        {
            InitializeComponent();
            UndoRedoManager.Instance().RedoStackStatusChanged += new UndoRedoManager.OnStackStatusChanged(MainForm_RedoStackStatusChanged);
            UndoRedoManager.Instance().UndoStackStatusChanged += new UndoRedoManager.OnStackStatusChanged(MainForm_UndoStackStatusChanged);          
        }

        void MainForm_UndoStackStatusChanged(bool hasItems)
        {
           undoToolStripMenuItem.Enabled = hasItems;
        }

        void MainForm_RedoStackStatusChanged(bool hasItems)
        {
            redoToolStripMenuItem.Enabled = hasItems;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
           
            personListBindingSource.DataSource = _personList;
            lbPeople.DataSource = personListBindingSource;
            lbPeople.DisplayMember = "Name";

            //기본 대상자 2명 입력.
            AddDefaultPeople();

            ///clear any undo operations added implicitly during startup
            UndoRedoManager.Instance().Clear();
        }

        private void AddDefaultPeople()
        {
            Person p = new Person()
                           {
                               Name = "Tom Jones",
                               Age = 33
                           };
            AddPerson(p);

            p = new Person()
            {
                Name = "John Doe",
                Age = 29
            };
            AddPerson(p);
        }

        private Person AddPerson(Person person)
        {
            //Do not add if the person is already in the list
            Person personInList = _personList.Find(p => p.ID == person.ID);
            if (personInList != null)
            {
                return personInList;
            }

            //UndoRedoManager.Instance().Push(p => RemovePerson(p), person,"Add Person");
            UndoRedoManager.Instance().Push(delegate(Person p) { RemovePerson(p); }, person, "Add Person");

            personListBindingSource.Position =  personListBindingSource.Add(person);

            return person;

        }

        private void RemovePerson(Person person)
        {
            //Nothing to do if the person is not in the list
            bool found = _personList.Exists(p => p.ID == person.ID);
            if (!found)
            {
                return;
            }

            UndoRedoManager.Instance().Push(p => AddPerson(p), person,"Remove Person");

            personListBindingSource.Remove(person);   
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Person p = new Person() {};
            AddPerson(p);
            p.Name = "<Change Name>";
            p.Age = 0;

        }

        private void personListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            personBindingSource.DataSource = personListBindingSource.Current;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //current 형이 Object형식이니깐 person 으로 as
            RemovePerson(personListBindingSource.Current as Person);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UndoRedoManager.Instance().Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UndoRedoManager.Instance().Redo();
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            (personListBindingSource.Current as Person).ReverseName();
        }

        private void btnRandomizeNameAndAge_Click(object sender, EventArgs e)
        {
            Person p = (personListBindingSource.Current as Person);
            RandomizeNameAndAge(p);
        }

        private void RandomizeNameAndAge(Person p)
        {
            using (new UndoTransaction("Randomize name and age"))
            {
                
                p.Name = Guid.NewGuid().ToString();
                p.Age = (new Random((int) DateTime.Now.Ticks)).Next(110);
            }
        }

        private void btnAddAndRandomize_Click(object sender, EventArgs e)
        {
            using (new UndoTransaction("Add person and randomize data"))
            {
                Person p = new Person();
                AddPerson(p);
                RandomizeNameAndAge(p);
            }
        }

        private void btnAddTran_Click(object sender, EventArgs e)
        {
            using (new UndoTransaction("Add Person-Transaction"))
            {
                Person p = new Person() {};
                AddPerson(p);
                p.Name = "<Change Name>";
                p.Age = 0;
            }
        }
    }
}
