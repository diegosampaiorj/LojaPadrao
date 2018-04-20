using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtual.API.Models.Response
{
    public class ErrorsResponse
    {
        public List<ErrorResponseItem> Errors { get; set; }

        public ErrorsResponse()
        {
            this.Errors = new List<ErrorResponseItem>();
        }
    }
}