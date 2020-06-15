using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace KurtoSys_Assessment
{
    public class TestWebServiceApi
    {
        /// <summary>
        /// Representing service endpoint
        /// </summary>
        private const string Service =
            "/tools/ksys373/api/fund/searchentity?data-version=1562843391575&req=%7B%22type%22%3A%22CLSS%22%2C%22search" 
            + "%22%3A%5B%7B%22property%22%3A%22core_holding_id%22%2C%22values%22%3A%5B%22GEMRE%22%5D%2C%22matchtype%22%3A%" 
            + "22MATCH%22%7D%2C%7B%22property%22%3A%22core_holding_id%22%2C%22values%22%3A%5B%22GEMRE%22%5D%2C%22matchtype%22%3A%22MATCH%22%7D%5D%2C%" 
            + "22include%22%3A%7B%22allocations%22%3A%7B%7D%2C%22statistics%22%3A%7B%7D%2C%22timeseries%22%3A%7B%7D" 
            + "%7D%2C%22culture%22%3A%22en-GB%22%2C%22applyFormats%22%3Afalse%2C%22limit%22%3A0%2C%22fundList%22%3A%22Institutional_NL%22%7D ";
        
        /// <summary>
        /// Testing service returns success 
        /// </summary>

        [Test]
        public void VerifyServiceReturnsSuccess()
        {
            var client = new RestClient("https://api.kurtosys.io");
            var request = new RestRequest(Service, Method.GET);
            
            var response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            
            var responseObject = new JsonDeserializer().Deserialize<dynamic>(response);
            var message = responseObject["values"];
            var values = message["properties_pub"];
            Assert.IsTrue(message.Contains(values));

            var responseTime = response.Request.Timeout;
            Console.WriteLine($"JSON size is: {responseTime}");

            var jsonSize = response.Content.Count();
            Console.WriteLine($"JSON size is: {jsonSize}");
        }
    }
}