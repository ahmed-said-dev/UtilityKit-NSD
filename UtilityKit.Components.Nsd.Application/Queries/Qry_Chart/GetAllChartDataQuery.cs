using AutoMapper;
using ChartsProject.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Chart.DTO;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.DTO;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Queries.Qry_Widget
{
    public class GetAllChartDataQuery : IRequest<List<ChartDTO>>
    {
        public class Handler : IRequestHandler<GetAllChartDataQuery, List<ChartDTO>>
        {
            private readonly IChartRepository _chartRepository;
            private readonly IMapper _Mapper;


            public Handler(IWidgetRepository WidgetRepository, IMapper mapper, IChartRepository chartRepository)
            {
                _Mapper = mapper;
                _chartRepository = chartRepository;
            }

            public async Task<List<ChartDTO>> Handle(GetAllChartDataQuery request, CancellationToken cancellationToken)
            {

                var allChartData = await _chartRepository.GetChartData();

                return _Mapper.Map<List<ChartDTO>>(allChartData);



                //string desiredFormatJson = JsonConvert.SerializeObject(desiredFormatList, Newtonsoft.Json.Formatting.Indented);
                //return Content(desiredFormatJson, "application/json");


            }



        }
        }

    }

