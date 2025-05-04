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
    
    [Fact]
    public void ConvertFromArabic_GivenNumber1_Literal_I_IsReturned()
    {
        //Arrange
        const int arabic = 1;
        var expected = new RomanNumeral("I", arabic);
        
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
        throw new ArgumentException("Numbers greater than 3999 are not supported.");
    }
}

