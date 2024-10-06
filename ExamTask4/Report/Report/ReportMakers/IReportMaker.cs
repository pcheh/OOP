using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    public interface IReportMaker
    {
        string MakeCaption(string caption);
        string BeginList();
        string MakeItem(string valueType, string entry);
        string EndList();
    }
}
