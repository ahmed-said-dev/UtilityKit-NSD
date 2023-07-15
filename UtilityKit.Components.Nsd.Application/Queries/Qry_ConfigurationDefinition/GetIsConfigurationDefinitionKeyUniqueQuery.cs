using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;

namespace UtilityKit.Components.Nsd.Application.Queries.Qry_ConfigurationDefinition
{
    public class GetIsConfigurationDefinitionKeyUniqueQuery : IRequest<Boolean>
    {
        public Guid WidgetId { get; set; }
        public String OldKey { get; set; }
        public String Key { get; set; }
        public class Handler : IRequestHandler<GetIsConfigurationDefinitionKeyUniqueQuery, Boolean>
        {
            private readonly IWidgetRepository _widgetsRepository;

            public Handler(IWidgetRepository widgetsRepository)
            {
                _widgetsRepository = widgetsRepository;
            }
            public async Task<Boolean> Handle(GetIsConfigurationDefinitionKeyUniqueQuery request, CancellationToken cancellationToken)
            {
                var isUnique = await _widgetsRepository.IsConfigurationDefinitionKeyUnique(request.Key, request.WidgetId, request.OldKey, cancellationToken);
                return !isUnique;
            }
        }
    }
}
