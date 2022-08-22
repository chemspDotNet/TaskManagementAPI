using System.Linq;
using System.Web.Http;
using System.Security.Claims;
using System.Net.Http;
using System.Net;
using TaskManagementAPI.AuthProvider;

namespace TaskManagementAPI.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route("api/Account/Register")]
        public IHttpActionResult Register([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usermanger = new UserManager();
                    usermanger.CreateUser(user);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }

            } else
            {
                return BadRequest(ModelState);
            }

        }
    }
}
