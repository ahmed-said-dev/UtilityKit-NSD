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
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Commands.Cmd_Dashboard
{
    public class AddDashboardCommand : IRequest<Dashboard_Response>
    {
        public Dashboard_Add_Request AddDashboardModel { get; set; }
        public class Handler : IRequestHandler<AddDashboardCommand, Dashboard_Response>
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
            public async Task<Dashboard_Response> Handle(AddDashboardCommand request, CancellationToken cancellationToken)
            {
                Dashboard dashboard = await _dashboardRepository.AddDashboard(request.AddDashboardModel?.MapToDomain(), cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new Dashboard_Response().MapToResponse(dashboard);
            }
            #endregion

            #region --- Vallidation
            public class Validator : AbstractValidator<AddDashboardCommand>
            {
                public Validator()
                {
                    RuleFor(x => x.AddDashboardModel.Name).NotEmpty().WithMessage(DashboardErrors.EMPTY_NAME);
                    RuleFor(x => x.AddDashboardModel.LayoutId).NotEmpty().WithMessage(DashboardErrors.EMPTY_LAYOUT_ID);
                    RuleFor(x => x.AddDashboardModel.Name).Length(0, 100).WithMessage(DashboardErrors.NAME_MAX_LENGHT);
                    RuleFor(x => x.AddDashboardModel.Description).Length(0, 500).WithMessage(DashboardErrors.DESCRIPTION_MAX_LENGHT);
                    RuleFor(x => x.AddDashboardModel.Tags).Length(0, 500).WithMessage(DashboardErrors.TAGS_MAX_LENGHT);

                }
            }
            #endregion
        }
    }
}
