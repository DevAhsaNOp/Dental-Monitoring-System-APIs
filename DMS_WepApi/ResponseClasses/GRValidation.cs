using DMS_BOL;
using System;
using System.Text.Json.Nodes;
using System.Data.Entity;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DMS_WepApi.ResponseClasses
{
    public class GRValidation
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    public class GRIValidation
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public object Datalist { get; set; }
    }
    
    public class GRMValidation
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Errorslist { get; set; }
    }

    public class ErrorResponse
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }

    public class LoginResponseValidation
    {
        public int StatusCode { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        public bool Success { get; set; }
        public int UserID { get; set; }
        public string UserImage { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; internal set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; internal set; }
        [JsonProperty("token_type")]
        public string TokenType { get; internal set; }
        [JsonProperty(".issued")]
        public string IssuedTime { get; set; }
        [JsonProperty(".expires")]
        public string ExpiredTime { get; set; }
    }
}