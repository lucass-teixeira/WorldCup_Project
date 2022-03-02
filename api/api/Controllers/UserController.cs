using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUnityOfWork _uof;
        public UserController(IUnityOfWork contexto)
        {
            _uof = contexto;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _uof.GameRepository.Get();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
