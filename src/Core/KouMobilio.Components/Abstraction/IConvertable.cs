namespace KouMobilio.Components.Abstraction;

public interface IConvertable
{
    public string Type => this.GetType().ToString();
}