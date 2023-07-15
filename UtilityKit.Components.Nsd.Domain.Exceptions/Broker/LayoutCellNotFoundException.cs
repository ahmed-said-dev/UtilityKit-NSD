using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Nsd.Domain.Exceptions.Broker
{
    public class LayoutCellNotFoundException : BusinessException
    {
        public LayoutCellNotFoundException() :
      base(
      7,
      "LayoutCell not found.",
      "",
      HttpStatusCode.BadRequest)
        { }
    }
}
