using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labet_Telemedicina_Back.Application.Models
{
    public class ResponseModel
    {

        public ResponseModel(int statusCode)
        {
            StatusCode = statusCode;
        }

        public ResponseModel(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public ResponseModel(int statusCode, object content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public ResponseModel()
        {
        }

        public object Content { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public static ResponseModel BuildResponse(int statusCode, object content)
        {
            return new ResponseModel(statusCode, content);
        }

        public static ResponseModel BuildOkResponse(object content)
        {
            return new ResponseModel(200, content);
        }

        public static ResponseModel BuildOkResponse()
        {
            return new ResponseModel(200);
        }

        public static ResponseModel BuildErrorResponse(object content)
        {
            return new ResponseModel(500, content);
        }

        public static ResponseModel BuildErrorResponse()
        {
            return new ResponseModel(500);
        }

        public static ResponseModel BuildUnauthorizedResponse(object content)
        {
            return new ResponseModel(401, content);
        }

        public static ResponseModel BuildUnauthorizedResponse()
        {
            return new ResponseModel(401);
        }

        public static ResponseModel BuildForbiddenResponse(object content)
        {
            return new ResponseModel(403, content);
        }

        public static ResponseModel BuildForbiddenResponse()
        {
            return new ResponseModel(403);
        }

        public static ResponseModel BuildConflictResponse(object content)
        {
            return new ResponseModel(409, content);
        }

        public static ResponseModel BuildConflictResponse()
        {
            return new ResponseModel(409);
        }

        public static ResponseModel BuildUnprocessableEntityResponse(object content)
        {
            return new ResponseModel(422, content);
        }

        public static ResponseModel BuildUnprocessableEntityResponse()
        {
            return new ResponseModel(422);
        }
    }
}
