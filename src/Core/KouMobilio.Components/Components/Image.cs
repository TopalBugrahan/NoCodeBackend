using KouMobilio.Components.Common;
using KouMobilio.Components.Enums;

namespace KouMobilio.Components.Components;

public class Image : BaseComponent
{
    public string ImageUrl { get; set; }
    public BorderSettings Border { get; set; }
    public ResizeMode Mode { get; set; }
    public string OnClick { get; set; }
}