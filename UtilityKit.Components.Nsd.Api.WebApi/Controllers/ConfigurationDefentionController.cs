using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UtilityKit.Components.Nsd.Application.Commands.Cmd_ConfigurationDefinition;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.Requests;
using UtilityKit.Components.Nsd.Application.Queries.NewFolder;
using UtilityKit.Components.Nsd.Application.Queries.Qry_ConfigurationDefinition;

namespace UtilityKit.Components.Nsd.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationDefinitionController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([Required] Guid widgetId,[FromBody] ConfigurationDefinition_Add_Request configurationDefinition, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new AddConfigurationDefinitionCommand() { WidgetId = widgetId, AddConfigurationDefinitionModel = configurationDefinition }, cancellationToken));
        [HttpGet()]
        public async Task<IActionResult> GetConfigurationDefinitions([Required] Guid widgetId, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetConfigurationDefinitionQuery() { WidgetId = widgetId }, cancellationToken));
        [HttpGet("key/")]
        public async Task<IActionResult> IsConfigurationDefinitionKeyUnique([Required] String key, [Required] Guid widgetId, String? oldKey, CancellationToken cancellationToken)
           => Ok(await Mediator.Send(new GetIsConfigurationDefinitionKeyUniqueQuery() { Key = key, WidgetId = widgetId, OldKey = oldKey }, cancellationToken));
    }
}
