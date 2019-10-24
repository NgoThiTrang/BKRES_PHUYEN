using DoAn.Data.Model;
using System.Collections.Generic;

namespace DoAn.ViewModel
{
    public class ChartDataViewModel
    {
        public List<WarningProfile> chcbs { get; set; }

        public List<DataPackage> data { get; set; }

        public string LakeName { get; set; }

        public string ClientName { get; set; }

        public string Imei { get; set; }
    }
}