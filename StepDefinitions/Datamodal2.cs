using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowApiProject.StepDefinitions
{
    class Datamodal2
    {
        public String Name { get; set; }
        public String Job { get; set; }
        public Object[] addr { get; set; }
    }
    class postalcode
    {
        public String code { get; set; }
        public String sector { get; set; }
    }

    class serializeable
    {
#pragma warning disable CS0017 // Program has more than one entry point defined. Compile with /main to specify the type that contains the entry point.
        static void Main(string[] args)
#pragma warning restore CS0017 // Program has more than one entry point defined. Compile with /main to specify the type that contains the entry point.
        {

            
                Datamodal2 data = new Datamodal2();
                {


                    data.Name = "Aadya";
                    data.Job = "Tester";
                    data.addr = new Object[] { new postalcode() { code = "DA1 49Z", sector = "567" }, "London", "UK" };
                };

              var dataser=  JsonConvert.SerializeObject(data);
                Console.WriteLine(dataser);
                Console.ReadLine();
            
        }
                
    }

}

    

