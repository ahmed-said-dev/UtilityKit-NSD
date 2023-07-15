using UtilityKit.Components.Nsd.Domain.Exceptions;

namespace UtilityKit.Components.Und.Domain.Exceptions.Broker;
public class Widget_Name_Exist_Exception : BusinessException
{
    public Widget_Name_Exist_Exception() :
        base(
        2,
        "Widget Name IS Already Existing",
        "",
        HttpStatusCode.BadRequest)
    { }
}