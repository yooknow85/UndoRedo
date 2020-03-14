using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UndoMethods;

namespace UndoPattern.tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PersonTest
    {
        public PersonTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void NameUndoTest()
        {
            Assert.IsFalse(UndoRedoManager.Instance().HasUndoOperations);
            Person person = new Person();
            person.Name = "oldname";
            Assert.IsTrue(UndoRedoManager.Instance().HasUndoOperations);
            person.Name = "newname";
            Assert.AreEqual("newname", person.Name);
            UndoRedoManager.Instance().Undo();
            Assert.IsTrue(UndoRedoManager.Instance().HasRedoOperations);
            Assert.AreEqual("oldname", person.Name);
            UndoRedoManager.Instance().Undo();
            Assert.IsNull( person.Name);
            Assert.IsFalse(UndoRedoManager.Instance().HasUndoOperations);

            UndoRedoManager.Instance().Redo();
            Assert.IsTrue(UndoRedoManager.Instance().HasUndoOperations);
            Assert.AreEqual("oldname", person.Name);
            UndoRedoManager.Instance().Redo();
            Assert.AreEqual("newname", person.Name);
            Assert.IsTrue(UndoRedoManager.Instance().HasUndoOperations);

            UndoRedoManager.Instance().Undo();
            Assert.IsTrue(UndoRedoManager.Instance().HasRedoOperations);
            Assert.AreEqual("oldname", person.Name);
            UndoRedoManager.Instance().Undo();
            Assert.IsNull(person.Name);
            Assert.IsFalse(UndoRedoManager.Instance().HasUndoOperations);

        }

        [TestMethod]
        public void ReverseNameTest()
        {
            Person person = new Person();
            string originalName = "abcd";
            person.Name = originalName;
            person.ReverseName();
            Assert.AreNotEqual(originalName,person.Name);
            UndoRedoManager.Instance().Undo();
            Assert.AreEqual(originalName, person.Name);
            UndoRedoManager.Instance().Redo();
            Assert.AreEqual(new string(originalName.Reverse().ToArray()), person.Name);
            person.ReverseName();
        }
    }
}
