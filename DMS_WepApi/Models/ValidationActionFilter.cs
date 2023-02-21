using DMS_WepApi.ResponseClasses;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Collections.Generic;

namespace DMS_WepApi.Models
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;

            if (!modelState.IsValid)
            {
                var errorsList = new List<ErrorResponse>();
                foreach (var state in modelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errorsList.Add(new ErrorResponse()
                        {
                            Field = state.Key,
                            Message = error.ErrorMessage
                        });
                    }
                }

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRMValidation()
                {
                    StatusCode = 412,
                    Message = "Invalid data provided!",
                    Errorslist = errorsList,
                    Success = false
                });
            }
        }
    }
}