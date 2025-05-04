// See https://aka.ms/new-console-template for more information

using RomanNumeralsTests;

Console.WriteLine("----- Roman Numeral Converter -----");

var inputRead = false;
uint number = 0;
while (!inputRead)
{
    Console.WriteLine("Insert a number between 0 and 3999");
    inputRead = uint.TryParse(Console.ReadLine(), out number);
}

Console.WriteLine($"The roman numeral is: {RomanNumeral.FromArabic(number)}");
Console.WriteLine("--------------------------------");

