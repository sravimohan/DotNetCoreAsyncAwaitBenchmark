using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BenchMark
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task Main()
        {
            var url = "http://localhost:50095/readfile";
            var urlAsync = "http://localhost:50095/readfileasync";

            //warm up
            await client.GetAsync(url);
            await client.GetAsync(urlAsync);

            Console.WriteLine("Calling endpoint not using async/await");
            CallApi(url);
            Console.WriteLine("");

            Console.WriteLine("Calling endpoint using async/await");
            CallApi(urlAsync);
            Console.WriteLine("");
        }

        private static void CallApi(string url)
        {
            var tasks = new List<Task>();

            var startTime = DateTime.Now;

            var count = 0;
            while (count <= 10000)
            {
                count++;
                tasks.Add(client.GetAsync(url));
            }

            Task.WaitAll();
            
            Console.WriteLine($"Elapsed time for 10000 calls is {DateTime.Now - startTime}");
        }
    }
}
