using System;
using System.Threading.Tasks;

namespace TestAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var a = new AsyncClass();
            await a.TestStart();
        }
    }
}
