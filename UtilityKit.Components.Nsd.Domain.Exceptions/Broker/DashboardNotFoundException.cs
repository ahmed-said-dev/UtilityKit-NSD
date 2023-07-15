using UtilityKit.Components.Nsd.Domain.Exceptions;

namespace UtilityKit.Components.Und.Domain.Exceptions.Broker;
public class DashboardNotFoundException : BusinessException
{
    public DashboardNotFoundException() :
        base(
        1,
        "Dashboard not found.",
        "",
        HttpStatusCode.BadRequest)
    { }
}