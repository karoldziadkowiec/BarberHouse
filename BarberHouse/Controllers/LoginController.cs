using BarberHouse.Models;
using BarberHouse.Models.DTOs;
using BarberHouse.Repositories.Classes;
using BarberHouse.Repositories.Interfaces;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberHouse.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        /*[HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            
        }*/
    }
}
