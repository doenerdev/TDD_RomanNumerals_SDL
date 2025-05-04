namespace RomanNumeralsTests;

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

    public override string ToString()
    {
        return Numeral;
    }
}