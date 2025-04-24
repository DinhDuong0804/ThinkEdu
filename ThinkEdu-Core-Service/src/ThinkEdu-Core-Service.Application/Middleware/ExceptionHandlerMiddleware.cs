using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using ThinkEdu_Core_Service.Application.Exceptions;
using ThinkEdu_Core_Service.Domain.Common;
using ThinkEdu_Core_Service.Domain.Enums;

namespace ThinkEdu_Core_Service.Application.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            int httpStatusCode;
            var result = exception.Message;
            var response = new BaseResponse<string>
            {
                Success = false
            };

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    response.ResultCode = EResultCode.BADREQUEST;
                    response.Message = exception.Message;
                    response.ValidationErrors = validationException.ValidationErrors;
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    response.ResultCode = EResultCode.BADREQUEST;
                    response.Message = badRequestException.Message;
                    break;
                case NotFoundException _:
                    httpStatusCode = (int)HttpStatusCode.NotFound;
                    response.ResultCode = EResultCode.NOTFOUND;
                    response.Message = exception.Message;
                    break;
                case ApiException apiException:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    response.ResultCode = EResultCode.INTERNALSERVERERROR;
                    response.Message = apiException.Message;
                    break;
                default:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    response.ResultCode = EResultCode.INTERNALSERVERERROR;
                    response.Message = exception.Message;
                    break;
            }


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = httpStatusCode;

            if (result == string.Empty)
            {
                response.Message = exception.Message;
            }

            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                    Formatting = Formatting.None
                };

                return settings;
            };
            result = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(result);
        }
    }

}
