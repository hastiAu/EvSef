using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.ViewModels.CorporationFood
{
    public class CorporationFoodViewModel
    {
        public int CorporationId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CorporationOrderFromDate { get; set; }
        public DateTime CorporationOrderToDate { get; set; }
    }
}
 
