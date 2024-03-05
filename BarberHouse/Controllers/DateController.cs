using BarberHouse.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberHouse.Controllers
{
    [Route("api/dates")]
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly IDateRepository _dateRepository;

        public DateController(IDateRepository dateRepository)
        {
            _dateRepository = dateRepository;
        }


    }
}
