using UtilityKit.Components.Nsd.Domain.Exceptions;

namespace UtilityKit.Components.Und.Domain.Exceptions.Broker;
public class Widget_Files_Format_Exception : BusinessException
{
    public Widget_Files_Format_Exception() :
        base(
        3,
        "Widget file Must be  in format [.zip]",
        "",
        HttpStatusCode.BadRequest)
    { }
}