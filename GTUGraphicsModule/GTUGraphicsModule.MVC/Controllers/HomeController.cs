using GTUGraphicsModule.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using GTUGraphicsModule.MVC.Communication;
using System.Diagnostics;
using GTUGraphicsModule.Models.Models;
using GTUGraphicsModule.Models.Models.ViewModels;

namespace GTUGraphicsModule.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IServiceCommunication _serviceCommunication;
        public HomeController(ILogger<HomeController> logger, IServiceCommunication serviceCommunication)
        {
            _logger = logger;
            _serviceCommunication = serviceCommunication;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> KonuContentGenel(int id)
        {
            var res = await _serviceCommunication.GetResponseList<PerformansGostergeKonuVM>($"api/Kalite_PerformansGostergeVeriKategorisiIliski/GetKonuVeri/{id}");

            return PartialView(res);

        }

        public async Task<IActionResult> KonuContent(int id)
        {
            var res = await _serviceCommunication.GetResponseList<PerformansGostergeKonuVM>($"api/Kalite_PerformansGostergeVeriKategorisiIliski/GetKonuVeri/{id}");

            return PartialView(res);

        }

        public async Task<IActionResult> KonuContentDetayli(int id)
        {
            var res = await _serviceCommunication.GetResponseList<PerformansGostergeKonuVM>($"api/Kalite_PerformansGostergeVeriKategorisiIliski/GetKonuVeri/{id}");

            return PartialView(res);

        }

        public async Task<IActionResult> BirimContent(int id)
        {
            var res = await _serviceCommunication.GetResponseList<PerformansGostergeBirimVM>($"api/Kalite_PerformansGostergeVeriKategorisiIliski/GetBirimVeri/{id}");

            return PartialView(res);

        }

        public async Task<IActionResult> BirimContentDetayli(int id)
        {
            var res = await _serviceCommunication.GetResponseList<PerformansGostergeBirimVM>($"api/Kalite_PerformansGostergeVeriKategorisiIliski/GetBirimVeri/{id}");

            return PartialView(res);

        }

        public async Task<IActionResult> BirimContentGenel(int id)
        {
            var res = await _serviceCommunication.GetResponseList<PerformansGostergeBirimVM>($"api/Kalite_PerformansGostergeVeriKategorisiIliski/GetBirimVeri/{id}");

            return PartialView(res);

        }

        public async Task<IActionResult> StratejikPlanDetayli()
        {
            
            var StratejikPlanPerformasiVeriler = await _serviceCommunication.GetResponseList<PerformansGostergeVeriKategorisiVM>("api/Kalite_PerformansGostergeVeriKategorisiIliski/GetPerformansVeri");
            //var res = await _serviceCommunication.GetResponseList<PerformansGostergeBirimVM>($"api/Kalite_PerformansGostergeVeriKategorisiIliski/GetBirimVeri/{birimId}");

            var Birimler = await _serviceCommunication.GetResponseList<Kalite_Birim>("api/Kalite_Birim/GetAll");

            var Konular = await _serviceCommunication.GetResponseList<Kalite_Konu>("api/Kalite_Konu/GetAll");

            PerformansGostergeVeriKategorisiBirimVM performansGostergeVeriKategorisiBirimVM = new PerformansGostergeVeriKategorisiBirimVM();

            performansGostergeVeriKategorisiBirimVM.PerformansGostergeVeriKategorisiVMList = StratejikPlanPerformasiVeriler;

            performansGostergeVeriKategorisiBirimVM.Birimler = Birimler;

            performansGostergeVeriKategorisiBirimVM.Konular = Konular;

            return View(performansGostergeVeriKategorisiBirimVM);

        }

        public async Task<IActionResult> StratejikPlanPerformansi()
        {

            var StratejikPlanPerformasiVeriler = await _serviceCommunication.GetResponseList<PerformansGostergeVeriKategorisiVM>("api/Kalite_PerformansGostergeVeriKategorisiIliski/GetPerformansVeri");

            var Birimler = await _serviceCommunication.GetResponseList<Kalite_Birim>("api/Kalite_Birim/GetAll");

            var Konular = await _serviceCommunication.GetResponseList<Kalite_Konu>("api/Kalite_Konu/GetAll");

            PerformansGostergeVeriKategorisiBirimVM performansGostergeVeriKategorisiBirimVM = new PerformansGostergeVeriKategorisiBirimVM();

            performansGostergeVeriKategorisiBirimVM.PerformansGostergeVeriKategorisiVMList = StratejikPlanPerformasiVeriler;

            performansGostergeVeriKategorisiBirimVM.Birimler = Birimler;

            performansGostergeVeriKategorisiBirimVM.Konular = Konular;

            return View(performansGostergeVeriKategorisiBirimVM);
        }

        public async Task<IActionResult> StratejikPlanGenel()
        {

            var StratejikPlanPerformasiVeriler = await _serviceCommunication.GetResponseList<PerformansGostergeVeriKategorisiVM>("api/Kalite_PerformansGostergeVeriKategorisiIliski/GetPerformansVeri");

            var Birimler = await _serviceCommunication.GetResponseList<Kalite_Birim>("api/Kalite_Birim/GetAll");

            var Konular = await _serviceCommunication.GetResponseList<Kalite_Konu>("api/Kalite_Konu/GetAll");

            PerformansGostergeVeriKategorisiBirimVM performansGostergeVeriKategorisiBirimVM = new PerformansGostergeVeriKategorisiBirimVM();

            performansGostergeVeriKategorisiBirimVM.PerformansGostergeVeriKategorisiVMList = StratejikPlanPerformasiVeriler;

            performansGostergeVeriKategorisiBirimVM.Birimler = Birimler;

            performansGostergeVeriKategorisiBirimVM.Konular = Konular;

            return View(performansGostergeVeriKategorisiBirimVM);

        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}