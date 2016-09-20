using RepositoryLogic.Entities;
using System.Web.Http;
using RepositoryLogic.LogicImplementation;

namespace ReusableWebAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : BaseController<User>
    {
        public UserController(IUserLogic logic) : base(logic)
        {
        }
    }
}