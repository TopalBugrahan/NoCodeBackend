using KouMobilio.Components.Abstraction;

namespace KouMobilio.Components.Layouts;

public abstract class BaseLayout : ILayout
{
    public List<IConvertable> Content { get; set; }
}