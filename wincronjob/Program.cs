using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.VisualBasic;



namespace wincronjob
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("1");
            //    Thread.Sleep(1000);
            //}

            try
            {
                var token = Environment.GetEnvironmentVariable("TOKEN");
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = httpClient.GetStringAsync("https://broker.msa.apps.yokogawa.dev/resources/ashok-test-29/events").Result;
                Console.WriteLine(response.Substring(0, Math.Min(1024, response.Length)));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}
