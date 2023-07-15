using Microsoft.EntityFrameworkCore;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Infrastrcuture.Repositories
{
    public class WidgetRepository : IWidgetRepository
    {
        private readonly DbSet<Widget> _WidgetContext;

        #region --- Constructor
        public WidgetRepository(NsdDbContext context)
        {
            _WidgetContext = context.Set<Widget>();
        }


        #endregion

        #region --- Methods
        public async Task<Widget> Add(Widget NewWidget, CancellationToken cancellationToken)
        {
             await _WidgetContext.AddAsync(NewWidget);
             return NewWidget;
        }
        public async Task<List<Widget>> GetAll(CancellationToken cancellationToken)
        {
            return await _WidgetContext.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Widget> GetByID(Guid WidgetId,CancellationToken cancellationToken)
        {
          return  await _WidgetContext.FindAsync(WidgetId);
        }

        public async Task<bool> IsNameExtisting(string WidgetName, CancellationToken cancellationToken)
        {
           var widget= await _WidgetContext.FirstOrDefaultAsync(n => n.Name == WidgetName);
           return widget == null ? false : true;
        }
        #endregion

        #region --- Get Widget
        public async Task<Widget> GetWidget(Guid WidgetId, CancellationToken cancellationToken)
        {
            return await _WidgetContext.AsNoTracking().Where(x => x.Id == WidgetId).FirstOrDefaultAsync(cancellationToken);
        }
        #endregion
        #region --- Update Widget
        public Widget UpdateWidget(Widget widget, CancellationToken token)
        {
            widget.LastModifiedDate = DateTime.Now;
            _WidgetContext.Update(widget);
            return widget;
        }
        #endregion

        #region --- Is Configuration Definition Key Unique
        public async Task<bool> IsConfigurationDefinitionKeyUnique(string key, Guid widgetId, string? oldKey, CancellationToken cancellationToken)
        {
            bool isUnique = true;
            key = key.ToLower().Trim();

            var widgets = await _WidgetContext.AsNoTracking().Where(x => x.Id == widgetId).FirstOrDefaultAsync(cancellationToken);
            if (oldKey != null)
            {
                oldKey = oldKey.ToLower().Trim();
                var i = widgets.ConfigurationDefinitions.FindIndex(x => x.Key.ToLower().Trim() == oldKey);
                if(i is int & i > -1)
                    widgets.ConfigurationDefinitions.RemoveAt(i);
            }

   
            foreach (var ConfigurationDefinition in widgets.ConfigurationDefinitions)
            {
                if(ConfigurationDefinition.Key.ToLower().Trim() == key)
                {
                    isUnique = false;
                    return isUnique;
                }
            }
            return isUnique;
        }
        #endregion
    }
}
