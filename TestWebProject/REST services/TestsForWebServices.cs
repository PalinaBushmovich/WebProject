using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TestWebProject.REST.REST_dto;

namespace TestWebProject.REST
{
    [TestClass]
    public class TestsForWebServices
    {
        private string Url = "https://jsonplaceholder.typicode.com/users";

        [TestMethod]
        public void VerifyResponceStatusCode()
        {
            HttpStatusCode responceCode = HTTPrequests.GetResponseStatusCode(HTTPrequests.ExecuteGetRequest(Url));

        }
        [TestMethod]
        public void SendPostUserRequest()
        {
            string userRequest = JsonSerialization.SerializeToJson(new UserGETdto());
            HttpStatusCode statusCode = HTTPrequests.GetResponseStatusCode(HTTPrequests.ExecutePostRequest(Url, userRequest));
            
        }
    }
}
