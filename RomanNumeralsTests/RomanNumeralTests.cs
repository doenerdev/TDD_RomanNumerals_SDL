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
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(20, "XX")]
    [InlineData(50, "L")]
    [InlineData(45, "XLV")]
    [InlineData(93, "XCIII")]
    [InlineData(100, "C")]
    [InlineData(421, "CDXXI")]
    [InlineData(500, "D")]
    [InlineData(670, "DCLXX")]
    [InlineData(999, "CMXCIX")]
    [InlineData(1000, "M")]
    [InlineData(3999, "MMMCMXCIX")]
    public void FromArabic_ReturnsExpectedRomanNumeral(uint arabic, string expectedNumeral)
    {
        RomanNumeral
            .FromArabic(arabic)
            .Should()
            .BeEquivalentTo(new RomanNumeral(expectedNumeral, arabic));
    }
}

public class RomanNumeral(string numeral, uint value)
{
    public string Numeral { get; set; } = numeral;
    public uint Value { get; set; } = value;

    private static readonly List<(uint Arabic, string Numeral)> Numerals =
    [
        (1, "I"),
        (4, "IV"),
        (5, "V"),
        (9, "IX"),
        (10, "X"),
        (40, "XL"),
        (50, "L"),
        (90, "XC"),
        (100, "C"),
        (400, "CD"),
        (500, "D"),
        (900, "CM"),
        (1000, "M"),
    ];

    public static RomanNumeral FromArabic(uint arabic)
    {
        if(arabic > 3999)
            throw new ArgumentException("Numbers greater than 3999 are not supported.");

        var numeral = "";
        var arabicToProcess = arabic;

        foreach (var numeralLookup in Numerals.OrderByDescending(x => x.Arabic))
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

