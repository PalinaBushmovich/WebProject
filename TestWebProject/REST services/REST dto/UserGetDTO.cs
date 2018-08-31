using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebProject.REST.REST_dto
{
    public struct UserGetDTO
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Adrress adrress { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }

        public struct Adrress
        {
            public string street { get; set; }
            public string suite { get; set; }
            public string city { get; set; }
            public string zipcode { get; set; }
            public Geo geo { get; set; }
        }

        public struct Geo
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public struct Company
        {
            public string name { get; set; }
            public string catchPhrase { get; set; }
            public string bs { get; set; }
        }
    }
}
