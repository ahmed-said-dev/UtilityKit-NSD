using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Domain.Exceptions.Broker;

namespace UtilityKit.Components.Nsd.Application.Queries.NewFolder
{
    public class GetConfigurationDefinitionQuery : IRequest<ConfigurationDefinition_Response>
    {
        public Guid WidgetId { get; set; }
        public class Handler : IRequestHandler<GetConfigurationDefinitionQuery, ConfigurationDefinition_Response>
        {
            private readonly IWidgetRepository _widgetRepository;

            public Handler(IWidgetRepository widgetRepository)
            {
                _widgetRepository = widgetRepository;
            }

            public async Task<ConfigurationDefinition_Response> Handle(GetConfigurationDefinitionQuery request, CancellationToken cancellationToken)
            {
                var widget = await _widgetRepository.GetByID(request.WidgetId, cancellationToken);
                if (widget is null)
                    throw new WidgetNotFoundException();

                return new ConfigurationDefinition_Response().MapToResponse(widget.ConfigurationDefinitions);
            }
        }

    }
}
