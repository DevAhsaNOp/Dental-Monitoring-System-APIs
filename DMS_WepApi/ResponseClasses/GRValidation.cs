using DMS_BOL;
using System;
using System.Text.Json.Nodes;
using System.Data.Entity;
using System.Runtime.Serialization;

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
}