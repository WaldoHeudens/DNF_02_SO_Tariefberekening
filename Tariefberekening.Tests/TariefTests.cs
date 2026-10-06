using Tariefberekening;

namespace Tariefberekening.Tests;

public class TariefTests
{
    [Theory]
    [InlineData(0, 0.00)]
    [InlineData(5, 0.00)]
    public void Bereken_JongKind_ReistGratis(int leeftijd, decimal verwacht)
    {
        Assert.Equal(verwacht, Tarief.Bereken(leeftijd));
    }

    [Theory]
    [InlineData(6)]
    [InlineData(18)]
    [InlineData(25)]
    public void Bereken_Jongere_GeeftJongerentarief(int leeftijd)
    {
        Assert.Equal(1.50m, Tarief.Bereken(leeftijd));
    }

    [Theory]
    [InlineData(26)]
    [InlineData(40)]
    [InlineData(64)]
    public void Bereken_Volwassene_GeeftVolTarief(int leeftijd)
    {
        Assert.Equal(2.50m, Tarief.Bereken(leeftijd));
    }

    [Theory]
    [InlineData(65)]
    [InlineData(80)]
    public void Bereken_Senior_GeeftSeniorentarief(int leeftijd)
    {
        Assert.Equal(1.00m, Tarief.Bereken(leeftijd));
    }

    [Fact]
    public void Bereken_OnbekendeLeeftijd_GeeftVolTarief()
    {
        Assert.Equal(2.50m, Tarief.Bereken(null));
    }

    [Fact]
    public void Bereken_NegatieveLeeftijd_GooitException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Tarief.Bereken(-1));
    }
}
