using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TestWebProject.REST
{
    public static class JsonSerialization
    {
        public static string SerializeToJson<T>(T obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(obj);

            return json;
        }

        public static T DeserializeFromJson<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T caseGetResponse = caseGetResponse = serializer.Deserialize<T>(json);
            return caseGetResponse;
        }
    }
}
