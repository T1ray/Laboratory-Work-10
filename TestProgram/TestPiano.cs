namespace TestProgram;
using Lab10;
using Lab9_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestPiano
{
    private Student student;
    
    private Piano basePiano;
    private Piano basePiano1;

    [TestInitialize]
    public void InitializePiano()
    {
        student = new Student();
        
        basePiano = new Piano();
        basePiano1 = new Piano();
    }

    [TestMethod]
    public void TestNumberPianos()
    {
        Assert.AreEqual(2, Piano.NumberPianos);
    }

    [TestMethod]
    public void TestBasicPiano()
    {
        Assert.AreEqual("Фортепиано", basePiano.Name);
        Assert.AreEqual(0, basePiano.Id.Id);
        Assert.AreEqual(88, basePiano.NumberKeys);
        Assert.AreEqual("октавная", basePiano.KeyLayout);
    }

    [TestMethod]
    public void TestWrongPiano1()
    {
        try
        {
            Piano brokenPiano = new Piano(0, "октавная", 15);
            Assert.Fail("Количество клавиш в сломанном фортепиано не положительное число");
        }
        catch (Exception e)
        {
            Assert.AreEqual("Количество клавиш не может быть отрицательным числом!", e.Message);
        }
    }

    [TestMethod]
    public void TestWrongPiano2()
    {
        try
        {
            Piano brokenPiano = new Piano(88, "неизвестная раскладка", 15);
            Assert.Fail("Раскладка клавиш не из списка доступных");
        }
        catch (Exception e)
        {
            Assert.AreEqual("Нет такой раскладки клавиш!", e.Message);
        }
    }

    [TestMethod]
    public void TestEqualsPiano1()
    {
        Assert.IsTrue(basePiano.Equals(basePiano1));
    }

    [TestMethod]
    public void TestEqualsPiano2()
    {
        Assert.IsFalse(basePiano.Equals(student));
    }

    // [TestMethod]
    // public void TestEqualsDifferentKeyLayout()
    // {
    //     Piano differentLayout = new Piano(88, "шкальная", 0);
    //     Assert.IsFalse(basePiano.Equals(differentLayout));
    // }

    // [TestMethod]
    // public void TestEqualsDifferentId()
    // {
    //     Piano differentId = new Piano(88, "октавная", 1);
    //     Assert.IsFalse(basePiano.Equals(differentId));
    // }

    [TestMethod]
    public void TestToStringPiano()
    {
        string correctString = "ID инструмента: 0, Название инструмента: Фортепиано\n" +
                               "Раскладка клавиш: октавная \nКоличество клавиш: 88\n";
        Assert.AreEqual(correctString, basePiano.ToString());
    }

    [TestMethod]
    public void TestClonePiano()
    {
        Piano cloned = (Piano)basePiano.Clone();
        Assert.IsTrue(basePiano.Id.Equals(cloned.Id));
        Assert.AreEqual(basePiano.Name, cloned.Name);
        Assert.AreEqual(basePiano.NumberKeys, cloned.NumberKeys);
        Assert.AreEqual(basePiano.KeyLayout, cloned.KeyLayout);
    }

    [TestMethod]
    public void TestCopyPiano()
    {
        Piano copied = (Piano)basePiano.ShallowClone();
        Assert.IsTrue(basePiano.Id.Equals(copied.Id));
        Assert.AreEqual(basePiano.Name, copied.Name);
        Assert.AreEqual(basePiano.NumberKeys, copied.NumberKeys);
        Assert.AreEqual(basePiano.KeyLayout, copied.KeyLayout);
    }
}