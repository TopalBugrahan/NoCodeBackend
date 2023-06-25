using KouMobilio.Components.Common;

namespace KouMobilio.Components.Components;

public class TextInput : BaseComponent
{
    public TextStyle TextStyle { get; set; }
    public string Text { get; set; }
    public string Placeholder { get; set; }
    public int MinLength { get; set; }
    public int MaxLength { get; set; }
    public bool SecureTextEntry { get; set; }
    public string OnClick { get; set; }
    public string OnChange { get; set; }
}