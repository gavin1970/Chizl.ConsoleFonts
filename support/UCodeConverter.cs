using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Chizl.EmojiLive.support
{
    internal class UCodeConverter
    {
        /// <summary>
        /// Converts Hex string into Unicode escape string<br/>
        /// <code>
        ///     var unicodeEscapeString = HexToUnicodeEscapes("1F469 200D 1F469 200D 1F467 200D 1F467");<br/>
        ///     Output: "\U0001F469\u200D\U0001F469\u200D\U0001F467\u200D\U0001F467";<br/>
        /// </code>
        /// </summary>
        /// <param name="input">Unicode Escape string</param>
        /// <returns>Hex string</returns>
        public static string HexToUnicodeEscapes(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var output = new StringBuilder();
            var hexValues = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string hexValue in hexValues)
            {
                if (hexValue.Length <= 4)
                {
                    output.Append("\\u").Append(hexValue.PadLeft(4, '0')); // Pad with zeros for \u
                }
                else if (hexValue.Length <= 8)
                {
                    output.Append("\\U").Append(hexValue.PadLeft(8, '0')); // Pad with zeros for \U
                }
                else
                {
                    // Handle invalid hex values (e.g., longer than 8 characters)
                    // You might want to throw an exception or log an error here
                    Console.WriteLine($"Warning: Invalid hex value: {hexValue}");
                    output.Append(hexValue).Append(' '); // Append as is with a space
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Converts Unicode escape string into Hex string<br/>
        /// <code>
        ///     var hexString = UnicodeEscapesToHex("\U0001F469\u200D\U0001F469\u200D\U0001F467\u200D\U0001F467");<br/>
        ///     Output hexString = "1F469 200D 1F469 200D 1F467 200D 1F467";<br/>
        /// </code>
        /// </summary>
        /// <param name="input">Unicode Escape string</param>
        /// <returns>Hex string</returns>
        public static string UnicodeEscapesToHex(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var output = new StringBuilder();
            var matches = Regex.Matches(input, @"\\U([0-9A-Fa-f]{8})|\\u([0-9A-Fa-f]{4})");

            var lastIndex = 0;
            foreach (Match match in matches)
            {
                // Append any characters before the current match
                _ = output.Append(input.Substring(lastIndex, match.Index - lastIndex));

                var hexValue = match.Groups[1].Success ? match.Groups[1].Value : match.Groups[2].Value;
                output.Append(hexValue).Append(' ');

                lastIndex = match.Index + match.Length;
            }

            // Append any remaining characters after the last match
            output.Append(input.Substring(lastIndex));

            return output.ToString().Trim(); // Trim trailing space
        }
    }
    /*
            Console.WriteLine($"[\U0001F43B\x200D\x2744\xFE0F]");
            Console.ReadKey(true); // Keep the console window open

            // Define the code points for the polar bear emoji
            //char bear = '\U0001F43B'; // Brown bear
            string bear = "\U0001F43B"; // Brown bear
            char joiner = '\u200D';
            char snowflake = '\u2744';
            char variationSelector = '\uFE0F';
            
            string combine = new string(new[] { joiner, snowflake, variationSelector });
            // Combine the code points to form the polar bear emoji
            string polarBearEmoji = $"{bear}{combine}";

            // Print the polar bear emoji to the console
            Console.WriteLine(polarBearEmoji);

            Console.ReadKey(true); // Keep the console window open
    */
    /*
        string input = @"\U0001F469\u200D\U0001F469\u200D\U0001F467\u200D\U0001F467";
        string expectedOutput = "1F469 200D 1F469 200D 1F467 200D 1F467";
        string output = ConvertUnicodeEscapesToHex(input);

        Console.WriteLine($"Input: {input}");
        Console.WriteLine($"Output: {output}");
        Console.WriteLine($"Expected Output: {expectedOutput}");
        Console.WriteLine($"Match: {output == expectedOutput}");

        input = ""; // Test with empty string
        expectedOutput = "";
        output = ConvertUnicodeEscapesToHex(input);

        Console.WriteLine($"Input: {input}");
        Console.WriteLine($"Output: {output}");
        Console.WriteLine($"Expected Output: {expectedOutput}");
        Console.WriteLine($"Match: {output == expectedOutput}"); 
     */
}
