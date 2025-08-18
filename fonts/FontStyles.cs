namespace Chizl.ConsoleFonts
{
    /// <summary>
    /// Used for Console.Write/WriteLine to manipulate inline text.  Using Reset will end each manipulation within the string.<br/>
    /// <code>
    /// Example:<br/>
    ///     Console.WriteLine($"This is my " + <br/>
    ///                         "{FontStyle.Underline}UNDERLINE{FontStyle.Reset} and " + <br/>
    ///                         "{FontStyle.Strike}{FontStyle.BLINK}Striked and Blinking{FontStyle.Reset} " + <br/>
    ///                         "text.");<br/>
    /// </code>
    /// </summary>
    public readonly struct FontStyles
    {
        private readonly FontStyleEx _style;
        private readonly string _name;
        private readonly string _value;
        private readonly int _numValue;

        /// <summary>
        /// Returns the Ascii Escape, make following text Reset from previous Font Styles and Console Colors.<br/>
        /// <code>
        /// Console.WriteLine($"This is my {FontStyle.Bold}BOLD{<b>FontStyle.Reset</b>} format.");
        /// </code>
        /// </summary>
        public static FontStyles Reset => new FontStyles(FontStyleEx.RESET);
        /// <summary>
        /// Returns the Ascii Escape, make following text in bold format.<br/>
        /// Will persist until Reset called.<br/>
        /// <b>NOTE</b>: Based on console/terminal font settings, this might not look bold.
        /// <code>
        /// Console.WriteLine($"This is my {<b>FontStyle.Bold</b>}BOLD{FontStyle.Reset} format.");
        /// </code>
        /// </summary>
        public static FontStyles Bold => new FontStyles(FontStyleEx.BOLD);
        /// <summary>
        /// Returns the Ascii Escape, make following text darken from existing color.<br/>
        /// Will persist until Reset called.<br/>
        /// <code>
        /// Console.WriteLine($"This is my {<b>FontStyle.Disabled</b>}DISABLED{FontStyle.Reset} format.");
        /// </code>
        /// </summary>
        public static FontStyles Disabled => new FontStyles(FontStyleEx.DISABLED);
        /// <summary>
        /// Returns the Ascii Escape, make following text show in italics format.<br/>
        /// Will persist until Reset called.<br/>
        /// <code>
        /// Console.WriteLine($"This is my {<b>FontStyle.Italics</b>}ITALICS{FontStyle.Reset} format.");
        /// </code>
        /// </summary>
        public static FontStyles Italics => new FontStyles(FontStyleEx.ITALICS);
        /// <summary>
        /// Returns the Ascii Escape, make following text underlined.<br/>
        /// Will persist until Reset called.<br/>
        /// <code>
        /// Console.WriteLine($"This is my {<b>FontStyle.Underline</b>}UNDERLINE{FontStyle.Reset} format.");
        /// </code>
        /// </summary>
        public static FontStyles Underline => new FontStyles(FontStyleEx.UNDERLINE);
        /// <summary>
        /// Returns the Ascii Escape, make following text blink the existing color.<br/>
        /// Will persist until Reset called.<br/>
        /// <code>
        /// Console.WriteLine($"This is my {<b>FontStyle.Blink</b>}BLINK{FontStyle.Reset} format.");
        /// </code>
        /// </summary>
        public static FontStyles Blink => new FontStyles(FontStyleEx.BLINK);
        /// <summary>
        /// Returns the Ascii Escape, make following text invert Foreground and Background colors.<br/>
        /// Will persist until Reset or Invert is called again.<br/>
        /// <code>
        /// Console.WriteLine($"This is my {<b>FontStyle.Invert</b>}INVERT{FontStyle.Reset} format.");
        /// </code>
        /// </summary>
        public static FontStyles Invert => new FontStyles(FontStyleEx.INVERT);
        /// <summary>
        /// Returns the Ascii Escape, make following text the same color as the background color.<br/>
        /// Good to use for text loggers and not show all text in the console.<br/>
        /// Will persist until Reset called.<br/>
        /// <code>
        /// Console.WriteLine($"This is my {<b>FontStyle.Invisible</b>}INVISIBLE{FontStyle.Reset} format.");
        /// </code>
        /// </summary>
        public static FontStyles Invisible => new FontStyles(FontStyleEx.INVISIBLE);
        /// <summary>
        /// Returns the Ascii Escape, make following text striked through.<br/>
        /// Will persist until Reset is called.<br/>
        /// <code>
        /// Console.WriteLine($"This is my {<b>FontStyle.Strike</b>}STRIKE{FontStyle.Reset} format.");
        /// </code>
        /// </summary>
        public static FontStyles Strike => new FontStyles(FontStyleEx.STRIKE);

        #region Private Constructor
        private FontStyles(FontStyleEx style)
        {
            _style = style;
            _name = _style.Name();
            _numValue = _style.Value();
            _value = style.AsciiEsc();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns the name of the style used.
        /// </summary>
        public string Name => _name;
        /// <summary>
        /// Returns the Ascii Escape string.
        /// </summary>
        public string Value => _value;
        /// <summary>
        /// Numeric Ascii Escape value
        /// </summary>
        public int NumberValue => _numValue;
        #endregion

        #region Validate
        /// <summary>
        /// Determines whether this instance and another specified FontStyle object have the same NumberValue.
        /// </summary>
        /// <param name="other">The FontStyle object to compare to this instance.</param>
        /// <returns>
        /// true if the NumberValue of the value parameter is the same as the NumberValue of this instance;<br/>
        /// otherwise, false.  If NumberValue is null, the method returns false.
        /// </returns>
        public bool Equals(FontStyles other) => this.NumberValue.Equals(other.NumberValue);
        #endregion

        #region Public Overrides
        /// <summary>
        /// Returns the hash code for this object's Name and Value combined.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() => $"{this.Name}:{this.NumberValue}".GetHashCode();
        public override bool Equals(object obj) => obj is FontStyles other && Equals(other);
        public override string ToString() => this.Value;
        #endregion

        #region Public Operators
        public static bool operator ==(FontStyles left, FontStyles right) => left.GetHashCode() == right.GetHashCode();
        public static bool operator !=(FontStyles left, FontStyles right) => left.GetHashCode() != right.GetHashCode();
        #endregion
    }
}
