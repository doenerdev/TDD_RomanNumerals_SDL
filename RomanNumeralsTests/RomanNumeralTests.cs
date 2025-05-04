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

    public static RomanNumeral FromArabic(int arabic)
    {
        if(arabic > 3999)
            throw new ArgumentException("Numbers greater than 3999 are not supported.");

        var numeral = "";
        var arabicToProcess = arabic;
        
        if (arabic >= 5)
        {
            numeral += "V";
            arabicToProcess -= 5;
        }
        
        for (var i = 0; i < arabicToProcess; i++)
            numeral += "I";
        
        return new RomanNumeral(numeral, arabic);
    }
}

