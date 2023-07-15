using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using UtilityKit.Components.Und.Domain.Exceptions.Broker;

namespace UtilityKit.Components.Nsd.Application.Commands.Cmd_Dashboard
{
    public class DeleteDashboardCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public class Handler : IRequestHandler<DeleteDashboardCommand, bool>
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
            public async Task<bool> Handle(DeleteDashboardCommand request, CancellationToken cancellationToken)
            {
                var existingDashboard = await _dashboardRepository.Get(request.Id, cancellationToken);
                if (existingDashboard is null)
                    throw new DashboardNotFoundException();

                var isDeleted = await _dashboardRepository.Delete(request.Id, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return isDeleted;
            }
            #endregion
        }
    }
}
