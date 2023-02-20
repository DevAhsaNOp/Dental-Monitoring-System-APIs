using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DMS_BLL.Repositories;
using DMS_WepApi.ResponseClasses;
using DMS_BOL.Validation_Classes;

namespace DMS_WepApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private UsersRepo UserRepoObj;

        public UsersController()
        {
            UserRepoObj = new UsersRepo();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Register/Patient")]
        public HttpResponseMessage RegisterPatient([FromBody] ValidatePatient user)
        {
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    var reas = UserRepoObj.InsertPatient(user);
                    if (reas)
                        return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                        {
                            StatusCode = 200,
                            Success = true,
                            Message = "Your account has been registered successfully!"
                        });
                    else
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                        { StatusCode = 500, Success = false, Message = "Error occured on creating Account. Please try again later!" });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, new GRValidation()
                    { StatusCode = 406, Success = false, Message = "Invalid provided data!" });
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
