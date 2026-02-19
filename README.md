# Chizl.ConsoleFonts 
<!-- ![logo](https://raw.githubusercontent.com/gavin1970/Chizl.ConsoleFonts/refs/heads/master/ChizlConsoleFonts_256x256.png) -->

[![NuGet Version](https://img.shields.io/nuget/v/Chizl.ConsoleFonts)](https://www.nuget.org/packages/Chizl.ConsoleFonts)
[![License](https://img.shields.io/badge/license-MIT-green)](https://github.com/gavin1970/Chizl.ConsoleFonts/blob/master/LICENSE.md)
[![.NET](https://img.shields.io/badge/.NET-Standard%202.0%20%7C%202.1%20-purple)](https://dotnet.microsoft.com/)

A lightweight, cross-platform .NET library for adding **font styles** to console applications using ANSI escape sequences.

---

![example](https://raw.githubusercontent.com/gavin1970/Chizl.ConsoleFonts/refs/heads/master/FontDemo/docs/example.gif)

---
## 📦 Installation

### NuGet Package Manager

Install-Package Chizl.ConsoleFonts

### .NET CLI

dotnet add package Chizl.ConsoleFonts

### PackageReference
```xml
<PackageReference Include="Chizl.ConsoleFonts" />
```
> **Note:** Omitting the version attribute automatically uses the latest stable release. To pin a specific version, use `Version="x.x.x"`.

---

## 🎯 Features

- ✅ Simple, fluent API for console text styling
- ✅ Multiple font styles: **Bold**, *Italics*, <u>Underline</u>, ~~Strike~~, Blink, and more
- ✅ Cross-platform support (.NET Standard 2.0/2.1)
- ✅ Zero dependencies
- ✅ Lightweight and performant
- ✅ Works with modern terminals that support ANSI escape sequences

---

## 📖 Available Styles

| Style | Description | Usage Example |
|-------|-------------|---------------|
| `Bold` | Makes text bold | `{FontStyles.Bold}text{FontStyles.Reset}` |
| `Disabled` | Darkens text from existing color | `{FontStyles.Disabled}text{FontStyles.Reset}` |
| `Italics` | Makes text italic | `{FontStyles.Italics}text{FontStyles.Reset}` |
| `Underline` | Adds single underline | `{FontStyles.Underline}text{FontStyles.Reset}` |
| `DOUBLE_UNDERLINE` | Adds double underline | `{FontStyles.DOUBLE_UNDERLINE}text{FontStyles.Reset}` |
| `Blink` | Makes text blink | `{FontStyles.Blink}text{FontStyles.Reset}` |
| `Invert` | Swaps foreground/background colors | `{FontStyles.Invert}text{FontStyles.Reset}` |
| `Invisible` | Hides text (same as background) | `{FontStyles.Invisible}text{FontStyles.Reset}` |
| `Strike` | Adds strikethrough | `{FontStyles.Strike}text{FontStyles.Reset}` |
| `Reset` | Resets all styles | `{FontStyles.Reset}` |

---

## 💡 Usage Examples

### Basic Styling

```csharp
Console.WriteLine($"This is my {FontStyles.Underline}UNDERLINE{FontStyles.Reset} text.");
```

### Multiple Styles

```csharp
Console.WriteLine($"This is my {FontStyles.Bold}{FontStyles.Italics}BOLD ITALICS{FontStyles.Reset} text.");
Console.WriteLine($"This is my {FontStyles.Underline}{FontStyles.Blink}UNDERLINE BLINK{FontStyles.Reset} text.");
```

### Hiding Sensitive Information
```csharp
// Good for logging without displaying sensitive data in console 
Console.WriteLine($"Password: {FontStyles.Invisible}secret123{FontStyles.Reset}");
```

---

## 🛠️ Properties

Each `FontStyles` instance provides the following properties:

- `Name` - Returns the name of the style (e.g., "BOLD", "UNDERLINE")
- `Value` - Returns the ANSI escape sequence string
- `NumberValue` - Returns the numeric ANSI escape value

```csharp
var style = FontStyles.Bold; 
Console.WriteLine($"Name: {style.Name}");
// "BOLD" 
Console.WriteLine($"Value: {style.Value}");
// "\x1b[1m" 
Console.WriteLine($"Number: {style.NumberValue}"); // 1
```

---

## ⚙️ Requirements

- **.NET Standard 2.0** or higher
- Terminal/console with ANSI escape sequence support
  - Windows Terminal ✅
  - PowerShell 7+ ✅
  - Linux/macOS terminals ✅
  - Legacy Windows Command Prompt (limited support)

---

## ⚠️ Important Notes

1. **Always use `FontStyles.Reset`** after applying styles to avoid style bleeding into subsequent text
2. **Bold appearance** depends on your terminal's font settings
3. **Blink support** varies by terminal (many modern terminals disable blinking)
4. Set `Console.OutputEncoding = Encoding.UTF8;` for best compatibility

---

## 📄 License

© 2024 chizl.com

---

## 🔗 Links

- [GitHub Repository](https://github.com/gavin1970/Chizl.ConsoleFonts)
- [NuGet Package](https://www.nuget.org/packages/Chizl.ConsoleFonts)

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check the [issues page](https://github.com/gavin1970/Chizl.ConsoleFonts/issues).

---

**Made with experience by Chizl**

