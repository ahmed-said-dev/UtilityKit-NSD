using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Contracts.Repository
{
    public interface IWidgetRepository
    {
        //Get All Widget To List 
        Task<List<Widget>> GetAll(CancellationToken cancellationToken);
        Task<Widget> GetByID(Guid WidgetId,CancellationToken cancellationToken);
        Task<Widget> Add(Widget NewWidget,CancellationToken cancellationToken);
         Task<bool> IsNameExtisting(string WidgetName, CancellationToken cancellationToken);
         Widget UpdateWidget(Widget widget, CancellationToken token);
        Task<bool> IsConfigurationDefinitionKeyUnique(string key, Guid widgetId, string? oldKey, CancellationToken cancellationToken);
    }
}
