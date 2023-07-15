using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UtilityKit.Components.Nsd.Application.Commands.Cmd_Dashboard;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.Requests;
using UtilityKit.Components.Nsd.Application.Queries.Qry_Dashboard;
using UtilityKit.Components.Nsd.Application.Queries.Qry_Widget;

namespace UtilityKit.Components.Nsd.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : BaseController
    {
        [HttpGet("transformedData")]
        public async Task<IActionResult> GetAllTransformedData(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetTransformedChartDataQuery(), cancellationToken));
        [HttpGet("alldata")]
        public async Task<IActionResult> GetAllChartData(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetAllChartDataQuery(), cancellationToken));

    }
}
