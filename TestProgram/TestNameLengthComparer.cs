namespace TestProgram;
using Lab10;

[TestClass]
public class TestNameLengthComparer
{
    private NameLengthComparer obj;
    
    private MusicalInstrument? n;
    private MusicalInstrument baseMusicalInstrument;
    private MusicalInstrument musicalInstrument;
    
    [TestInitialize]
    public void Initialize()
    {
        obj = new NameLengthComparer();
        
        n = null;
        baseMusicalInstrument = new MusicalInstrument();
        musicalInstrument = new MusicalInstrument("Саксофон", 200);
    }

    [TestMethod]
    public void TestMethod1()
    {
        Assert.IsTrue(obj.Compare(n, baseMusicalInstrument) == -1);
    }

    [TestMethod]
    public void TestMethod2()
    {
        Assert.IsTrue(obj.Compare(baseMusicalInstrument, n) == 1);
    }

    [TestMethod]
    public void TestMethod3()
    {
        Assert.IsTrue(obj.Compare(n, n) == 0);
    }

    [TestMethod]
    public void TestMethod4()
    {
        Assert.IsTrue(obj.Compare(baseMusicalInstrument, musicalInstrument) < 0);
    }
}