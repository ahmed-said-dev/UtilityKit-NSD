using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UtilityKit.Components.Nsd.Application.Commands.Cmd_LayoutCell;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_LayoutCell.Requests;

namespace UtilityKit.Components.Nsd.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutCellController : BaseController
    {
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] LayoutCell_Update_Request model, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new UpdateLayoutCellCommand() { UpdateLayoutCellModel = model }, cancellationToken));
    }
}
