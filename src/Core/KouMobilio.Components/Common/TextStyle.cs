using KouMobilio.Components.Enums;

namespace KouMobilio.Components.Common;

public class TextStyle
{
    public string FontFamily { get; set; }
    public string Size { get; set; }
    public string TextColor { get; set; }
    public TextDecorationLine TextDecoration { get; set; }
    public TextAlign Align { get; set; }
}