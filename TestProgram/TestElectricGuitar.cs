namespace TestProgram;
using Lab10;
using Lab9_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestElectricGuitar
{
    private Student student;
    
    private ElectricGuitar baseElectricGuitar;
    private ElectricGuitar baseElectricGuitar1;

    [TestInitialize]
    public void InitializeElectricGuitar()
    {
        student = new Student();
        
        baseElectricGuitar = new ElectricGuitar();
        baseElectricGuitar1 = new ElectricGuitar();
    }

    [TestMethod]
    public void TestNumberElectricGuitars()
    {
        Assert.AreEqual(2, ElectricGuitar.NumberElectricGuitars);
    }

    [TestMethod]
    public void TestBasicElectricGuitar()
    {
        Assert.AreEqual("Электрическая гитара", baseElectricGuitar.Name);
        Assert.AreEqual(0, baseElectricGuitar.Id.Id);
        Assert.AreEqual(6, baseElectricGuitar.NumberStrings);
        Assert.AreEqual("Аккумулятор", baseElectricGuitar.PowerSource);
    }

    [TestMethod]
    public void TestWrongElectricGuitar1()
    {
        try
        {
            ElectricGuitar brokenGuitar = new ElectricGuitar("аккумулятор", 0, 15);
            Assert.Fail("Количество струн в сломанной электрогитаре не положительное число");
        }
        catch (Exception e)
        {
            Assert.AreEqual("Количество струн должно быть положительным числом", e.Message);
        }
    }

    [TestMethod]
    public void TestWrongElectricGuitar2()
    {
        try
        {
            ElectricGuitar brokenGuitar = new ElectricGuitar("неизвестный источник", 6, 15);
            Assert.Fail("Источник питания не из списка доступных");
        }
        catch (Exception e)
        {
            Assert.AreEqual("Нет данного источника питания!", e.Message);
        }
    }

    [TestMethod]
    public void TestEqualsGuitar1()
    {
        Assert.IsTrue(baseElectricGuitar.Equals(baseElectricGuitar1));
    }

    [TestMethod]
    public void TestEqualsGuitar2()
    {
        Assert.IsFalse(baseElectricGuitar.Equals(student));
    }

    [TestMethod]
    public void TestToStringElectricGuitar()
    {
        string correctString = "ID инструмента: 0, Название инструмента: Электрическая гитара\n" +
                               "Количество струн: 6\n" +
                               "Источник питания: Аккумулятор\n";
        Assert.AreEqual(correctString, baseElectricGuitar.ToString());
    }

    [TestMethod]
    public void TestCloneElectricGuitar()
    {
        ElectricGuitar cloned = (ElectricGuitar)baseElectricGuitar.Clone();
        Assert.IsTrue(baseElectricGuitar.Id.Equals(cloned.Id));
        Assert.AreEqual(baseElectricGuitar.Name, cloned.Name);
        Assert.AreEqual(baseElectricGuitar.NumberStrings, cloned.NumberStrings);
        Assert.AreEqual(baseElectricGuitar.PowerSource, cloned.PowerSource);
    }

    [TestMethod]
    public void TestCopyElectricGuitar()
    {
        ElectricGuitar copied = (ElectricGuitar)baseElectricGuitar.ShallowClone();
        Assert.IsTrue(baseElectricGuitar.Id.Equals(copied.Id));
        Assert.AreEqual(baseElectricGuitar.Name, copied.Name);
        Assert.AreEqual(baseElectricGuitar.NumberStrings, copied.NumberStrings);
        Assert.AreEqual(baseElectricGuitar.PowerSource, copied.PowerSource);
    }
}