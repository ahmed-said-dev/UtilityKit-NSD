using AutoMapper;
using ChartsProject.Models;
using MediatR;
using Newtonsoft.Json;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.DTO;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Queries.Qry_Widget
{
    public class GetTransformedChartDataQuery : IRequest<List<TransformedDataDto>>
    {
        public class Handler : IRequestHandler<GetTransformedChartDataQuery, List<TransformedDataDto>>
        {
            private readonly IChartRepository _chartRepository;
            private readonly IMapper _Mapper;

            public Handler(IWidgetRepository WidgetRepository, IMapper mapper, IChartRepository chartRepository)
            {
                _Mapper = mapper;
                _chartRepository = chartRepository;
            }

            public async Task<List<TransformedDataDto>> Handle(GetTransformedChartDataQuery request, CancellationToken cancellationToken)
            {

                var getChartData = await _chartRepository.GetChartData();

                List<TransformedDataDto> desiredFormatList = getChartData
                    .GroupBy(a => a.AssetGroup)
                    .Select(g => new TransformedDataDto
                    {
                        arg = $"{g.Key} KV",
                        val = g.Key * 1000,
                        AssetType = "",
                        CityId = "",
                        GovId = "",
                        DomainName = "",
                        AssetTableName = "",
                        AssetGroup = g.Key,
                        IsBasic = 0,
                        TotalLength = 0,

                    })
                    .ToList();

                //string desiredFormatJson = JsonConvert.SerializeObject(desiredFormatList, Newtonsoft.Json.Formatting.Indented);
                //return Content(desiredFormatJson, "application/json");
                return desiredFormatList;

            }
        }

    }
}
