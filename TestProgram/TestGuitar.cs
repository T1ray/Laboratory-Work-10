namespace TestProgram;
using Lab10;
using Lab9_1;

[TestClass]
public class TestGuitar
{
    private Student student;
    
    private Guitar baseGuitar;
    private Guitar baseGuitar1;
    
    [TestInitialize]
    public void InitializeGuitar()
    {
        student = new Student();
        
        baseGuitar = new Guitar();
        baseGuitar1 = new Guitar();
    }

    [TestMethod]
    public void TestNumberGuitars()
    {
        Assert.AreEqual(22, Guitar.NumberGuitars);
    }

    [TestMethod]
    public void TestBasicGuitar()
    {
        Assert.AreEqual("Гитара", baseGuitar.Name);
        Assert.AreEqual(0, baseGuitar.Id.Id);
        Assert.AreEqual(4, baseGuitar.NumberStrings);
    }

    [TestMethod]
    public void TestWrongGuitar()
    {
        try
        {
            Guitar brokenGuitar = new Guitar(0, 15);
            Assert.Fail("Количество строк в сломанной гитаре не положительное число");
        }
        catch (Exception e) { }
    }

    [TestMethod]
    public void TestEqualsGuitar1()
    {
        Assert.IsTrue(baseGuitar.Equals(baseGuitar1));
    }

    [TestMethod]
    public void TestEqualsGuitar2()
    {
        Assert.IsFalse(baseGuitar.Equals(student));
    }

    [TestMethod]
    public void TestToStringGuitar()
    {
        string correctString = "ID инструмента: 0, Название инструмента: Гитара\n" +
                               "Количество струн: 4\n";
        Assert.AreEqual(correctString, baseGuitar.ToString());
    }

    [TestMethod]
    public void TestCloneGuitar()
    {
        Guitar cloned = (Guitar)baseGuitar.Clone();
        Assert.IsTrue(baseGuitar.Id.Equals(cloned.Id));
        Assert.AreEqual(baseGuitar.Name, cloned.Name);
        Assert.AreEqual(baseGuitar.NumberStrings, cloned.NumberStrings);
    }
    
    [TestMethod]
    public void TestCopyGuitar()
    {
        Guitar copied = (Guitar)baseGuitar.ShallowClone();
        Assert.IsTrue(baseGuitar.Id.Equals(copied.Id));
        Assert.AreEqual(baseGuitar.Name, copied.Name);
        Assert.AreEqual(baseGuitar.NumberStrings, copied.NumberStrings);
    }
}