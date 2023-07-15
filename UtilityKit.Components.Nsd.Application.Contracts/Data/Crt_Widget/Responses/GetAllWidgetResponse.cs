using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.DTO;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.Responses
{
    public class GetAllWidgetResponse
    {   
            public List<WidgetDto> GetWidgetDtos { get; set; }      
    }
}
