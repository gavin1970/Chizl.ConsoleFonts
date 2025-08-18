using System;
using Chizl.ConsoleFonts;
using System.Text.RegularExpressions;

namespace Chizl
{
    internal static class FontExtensions
    {
        static readonly RegexOptions _regexOptions = RegexOptions.IgnoreCase | 
                                                        RegexOptions.CultureInvariant | 
                                                        RegexOptions.Compiled;

        /// <summary>
        /// Returns the 'string' name of the Enums value being used.<br/>
        /// <code>
        /// Example:<br/>
        ///     var e = MyEnum.Property<br/>
        ///     Console.WriteLine($"Enum property name: {e.Name()}");
        /// </code>
        /// </summary>
        /// <returns>string name of enum property</returns>
        internal static string Name<T>(this T @this)
            where T : Enum, new()
        {
            return Enum.GetName(typeof(T), @this) ?? "";
        }
        /// <summary>
		/// Returns the 'int' value of the Enums value being used.<br/>
		/// Returns 
        /// <code>
        /// Example:<br/>
        ///     var e = MyEnum.Property<br/>
        ///     Console.WriteLine($"Enum property value: {e.Value()}");
        /// </code>
        /// </summary>
        /// <returns>int value of enum property</returns>
        internal static int Value<T>(this T @this)
            where T : Enum, new()
        {
            return (int)(object)@this;
        }
        /// <summary>
        /// Creates the ascii escape characters needed to create the style requested.
        /// </summary>
        internal static string AsciiEsc(this FontStyleEx @this) => $"\x1b[{@this.Value()}m";
        /// <summary>
        /// Creates the ascii escape characters needed to create the style requested.
        /// </summary>
        //internal static string UTF32String(this EmojiEx @this) => @this.Value() <= 0 ? "" : char.ConvertFromUtf32(@this.Value());
        /// <summary>
        /// Creates the ascii escape characters needed to create the style requested.
        /// </summary>
        //internal static string UTF32String(this VariationSelectors @this) => char.ConvertFromUtf32(@this.Value());
        /// <summary>
        /// Takes a RGB Hex string and clean it up.
        /// </summary>
        /// <param name="input">String to validate</param>
        /// <param name="addHash">Add initial hash "#"</param>
        /// <returns>8 byte Hex string.  AARRGGBB/#AARRGGBB e.g. (Green) FF00FF00/#FF00FF00</returns>
        internal static string ColorHex(this string input, bool addHash = false)
        {
            var r = new Regex("[^a-f0-9]", _regexOptions);
            var retVal = r.Replace(input, "");

            //if not 6 or 8 bytes, then this is an invalid RGB Hex string.
            //return what was passed in.
            if (!retVal.Length.Equals(6) && !retVal.Length.Equals(8))
                return input;

            if (retVal.Length.Equals(6))
                retVal += $"FF{retVal}";

            if (addHash)
                retVal = $"#{retVal}";

            return retVal;
        }
    }
}

/*
foreach (var rune in exampleString.EnumerateRunes())
{
    //unicode character
    var charStr = rune.ToString();
    Console.WriteLine($"Symbol/Character: {charStr}");
    Console.WriteLine($"\tDecimal Value: {rune.Value}");
    Console.WriteLine($"\tIsAscii: {rune.IsAscii}");
    Console.WriteLine($"\tIsBmp: {rune.IsBmp}");
    Console.WriteLine($"\tUtf8SequenceLength: {rune.Utf8SequenceLength}");
    Console.WriteLine($"\tUtf16SequenceLength: {rune.Utf16SequenceLength}");
    Console.WriteLine($"\tUnicodeCategory: {char.GetUnicodeCategory((char)rune.Value)}");
    Console.WriteLine($"\tUnicodeCategory: {char.GetUnicodeCategory(charStr, 0)}");
}
*/

