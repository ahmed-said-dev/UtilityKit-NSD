using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UtilityKit.Components.Nsd.Application.Commands.Cmd_Dashboard;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.Requests;
using UtilityKit.Components.Nsd.Application.Queries.Qry_Dashboard;

namespace UtilityKit.Components.Nsd.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Dashboard_Add_Request dashboard, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new AddDashboardCommand() { AddDashboardModel = dashboard }, cancellationToken));
        [HttpGet("Dashboard")]
        public async Task<IActionResult> GetDashboard([Required] Guid Id, CancellationToken cancellationToken)
         => Ok(await Mediator.Send(new GetDashboardQuery() { Id = Id }, cancellationToken));
        [HttpGet("layout")]
        public async Task<IActionResult> GetLayoutsForDashboard(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetLayoutsForDashboardQuery(), cancellationToken));
        [HttpGet("dataSource")]
        public async Task<IActionResult> GetDataSourcesForDashboard(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetDataSourcesForDashboardQuery(), cancellationToken));
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetDashboardsQuery(), cancellationToken));
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] Dashboard_Update_Request model, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new UpdateDashboardCommand() { UpdateDashboardModel = model }, cancellationToken));
        [HttpDelete]
        public async Task<IActionResult> Delete([Required] Guid Id, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new DeleteDashboardCommand() { Id = Id }, cancellationToken));
    }
}
