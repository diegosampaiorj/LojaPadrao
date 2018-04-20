using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace LojaVirtual.API.Models.Response
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            this.IsSuccess = true;
            this.ErrorBody = new ErrorsResponse();
        }

        public bool IsSuccess { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public T SuccessBody { get; set; }

        public ErrorsResponse ErrorBody { get; set; }

        public void AddError(ErrorResponseItem error)
        {
            if (this.ErrorBody == null)
            {
                this.ErrorBody = new ErrorsResponse();
            }

            this.IsSuccess = false;
            this.ErrorBody.Errors.Add(error);
        }
    }
}