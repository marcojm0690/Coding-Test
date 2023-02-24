using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Test.Model
{
    public class Recipient
    {
        [JsonProperty(PropertyName = "recipients")]
        public List<Info>? Recipients { get; set; }

        /// <summary>
        /// Load the file and deserialize the json File into a Recipient
        /// </summary>
        /// <returns></returns>
        public static Recipient? LoadJson()
        {
            string fileName = Path.Combine(Environment.CurrentDirectory, @"Json\data.json");
            string jsonString = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<Recipient>(jsonString)!;

        }
    }

}
