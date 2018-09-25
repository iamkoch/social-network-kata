using System.Diagnostics;

namespace SocialNetwork.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var network = new SocialNetworkRunner(System.Console.WriteLine);
            while (network.Process(System.Console.ReadLine))
            {
                Debug.WriteLine("Running..");
            }
        }
    }
}
