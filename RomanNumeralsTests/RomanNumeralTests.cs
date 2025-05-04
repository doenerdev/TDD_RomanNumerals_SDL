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

    [Theory]
    [InlineData(1, "I", "I")]
    [InlineData(35, "XXXV", "XXXV")]
    public void ToString_ReturnsNumeral(uint arabic, string numeral, string expected)
    {
        //Arrange
        var sut = new RomanNumeral(numeral, arabic);
        
        //Act
        sut.ToString().Should().Be(expected);
    }
}