using KouMobilio.Components.Abstraction;
using KouMobilio.Components.Common;

namespace KouMobilio.Components.Components;

public abstract class BaseComponent : IConvertable
{
    public string ElementId { get; set; }
    public bool Visible { get; set; }
    public DimensionSettings Size { get; set; }
    public PositionSettings Position { get; set; }
}