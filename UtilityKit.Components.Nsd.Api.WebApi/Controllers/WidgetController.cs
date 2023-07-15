using Microsoft.AspNetCore.Mvc;
using UtilityKit.Components.Nsd.Application.Commands.Cmd_Widget;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.Requests;
using UtilityKit.Components.Nsd.Application.Queries.Qry_Widget;

namespace UtilityKit.Components.Nsd.Api.WebApi.Controllers.Widget
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : BaseController
    {
        [HttpGet()]
        public async Task<IActionResult> GetAllWidgets(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new Get_All_Widget_Query(), cancellationToken));

        [HttpGet("Id")]
        public async Task<IActionResult> GetWidgetById(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
                    return BadRequest("No Guid is Enter");
                return Ok(await Mediator.Send(new GetWidgetDetailesbyIDQuery() { WidgetID = id }, cancellationToken));
        }

        [HttpPost()]
        public async Task<IActionResult> Add(AddWidegtRequest NewWidget,CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new Add_Widget_Command(){AddWidegtRequest = NewWidget}, cancellationToken));
    }
}
