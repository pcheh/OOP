using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    internal class HtmlReportMaker : IReportMaker
    {
        public string MakeCaption(string caption)
        {
            return $"<h1>{caption}</h1>";
        }

        public string BeginList()
        {
            return "<ul>";
        }

        public string EndList()
        {
            return "</ul>";
        }

        public string MakeItem(string valueType, string entry)
        {
            return $"<li><b>{valueType}</b>: {entry}";
        }
    }
}
