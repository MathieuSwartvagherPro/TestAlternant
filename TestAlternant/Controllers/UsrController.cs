using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S_InterModels.IRepository;

namespace TestAlternant.Controllers
{
    public class UsrController : Controller
    {
        private readonly IUsr _Usr;

        public UsrController(IUsr usr)
        {
            _Usr = usr;
        }

        [HttpPost]
        [Route("")]
        public async Task<string> getListUsersAsync()
        {
            return JsonConvert.SerializeObject(listUsers, Formatting.Indented);
        }
    }
}