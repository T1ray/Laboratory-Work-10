using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProgram;
using Lab10;
using static Lab10.Program;

[TestClass]
public class TestFunctionsPart2
{
    private MusicalInstrument[] musicalInstruments;

    [TestInitialize]
    public void Initialize()
    {
        musicalInstruments = new MusicalInstrument[] {
            new Guitar(7, 27),
            new ElectricGuitar("Аккумулятор", 8, 715),
            new ElectricGuitar("Фиксированный источник питания", 9 , 3091),
            new Piano(101, 576),
            new Piano(93, 572),
            new ElectricGuitar("Фиксированный источник питания", 8 , 2384),
            new Piano(104, 578),
            new Guitar(9, 74)
        };
    }

    [TestMethod]
    public void TestAverageGuitarStrings()
    {
        Assert.AreEqual(8.2, AverageGuitarStrings(musicalInstruments), 0.001);
    }

    [TestMethod]
    public void TestNumberStringsAllElectricGuitarsFixedPowerSupply()
    {
        Assert.AreEqual(17, NumberStringsAllElectricGuitarsFixedPowerSupply(musicalInstruments));
    }

    [TestMethod]
    public void TestMaxNumberOctavePianoKeys()
    {
        Assert.AreEqual(104, MaxNumberOctavePianoKeys(musicalInstruments));
    }
}