using System;
using RestSharp;
using NUnit.Framework;
using System.Text;



    [TestFixture]
    public class ProgramTests
    {
        
        [Test]
        public void GetCategories()
        {
            RestClient restClient = new RestClient("https://localhost:5001");

            RestRequest restRequest = new RestRequest("/api/categories",Method.GET);
            
            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            if(!response.Contains("Fruits and Vegetables"))
            {
                Assert.Fail("No information");
            }

        }


        [Test]
        public void TestMetod2()
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest("/api/categorie",Method.GET);
            
            var content = client.Execute(request).Content;

        }
    }