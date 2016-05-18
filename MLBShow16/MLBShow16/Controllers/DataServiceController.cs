using HtmlAgilityPack;
using MLBShow16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MLBShow16.Controllers
{
    public class DataServiceController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllBids()
        {
            // - Create new Player Model under Models/ named player.
            //      - Maybe use HtmlAgilityPack to help parse: http://stackoverflow.com/questions/655603/html-agility-pack-parsing-tables
            //      - Return every listing on Pages 1 & 2. (We will have filters set up for specific querying)
            //      - Return List<Players> below where 'lst' is.

            //  - When navigating the app, you can check the # of records at /market/.
            //      - I left a 'degbugger' there on /app/market/market.js on ln 24, so if you run the app using chrome, 
            //        hit F12 for developer tools and then navigate to /market/ it should hit the breakpoint.




            var lst = new List<Test>()
            {
                new Test() { ID = 1, TestString = "TEST1"},
                new Test() { ID = 2, TestString = "TEST2"}
            };            

            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }
    }
}