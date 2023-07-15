using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.Requests;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;
using UtilityKit.Components.Nsd.Domain.Exceptions.Broker;

namespace UtilityKit.Components.Nsd.Application.Commands.Cmd_ConfigurationDefinition
{
    public class AddConfigurationDefinitionCommand : IRequest<ConfigurationDefinition_Response>
    {
        public Guid WidgetId { get; set; }
        public ConfigurationDefinition_Add_Request AddConfigurationDefinitionModel { get; set; }
        public class Handler : IRequestHandler<AddConfigurationDefinitionCommand, ConfigurationDefinition_Response>
        {
            #region --- Variables
            private readonly IWidgetRepository _widgetRepository;
            private readonly IUnitOfWork _unitOfWork;
            #endregion

            #region --- Constructor
            public Handler(IWidgetRepository widgetRepository, IUnitOfWork unitOfWork)
            {
                _widgetRepository = widgetRepository;
                _unitOfWork = unitOfWork;
            }
            #endregion

            #region --- Methods
            public async Task<ConfigurationDefinition_Response> Handle(AddConfigurationDefinitionCommand request, CancellationToken cancellationToken)
            {
                var widget = await _widgetRepository.GetByID(request.WidgetId, cancellationToken);
                if(widget is null)
                    throw new WidgetNotFoundException();
                widget.ConfigurationDefinitions = request.AddConfigurationDefinitionModel.MapToDomain();

                _widgetRepository.UpdateWidget(widget, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new ConfigurationDefinition_Response().MapToResponse(request.AddConfigurationDefinitionModel.ConfigurationDefinitions);
            }
            #endregion

/*            #region --- Vallidation
            public class Validator : AbstractValidator<AddConfigurationDefinitionCommand>
            {
                public Validator()
                {
                    RuleFor(x => x.AddConfigurationDefinitionModel.ConfigurationDefinitions.).NotEmpty().WithMessage(DashboardErrors.EMPTY_NAME);
                    RuleFor(x => x.AddConfigurationDefinitionModel.LayoutId).NotEmpty().WithMessage(DashboardErrors.EMPTY_LAYOUT_ID);
                    RuleFor(x => x.AddConfigurationDefinitionModel.Name).Length(0, 100).WithMessage(DashboardErrors.NAME_MAX_LENGHT);
                    RuleFor(x => x.AddConfigurationDefinitionModel.Description).Length(0, 500).WithMessage(DashboardErrors.DESCRIPTION_MAX_LENGHT);
                    RuleFor(x => x.AddConfigurationDefinitionModel.Tags).Length(0, 500).WithMessage(DashboardErrors.TAGS_MAX_LENGHT);

                }
            }
            #endregion*/
        }
    }
}
