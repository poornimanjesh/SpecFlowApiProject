using Newtonsoft.Json;
using SpecFlowApiProject.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;
using Nest;

namespace SpecFlowApiProject.StepDefinitions
{
    [Binding]
    public class PostHttpsSteps

    {


        HttpClient httpClient;
        HttpResponseMessage response;
        string responsebody;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;


        public PostHttpsSteps(ISpecFlowOutputHelper specFlowOutputHelper)
        {
           httpClient = new HttpClient();

           _specFlowOutputHelper = specFlowOutputHelper;


        }


        [Given(@"the user sends a post request with url as ""([^""]*)""")]
        public async Task GivenTheUserSendsAPostRequestWithUrlAs(string url)
        {
            PostData postdata = new PostData()
            {
                Name = "Manjesh",
                Job = "Devoloper"
            };

            string data = JsonConvert.SerializeObject(postdata);
            var contentdata = new StringContent(data);
           response = await httpClient.PostAsync(url, contentdata);

            responsebody= await response.Content.ReadAsStringAsync();    
            _specFlowOutputHelper.WriteLine("post response is"+ responsebody);
        }

        [Then(@"user should get a suceess response")]
        public void ThenUserShouldGetASuceessResponse()
        {
            Assert.True(response.IsSuccessStatusCode);
        }


    }

}

