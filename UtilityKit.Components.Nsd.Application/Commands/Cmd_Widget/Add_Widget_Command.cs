using FluentValidation;
using MediatR;
using AutoMapper;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.DTO;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.Requests;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Application.Errors.Design;
using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;
using UtilityKit.Components.Und.Domain.Exceptions.Broker;

namespace UtilityKit.Components.Nsd.Application.Commands.Cmd_Widget
{
    public class Add_Widget_Command : IRequest<AddWidgetRespones>
    {
        public AddWidegtRequest  AddWidegtRequest { get; set; }
        public class Handler : IRequestHandler<Add_Widget_Command, AddWidgetRespones>
        {
            #region --- Variables
            private readonly IWidgetRepository _widgetRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            #endregion

            #region --- Constructor
            public Handler(IWidgetRepository dashboardRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _widgetRepository = dashboardRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            #endregion


            #region --- Methods
            public async Task<AddWidgetRespones> Handle(Add_Widget_Command request, CancellationToken cancellationToken)
            {
                string[] Thumbnail_Extention = {".png",".jpg", ".jpeg"};

                AddWidgetRespones addWidgetRespones = new AddWidgetRespones();

                if (await _widgetRepository.IsNameExtisting(request.AddWidegtRequest.WidgetDto.Name, cancellationToken))
                    throw new Widget_Name_Exist_Exception();

                if (Path.GetExtension(request.AddWidegtRequest.WidgetDto.WidgetFileSource)?.ToLower() != ".zip")
                    throw new Widget_Files_Format_Exception();

                if(!Thumbnail_Extention.Contains(Path.GetExtension(request.AddWidegtRequest.WidgetDto.Thumbnail).ToLower()))
                    throw new Widget_Thumbnail_Extention_Exception();

                Widget widget = _mapper.Map<WidgetDto, Widget>(request.AddWidegtRequest.WidgetDto);
                Widget widgetAdded = await _widgetRepository.Add(widget,cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                addWidgetRespones.WidgetDto = _mapper.Map<Widget, WidgetDto>(widgetAdded);
                return addWidgetRespones;
            }
            #endregion
            
            #region --- Vallidation
            public class Validator : AbstractValidator<Add_Widget_Command>
            {
                public Validator()
                {
                    RuleFor(x => x.AddWidegtRequest.WidgetDto.Name)
                        .NotEmpty()
                        .WithMessage(WidgetErros.EMPTY_Name)
                        .MaximumLength(100)
                        .WithMessage(WidgetErros.Length_Name);

                    RuleFor(x => x.AddWidegtRequest.WidgetDto.Description)
                        .MaximumLength(500)
                        .WithMessage(WidgetErros.Length_Description);

                    RuleFor(x => x.AddWidegtRequest.WidgetDto.Industries)
                        .NotEmpty().WithMessage(WidgetErros.EMPTY_Industries);

                    RuleFor(x => x.AddWidegtRequest.WidgetDto.MinCellSize)
                        .NotEmpty().WithMessage(WidgetErros.EMPTY_MinCellSize);

                    RuleFor(x => x.AddWidegtRequest.WidgetDto.Thumbnail)
                        .NotEmpty().WithMessage(WidgetErros.EMPTY_Thumbnail);

                    RuleFor(x => x.AddWidegtRequest.WidgetDto.WidgetFileSource)
                        .NotEmpty().WithMessage(WidgetErros.EMPTY_WidgetFileSource);

                }
               

            }
            #endregion
        }
    }
}
