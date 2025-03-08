namespace TestProgram;
using Lab9_1;
using Lab10;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestMusicalInstrument
{
    private Student baseStudent;
    
    private MusicalInstrument baseMusicalInstrument;
    private MusicalInstrument baseMusicalInstrument1;
    private MusicalInstrument? nullMusicalInstrument;
    private MusicalInstrument createdMusicalInsrument;
    
    [TestInitialize]
    public void InitializeMusicalInstrument()
    {
        baseStudent = new Student();
        
        baseMusicalInstrument = new MusicalInstrument();
        baseMusicalInstrument1 = new MusicalInstrument();
        nullMusicalInstrument = null;
        createdMusicalInsrument = new MusicalInstrument("Контробас", 474);
    }

    [TestMethod]
    public void TestNumberMusicalInstrument()
    {
        Assert.AreEqual(66, MusicalInstrument.NumberMusicalInstruments);
    }
    
    [TestMethod]
    public void TestBasicInstrument()
    {
        Assert.AreEqual("", baseMusicalInstrument.Name);
        IdNumber baseId = new IdNumber();
        Assert.IsTrue(baseId.Equals(baseMusicalInstrument.Id));
    }

    [TestMethod]
    public void TestCreatedMusicalInstrument()
    {
        Assert.AreEqual("Контробас", createdMusicalInsrument.Name);
        Assert.AreEqual(474, createdMusicalInsrument.Id.Id);
    }

    [TestMethod]
    public void TestEqualsMusicalInstrument1()
    {
        Assert.IsTrue(baseMusicalInstrument.Equals(baseMusicalInstrument1));
    }

    [TestMethod]
    public void TestEqualsMusicalInstrument2()
    {
        Assert.IsFalse(baseMusicalInstrument.Equals(createdMusicalInsrument));
    }

    [TestMethod]
    public void TestEqualsMusicalInstrument3()
    {
        Assert.IsFalse(baseMusicalInstrument.Equals(baseStudent));
    }

    [TestMethod]
    public void TestCompareToMusicalInstrument1()
    {
        Assert.AreEqual(-1, baseMusicalInstrument.CompareTo(nullMusicalInstrument));
    }

    [TestMethod]
    public void TestCompareToMusicalInstrument2()
    {
        Assert.AreEqual(0, baseMusicalInstrument.CompareTo(baseMusicalInstrument1));
    }

    [TestMethod]
    public void TestCloneMusicalInstrument()
    {
        MusicalInstrument cloned = (MusicalInstrument)createdMusicalInsrument.Clone();
        Assert.AreEqual(createdMusicalInsrument.Id.Id, cloned.Id.Id);
        Assert.AreEqual(createdMusicalInsrument.Name, cloned.Name);
    }

    [TestMethod]
    public void TestCopyMusicalInstrument()
    {
        MusicalInstrument copied = (MusicalInstrument)createdMusicalInsrument.ShallowClone();
        Assert.AreEqual(createdMusicalInsrument.Id.Id, copied.Id.Id);
        Assert.AreEqual(createdMusicalInsrument.Name, copied.Name);
    }

    [TestMethod]
    public void TestToStringMusicalInstrument()
    {
        string correctString = $"ID инструмента: 474, Название инструмента: Контробас\n";
        Assert.AreEqual(correctString, createdMusicalInsrument.ToString());
    }
}