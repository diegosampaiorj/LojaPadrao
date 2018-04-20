using LojaVirtual.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace LojaVirtual.API.Controllers
{
    /// <summary>
    /// Base para controladores usarem padrão de respostas de sucesso e erro
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// Gerenciador de logs
        /// </summary>
        // protected IExceptionLogManager LogManager { get; set; }

        #region Responses

        /// <summary>
        /// Método base para criação de respostas HTTP de requisições
        /// </summary>
        /// <typeparam name="T">Tipo da resposta</typeparam>
        /// <param name="response">Resposta HTTP</param>
        /// <returns>Resposta HTTP</returns>
        protected HttpResponseMessage CreateResponse<T>(BaseResponse<T> response)
        {
            // Se obteve sucesso, retorna resposta de sucesso
            if (response.IsSuccess)
            {
                if (response.SuccessBody != null)
                {
                    return Request.CreateResponse<T>(response.StatusCode, response.SuccessBody);
                }
                else
                {
                    return Request.CreateResponse(response.StatusCode);
                }
            }
            else // Senão, retorna mensagem de erro
            {
                return Request.CreateResponse<ErrorsResponse>(response.StatusCode, response.ErrorBody);
            }
        }

        /// <summary>
        /// Esse método transforma os erros no formato do ModelStateDictionary para o formato de ErrorsResponse
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns>Resposta HTTP</returns>
        protected HttpResponseMessage CreateBadRequestResponse(ModelStateDictionary modelState)
        {
            // Lista de erros
            ErrorsResponse errorResponse = new ErrorsResponse();

            // Transforma ICollection em string[] para possibilitar obter o campo com erro
            string[] errorProperties = new string[modelState.Keys.Count];
            modelState.Keys.CopyTo(errorProperties, 0);

            // Cria contador para obter o campo com erro
            int index = 0;

            // Varre as mensagens de erro
            foreach (ModelState modelStateValue in modelState.Values)
            {
                foreach (ModelError modelError in modelStateValue.Errors)
                {
                    ErrorResponseItem errorResponseItem = new ErrorResponseItem();
                    errorResponseItem.Message = modelError.ErrorMessage;
                    errorResponseItem.Property = errorProperties[index];

                    errorResponse.Errors.Add(errorResponseItem);
                }

                index++;
            }

            // Retorna resposta de badrequest
            return Request.CreateResponse<ErrorsResponse>(HttpStatusCode.BadRequest, errorResponse);
        }

        /// <summary>
        /// Cria mensagem de resposta http de acordo com alguma exceção
        /// </summary>
        /// <param name="ex">Exceção</param>
        /// <returns>Resposta HTTP</returns>
        protected HttpResponseMessage CreateExceptionResponse(Exception ex)
        {
            // Loga a exceção
            // this.LogManager.LogException("Auth: Ocorreu um erro inesperado.", ex);

            // Monta e devolve resposta genérica de erro
            ErrorsResponse errorResponse = new ErrorsResponse();
            errorResponse.Errors.Add(new ErrorResponseItem
            {
                Message = "Ocorreu um erro inesperado. " + Newtonsoft.Json.JsonConvert.SerializeObject(ex).Replace("\"", "'")
            });

            return Request.CreateResponse<ErrorsResponse>(HttpStatusCode.InternalServerError, errorResponse);
        }

        #endregion
    }
}
