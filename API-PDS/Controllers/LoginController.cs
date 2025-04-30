using API_PDS.Services;
using API_PDS.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_PDS.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("{email}/{password}")]
        public IActionResult ObterLogin(string email, string password)
        {
            LoginViewModel lvm = new LoginViewModel();
            lvm.email = email;
            lvm.Password = password;
            return Ok(_loginService.Login(lvm));
        }
    }
}
