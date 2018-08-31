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
        private string _url = "https://jsonplaceholder.typicode.com/users";

        [TestMethod]
        public void VerifyResponceStatusCode()
        {
            HttpStatusCode responceCode = HTTPrequests.GetResponseStatusCode(HTTPrequests.ExecuteGetRequest(_url));
            Assert.AreEqual(Convert.ToString(responceCode), "OK");
        }

        [TestMethod]
        public void VerifyResultCountHeader()
        {
            string headerName = "Authorization";
            string contentType = "ContentType";
            string headerValue = HTTPrequests.GetResponseHeader(HTTPrequests.ExecuteGetRequest(_url), headerName);
            string contentTypeValue = HTTPrequests.GetResponseHeader(HTTPrequests.ExecuteGetRequest(_url), contentType);
            Assert.IsTrue(Convert.ToInt32(headerValue) >= 0);
        }

        [TestMethod]
        public void VerifyBodyOfGetRequest()
        {
            UserGetDTO userGetRequest = new UserGetDTO();
            string userGetRequestJson = JsonSerialization.SerializeToJson(userGetRequest);         
            string body = HTTPrequests.GetResponseBody(HTTPrequests.ExecuteGetRequest(_url));
            UserGetDTO caseGetResponse = JsonSerialization.DeserializeFromJson<UserGetDTO>(body);
          
        }
    }
}
