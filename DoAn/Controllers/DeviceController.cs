using DoAn.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    [Authorize] // như này là authorize bằng cook thế thì trong phầm home.js e vẫn gọi đừng nlink như vậy nó vẫn bt ấy hả 
    // gọi đến controller này  c/device
    public class DeviceController : Controller
    {
        private IDistrictService _districtService;

        public DeviceController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        // GET: Device
        public ActionResult Index()
        {
            var data = _districtService.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet); // đấy kiểu như này
        }
    }
}