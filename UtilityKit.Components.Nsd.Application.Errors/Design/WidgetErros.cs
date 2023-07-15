using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Nsd.Application.Errors.Design
{
    public class WidgetErros
    {
        public const string Widget_ID = "Widget ID is not exist or incorrect format";
        public const string EMPTY_Name = "Name is Empty You Must Enter Name ";
        public const string Length_Name = "Name character allowed is 100 character ";
        public const string Length_Description = "Description character allowed is 500 character ";
        public const string EMPTY_Industries = "Select at least one industry";
        public const string EMPTY_MinCellSize = "MinCellSize is Requierd";
        public const string EMPTY_Thumbnail = "Thumbnail is Requierd";
        public const string EMPTY_WidgetFileSource = "WidgetFileSource is Requierd";
    }
}
