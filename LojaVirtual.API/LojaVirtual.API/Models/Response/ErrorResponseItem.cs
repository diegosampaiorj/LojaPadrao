using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtual.API.Models.Response
{
    public class ErrorResponseItem
    {
        public string Message { get; set; }

        public string Property { get; set; }
    }
}