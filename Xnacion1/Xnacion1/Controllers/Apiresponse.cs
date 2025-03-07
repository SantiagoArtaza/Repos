using System.Net;

namespace Xnacion1.Controllers
{
    public class Apiresponse<T>
    {
        public HttpStatusCode status { get; set; }

        public T data { get; set; }

        public string ErrorMessage { get; set; }

    }
}
