using UtilityKit.Components.Nsd.Domain.Exceptions;

namespace UtilityKit.Components.Und.Domain.Exceptions.Broker;
public class Widget_Thumbnail_Extention_Exception : BusinessException
{
    public Widget_Thumbnail_Extention_Exception() :
        base(
        4,
        "Widget Thumbnail Must be  in Format  [ .jpg - .png , .jpeg ]",
        "",
        HttpStatusCode.BadRequest)
    { }
}