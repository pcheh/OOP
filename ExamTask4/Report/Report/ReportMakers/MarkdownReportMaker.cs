using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    internal class MarkdownReportMaker : IReportMaker
    {
        public string BeginList()
        {
            return "";
        }

        public string EndList()
        {
            return "";
        }

        public string MakeCaption(string caption)
        {
            return $"## {caption}\n\n";
        }

        public string MakeItem(string valueType, string entry)
        {
            return $" * **{valueType}**: {entry}\n\n";
        }
    }
}
