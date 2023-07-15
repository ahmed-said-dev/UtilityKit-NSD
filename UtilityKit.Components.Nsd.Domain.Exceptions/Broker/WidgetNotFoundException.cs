using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Nsd.Domain.Exceptions.Broker
{
    public class WidgetNotFoundException : BusinessException
    {
        public WidgetNotFoundException() :
      base(
      2,
      "Widget not found.",
      "",
      HttpStatusCode.BadRequest)
        { }
    }
}
