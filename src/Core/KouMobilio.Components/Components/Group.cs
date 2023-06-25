using KouMobilio.Components.Common;

namespace KouMobilio.Components.Components;

public class Group : BaseComponent  
{
    public string BackgroundImageUrl { get; set; }
    public string BackgroundColor { get; set; }
    public BorderSettings Border { get; set; }
    public string OnClick { get; set; }
}