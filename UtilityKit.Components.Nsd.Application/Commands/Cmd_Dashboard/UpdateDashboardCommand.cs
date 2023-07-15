using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.Requests;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Application.Errors.Design;
using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using UtilityKit.Components.Und.Domain.Exceptions.Broker;

namespace UtilityKit.Components.Nsd.Application.Commands.Cmd_Dashboard
{
    public class UpdateDashboardCommand : IRequest<Dashboard_Response>
    {
        public Dashboard_Update_Request UpdateDashboardModel { get; set; }
        public class Handler : IRequestHandler<UpdateDashboardCommand, Dashboard_Response>
        {
            #region --- Variables
            private readonly IDashboardRepository _dashboardRepository;
            private readonly IUnitOfWork _unitOfWork;
            #endregion

            #region --- Constructor
            public Handler(IDashboardRepository dashboardRepository, IUnitOfWork unitOfWork)
            {
                _dashboardRepository = dashboardRepository;
                _unitOfWork = unitOfWork;
            }
            #endregion

            #region --- Methods
            public async Task<Dashboard_Response> Handle(UpdateDashboardCommand request, CancellationToken cancellationToken)
            {
                var existingDashboard = await _dashboardRepository.Get(request.UpdateDashboardModel.Id, cancellationToken);
                if (existingDashboard is null)
                    throw new DashboardNotFoundException();

                var dashboardModel = request.UpdateDashboardModel.MapToDomain();
                dashboardModel.CreationDate = existingDashboard.CreationDate;
                _dashboardRepository.UpdateDashboard(dashboardModel, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new Dashboard_Response().MapToResponse(dashboardModel);
            }
            #endregion

            #region --- Vallidation
            public class Validator : AbstractValidator<UpdateDashboardCommand>
            {
                public Validator()
                {
                    RuleFor(x => x.UpdateDashboardModel.Name).NotEmpty().WithMessage(DashboardErrors.EMPTY_NAME);
                    RuleFor(x => x.UpdateDashboardModel.LayoutId).NotEmpty().WithMessage(DashboardErrors.EMPTY_LAYOUT_ID);
                    RuleFor(x => x.UpdateDashboardModel.Name).Length(0, 100).WithMessage(DashboardErrors.NAME_MAX_LENGHT);
                    RuleFor(x => x.UpdateDashboardModel.Description).Length(0, 500).WithMessage(DashboardErrors.DESCRIPTION_MAX_LENGHT);
                    RuleFor(x => x.UpdateDashboardModel.Tags).Length(0, 500).WithMessage(DashboardErrors.TAGS_MAX_LENGHT);
                }
            }
            #endregion
        }
    }
}
