using Microsoft.AspNetCore.Mvc;

namespace FluentValidations.API.Requests
{
    public class RequestToValidate
    {
        [FromHeader(Name = ApiConstants.HeaderName)]
        public string PropertyFromHeader { get; set; }

        [FromQuery(Name = ApiConstants.QueryPropertyName)]
        public int? PropertyFromQuery { get; set; }

        [FromBody]
        public RequestBody Body { get; set; }

        public class RequestBody
        {
            public int PastDate { get; set; }
            public int FutureDate { get; set; }
        }
    }
}