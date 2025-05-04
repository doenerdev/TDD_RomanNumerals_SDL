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
}

public class RomanNumeral(string numeral, int value)
{
    public string Numeral { get; set; } = numeral;
    public int Value { get; set; } = value;

    public static RomanNumeral FromArabic(int arabic)
    {
        throw new ArgumentException("Numbers greater than 3999 are not supported.");
    }
}

