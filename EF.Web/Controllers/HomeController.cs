using System.Web.Mvc;
using EF.Core.Data;
using EF.Data;

namespace EF.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _uow = new UnitOfWork();
        private readonly Repository<Machine> _machineRepo;
        private readonly CustomRepository _customRepo; 

        public HomeController()
        {
            _machineRepo = _uow.Repository<Machine>();
            _customRepo = _uow.CustomRepository();
        }
        public ActionResult Index()
        {
            var model1 = _machineRepo.GetById("SIMU_001");
            var model2 = _customRepo.GetMachineByMachineNo("SIMU_002");
            return View(model2);
        }
    }
}