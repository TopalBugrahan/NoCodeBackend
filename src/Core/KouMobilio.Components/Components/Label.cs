using KouMobilio.Components.Common;

namespace KouMobilio.Components.Components;

public class Label : BaseComponent
{
    public TextStyle TextStyle { get; set; }
    public string Text { get; set; }
    public BorderSettings Border { get; set; }
    public string BackgroundColor { get; set; }
    public string OnClick { get; set; }
}