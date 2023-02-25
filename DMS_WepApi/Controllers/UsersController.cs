using System;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;
using DMS_WepApi.Models;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;
using DMS_BLL.Repositories;
using DMS_WepApi.ResponseClasses;
using DMS_BOL.Validation_Classes;
using System.Collections.Generic;

namespace DMS_WepApi.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private UsersRepo UserRepoObj;
        string URL = "https://dmswepapi.azurewebsites.net/";

        public UsersController()
        {
            UserRepoObj = new UsersRepo();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidationActionFilter]
        [Route("api/Register/Patient")]
        public HttpResponseMessage RegisterPatient([FromBody] ValidatePatient user)
        {
            if (user != null)
            {
                var reas = UserRepoObj.InsertPatient(user);
                if (reas == 1)
                    return Request.CreateResponse(HttpStatusCode.Created, new GRValidation()
                    {
                        StatusCode = 201,
                        Success = true,
                        Message = "Your account has been registered successfully!",
                    });
                else if (reas == -1)
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new GRValidation()
                    {
                        StatusCode = 403,
                        Success = false,
                        Message = "Invalid OTP provided. Please ensure to enter correct OTP again!",
                    });
                else if (reas == -2)
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new GRValidation()
                    {
                        StatusCode = 404,
                        Success = false,
                        Message = "Email already exists. Please ensure to enter not used email account again!",
                    });
                else if (reas == -3)
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new GRValidation()
                    {
                        StatusCode = 405,
                        Success = false,
                        Message = "Phone Number already exists. Please ensure to enter not used phone number again!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on creating Account. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided!"
                });
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("api/Send/OTP")]
        public HttpResponseMessage SendOTP(string Email)
        {
            if (!string.IsNullOrEmpty(Email) && Email.Length > 5)
            {
                var reas = UserRepoObj.GenerateUserOTP(Email);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.Created, new GRValidation()
                    {
                        StatusCode = 201,
                        Success = true,
                        Message = "OTP has been send at your email successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on sending OTP at your Email Account. Please ensure to input correct Email Account or try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided!"
                });
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/Update/Patient")]
        [Authorize(Roles = "Admin,SuperAdmin,Patient")]
        public HttpResponseMessage UpdatePatient([FromBody] ValidatePatient user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0 && !string.IsNullOrEmpty(user.UserUpdatePhoneNumber) && !string.IsNullOrEmpty(user.UserUpdateEmail))
            {
                var reas = UserRepoObj.UpdatePatient(user);
                if (reas == 1)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Your account details has been updated successfully!",
                    });
                else if (reas == -1)
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new GRValidation()
                    {
                        StatusCode = 404,
                        Success = false,
                        Message = "Email already exists. Please ensure to enter not used email account again!",
                    });
                else if (reas == -2)
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new GRValidation()
                    {
                        StatusCode = 405,
                        Success = false,
                        Message = "Phone Number already exists. Please ensure to enter not used phone number again!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on updating Account. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided. Please provide User ID or Updated By!"
                });
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/InActive/Patient")]
        [Authorize(Roles = "Admin,SuperAdmin,Patient")]
        public HttpResponseMessage InActivePatient([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = UserRepoObj.InActivePatient(user);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Account has been deactivated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on deactivating Account. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided!"
                });
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/ReActive/Patient")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public HttpResponseMessage ReActivePatient([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = UserRepoObj.ReActivePatient(user);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Account has been activated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on activating Account. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided!"
                });
        }

        [HttpGet]
        [ValidationActionFilter]
        [Route("api/Get/Patient")]
        [Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        public HttpResponseMessage GetPatientByID(int PatientID)
        {
            if (PatientID > 0)
            {
                var reas = UserRepoObj.GetUserDetailById(PatientID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Account record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Account details. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided!"
                });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/login")]
        [ValidationActionFilter]
        public HttpResponseMessage Login([FromBody] ValidateUsersLogin user)
        {
            if (user != null)
            {
                var reas = UserRepoObj.CheckLoginDetails(user.UserEmail, user.UserPassword);
                if (reas != null)
                {
                    var keyValues = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("username", user.UserEmail),
                            new KeyValuePair<string, string>("password", user.UserPassword),
                            new KeyValuePair<string, string>("grant_type", "password"),
                        };

                    var request = new HttpRequestMessage(HttpMethod.Post, URL + "token");
                    request.Content = new FormUrlEncodedContent(keyValues);
                    var client = new HttpClient();
                    var response = client.SendAsync(request).Result;
                    string accessToken = null, token_type = null;
                    int accessTokenExpiration;
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync();
                        JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(json.Result);
                        accessToken = jwtDynamic.Value<string>("access_token");
                        token_type = jwtDynamic.Value<string>("token_type");
                        accessTokenExpiration = jwtDynamic.Value<int>("expires_in");
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new LoginResponseValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        AccessToken = accessToken,
                        ExpiresIn = accessTokenExpiration,
                        TokenType = token_type,
                        Username = reas.Name,
                        Email = reas.Email,
                        Role = reas.Role,
                        IssuedTime = DateTime.Now.ToString("ddd, dd MMM yyyy hh:mm:ss tt"),
                        ExpiredTime = DateTime.Now.AddSeconds(accessTokenExpiration).ToString("ddd, dd MMM yyyy hh:mm:ss tt"),
                    });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new GRValidation()
                    { StatusCode = 404, Success = false, Message = "Invalid creds." });
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, new GRValidation()
                { StatusCode = 404, Success = false, Message = "Invalid creds." });
        }
    }
}
