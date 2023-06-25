using KouMobilio.Components.Common;

namespace KouMobilio.Components.Components;

public class ListViewer : BaseComponent
{
    public List<string> Items { get; set; }
    public BorderSettings Border { get; set; }
    public string Color { get; set; }
    public string OnClick { get; set; }
}