using System;
using System.Text;
using System.Linq;
using System.Reflection;
using static Chizl.ConsoleFonts.FontStyles;

namespace FontDemo
{
    internal class Program
    {
        static readonly Encoding _defaultEncoding = Encoding.UTF8;

        const string _styleStructNamespace = "Chizl.ConsoleFonts";
        const string _styleStructName = "FontStyles";
        const string _clearScreen = "\u001bc\x1b[3J";

        static void Main(string[] args)
        {
            Console.OutputEncoding = _defaultEncoding;
            Console.WriteLine($" This is my {Blink}Blinking {Invert}Inverted{Reset} text.");
            ReadKey("Press any key to see all.");

            ClearScreen();
            FontDemo();
        }
        static void ReadKey(string msg)
        {
            if (!msg.StartsWith(" "))
                msg = $" {msg}";
            if (msg.Contains("\n"))
                msg = msg.Replace("\n", "\n ");

            Console.WriteLine(msg);
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.CursorVisible = true;
        }
        static void FontDemo()
        {
            Assembly myAssembly = typeof(Chizl.ConsoleFonts.FontStyles).GetTypeInfo().Assembly;
            Type[] typelist = GetTypesInNamespace(myAssembly, _styleStructNamespace)
                                    .Where(w => w.Name.Equals(_styleStructName)).ToArray();

            if (typelist.Length > 0)
            {
                //Console.WriteLine();
                foreach (var prop in typelist[0].GetProperties())
                {
                    if (!prop.Name.Equals(Reset.Name, StringComparison.CurrentCultureIgnoreCase) && prop.PropertyType.Equals(typeof(Chizl.ConsoleFonts.FontStyles)))
                    {
                        var fsValue = prop.GetValue(0);
                        var fontStyle = (Chizl.ConsoleFonts.FontStyles)prop.GetValue(0);
                        Console.Write($" This is my {fontStyle}{fontStyle.Name.ToUpper()}{Reset} format.");
                        if (fontStyle.Name.Equals(Invisible.Name))
                            Console.Write($" <-- {Invisible.Name.ToUpper()} ");
                        Console.WriteLine();
                    }
                    else if (prop.Name.Equals(Reset.Name, StringComparison.CurrentCultureIgnoreCase))
                        Console.WriteLine($" {Reset.Name.ToUpper()} is only used after formatting.\n");
                }
            }
            Console.WriteLine();
            ReadKey("Press any key to continue");
        }
        static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }
        static void ClearScreen()
        {
            Console.WriteLine(_clearScreen);
        }
    }
}
