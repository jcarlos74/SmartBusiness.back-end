using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBusiness.Infra.DataGrid.PrimeNG.Table.Models
{
    public class FilterContext
    {
        public object Value { get; set; }
        public string MatchMode { get; set; }
        public string Operator { get; set; }
    }
}
