using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Nsd.Application.Errors.Design
{
    public class DashboardErrors
    {
        public const string EMPTY_ID = "Dashboard Id is empty or does not exist";
        public const string EMPTY_LAYOUT_ID = "Layout may not exist";
        public const string EMPTY_NAME = "Dashoarrd name is empty";
        public const string NAME_MAX_LENGHT = "Dashboard name max length is 100 char";
        public const string DESCRIPTION_MAX_LENGHT = "Dashboard description max lenght is 500 char";
        public const string TAGS_MAX_LENGHT = "Dashboard tags max lenght is 500 char";
    }
}
