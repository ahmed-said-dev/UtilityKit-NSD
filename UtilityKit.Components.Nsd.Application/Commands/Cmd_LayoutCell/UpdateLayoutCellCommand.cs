using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_LayoutCell.Requests;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_LayoutCell.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using UtilityKit.Components.Nsd.Domain.Exceptions.Broker;

namespace UtilityKit.Components.Nsd.Application.Commands.Cmd_LayoutCell
{

    public class UpdateLayoutCellCommand : IRequest<LayoutCell_Response>
    {
        public LayoutCell_Update_Request UpdateLayoutCellModel { get; set; }
        public class Handler : IRequestHandler<UpdateLayoutCellCommand, LayoutCell_Response>
        {
            #region --- Variables
            private readonly ILayoutCellRepository _layoutCellRepository;
            private readonly IUnitOfWork _unitOfWork;
            #endregion

            #region --- Constructor
            public Handler(ILayoutCellRepository layoutCellRepository, IUnitOfWork unitOfWork)
            {
                _layoutCellRepository = layoutCellRepository;
                _unitOfWork = unitOfWork;
            }
            #endregion

            #region --- Methods
            public async Task<LayoutCell_Response> Handle(UpdateLayoutCellCommand request, CancellationToken cancellationToken)
            {
    /*            var existingLayoutCell = await _layoutCellRepository.Get(request.UpdateLayoutCellModel.Id, cancellationToken);
                if (existingLayoutCell is null)
                    throw new LayoutCellNotFoundException();*/

                var LayoutCellModel = request.UpdateLayoutCellModel.MapToDomain();
                _layoutCellRepository.Update(LayoutCellModel, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return new LayoutCell_Response().MapToResponse(LayoutCellModel);
            }
            #endregion

            #region --- Vallidation
            public class Validator : AbstractValidator<UpdateLayoutCellCommand>
            {
                public Validator()
                {
   /*                 RuleFor(x => x.UpdateDashboardModel.Name).NotEmpty().WithMessage(DashboardErrors.EMPTY_NAME);
                    RuleFor(x => x.UpdateDashboardModel.LayoutId).NotEmpty().WithMessage(DashboardErrors.EMPTY_LAYOUT_ID);
                    RuleFor(x => x.UpdateDashboardModel.Name).Length(0, 100).WithMessage(DashboardErrors.NAME_MAX_LENGHT);
                    RuleFor(x => x.UpdateDashboardModel.Description).Length(0, 500).WithMessage(DashboardErrors.DESCRIPTION_MAX_LENGHT);
                    RuleFor(x => x.UpdateDashboardModel.Tags).Length(0, 500).WithMessage(DashboardErrors.TAGS_MAX_LENGHT);*/
                }
            }
            #endregion
        }
    }
}