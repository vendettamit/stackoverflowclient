﻿using RestSharp;
using StackQuestionsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQuestionsClient
{
    public class ServiceAPI
    {
        private readonly string key = "LdzA8KAXI)POXiHQRw2sBQ((";
        public static string url = "https://api.stackexchange.com/2.2/questions?&key=LdzA8KAXI)POXiHQRw2sBQ((&order=desc&sort=creation&site=stackoverflow&tagged=csharp,WCF";
        private static string args = "&key=LdzA8KAXI)POXiHQRw2sBQ((&order=desc&sort=creation&site=stackoverflow&tags=csharp,wcf&filter=!-*f(6t*YrKg4";

        public ServiceAPI()
        {

        }

        public async Task<IRestResponse<Rootobject>> GetLatestQuestion()
        {
            var client = new RestClient(url);

            var request = new RestRequest("2.2/questions?&{id}", Method.POST);
            // request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("id", args);
            var response = await client.ExecuteGetTaskAsync<Rootobject>(request);

            return response;
        }
    }
}
