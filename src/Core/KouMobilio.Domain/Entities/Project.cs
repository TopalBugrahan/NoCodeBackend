using KouMobilio.Domain.Entities.Common;

namespace KouMobilio.Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    public string GlobalStyles { get; set; } = "[]";
    public string Content { get; set; } = "[{\"name\":\"Screen\",\"accepts\":[\"element\",\"inner_element\"],\"lastDroppedItem\":[],\"count\":0,\"isSelect\":false,\"backgroundColor\":\"#FFFFFF\",\"backgroundImage\":null}]";
}