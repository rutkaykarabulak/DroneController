using System;
using System.Net;
namespace Musala.BatteryLogger
{
    /// <summary>
    /// This console app is used to log all drone batteries
    /// 
    /// It creates a new text file that contains all the drones with their Id and Battery in percentage.
    /// The file will be located Musala/PeriodicTask/BatteryLogger/Result
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:5203/api/Drone/CheckAllBatteries";

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            Console.WriteLine(data);

            using (StreamWriter writer = new StreamWriter("./result/file.txt"))
            {
                writer.WriteLine(data);
            }
        }
    }
}