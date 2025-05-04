using Xunit;
using FluentAssertions;

namespace RomanNumeralsTests;

public class RomanNumeralTests
{
    [Fact]
    public void ConvertFromArabic_NumberGreaterThan3999_IsRejected()
    {
        //Arrange
        const int arabic = 4000;
        
        var action = () => RomanNumeral.FromArabic(arabic);
        
        //Act & Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Numbers greater than 3999 are not supported.");
    }
    
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(10, "X")]
    [InlineData(20, "XX")]
    public void FromArabic_ReturnsExpectedRomanNumeral(int arabic, string expectedNumeral)
    {
        //Arrange
        var expected = new RomanNumeral(expectedNumeral, arabic);
        
        //Act
        var actual = RomanNumeral.FromArabic(arabic);
        
        //Assert
        actual.Should().BeEquivalentTo(expected);
    }
}

public class RomanNumeral(string numeral, int value)
{
    public string Numeral { get; set; } = numeral;
    public int Value { get; set; } = value;

    private static readonly List<(int Arabic, string Numeral)> Numerals =
    [
        (1, "I"),
        (5, "V"),
        (10, "X")
    ];

    public static RomanNumeral FromArabic(int arabic)
    {
        if(arabic > 3999)
            throw new ArgumentException("Numbers greater than 3999 are not supported.");

        var numeral = "";
        var arabicToProcess = arabic;

        foreach (var numeralLookup in Numerals.OrderByDescending(x => x.Numeral))
        {
            while (arabicToProcess >= numeralLookup.Arabic)
            {
                numeral += numeralLookup.Numeral;
                arabicToProcess -= numeralLookup.Arabic;
            }
        }
        
        return new RomanNumeral(numeral, arabic);
    }
}

