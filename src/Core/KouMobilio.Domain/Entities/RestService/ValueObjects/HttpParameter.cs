using KouMobilio.Domain.Entities.Common;

namespace KouMobilio.Domain.Entities.RestService.ValueObjects;

public class HttpParameter : ValueObject
{
    public Guid RestServiceConfigId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    
    public bool IsHeaderParameter { get; set; }
    
    public HttpParameter()
    {
        
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return RestServiceConfigId;
        yield return Key;
        yield return Value;
        yield return IsHeaderParameter;
    }
}