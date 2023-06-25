using KouMobilio.Components.Common;

namespace KouMobilio.Components.Components;

public class Slider : BaseComponent
{
    public double Value { get; set; }
    public double Step { get; set; }
    public double MinValue { get; set; }
    public double MaxValue { get; set; }
    public bool Disabled { get; set; }
    public BorderSettings Border { get; set; }
    public string OnSliderComplete { get; set; }
    public string OnChange { get; set; }
}