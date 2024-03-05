using BarberHouse.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberHouse.Controllers
{
    [Route("api/visits")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitRepository _visitRepository;

        public VisitController(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }


    }
}
