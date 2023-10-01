using Newtonsoft.Json;
using SpecFlowApiProject.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowApiProject.StepDefinitions
{
    public class Employee
    {
        public  string Name { get; set; }

        public string Gender { get; set; }
    }
    [Binding]
    public class Httptest
    {
        HttpClient httpClient;
        HttpResponseMessage response;
        String responsebody;
        private readonly ISpecFlowOutputHelper specFlowOutputHelper;
        public Httptest(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            httpClient = new HttpClient();
            this.specFlowOutputHelper = specFlowOutputHelper;
        }
        [Given(@"the user sends a get request with url ""([^""]*)""")]
        public async Task  GivenTheUserSendsAGetRequestWithUrl(string URL)
        {
            response= await httpClient.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            responsebody = await response.Content.ReadAsStringAsync();
            specFlowOutputHelper.WriteLine(responsebody);

           var desdata= JsonConvert.DeserializeObject<DataModuel>(responsebody);
            specFlowOutputHelper.WriteLine("after deserialization value is"+ desdata.ToString());

            foreach (var item in desdata.data)
            {
                specFlowOutputHelper.WriteLine(item.id.ToString());
            }

        }

        [Then(@"request should be a sucess with (.*)s code")]
        public void ThenRequestShouldBeASucessWithSCode(int p0)
        {
            
        }

    }
}
