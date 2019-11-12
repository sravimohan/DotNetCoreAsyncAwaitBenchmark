using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BenchMark
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static void Main()
        {
            var url = "https://localhost:44352/readfile";
            var urlAsync = "https://localhost:44352/readfileasync";

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
            while (count <= 1000)
            {
                count++;
                tasks.Add(client.GetAsync(url));
            }

            Task.WaitAll();
            
            Console.WriteLine($"Elapsed time for 1000 calls is {DateTime.Now - startTime}");
        }
    }
}
