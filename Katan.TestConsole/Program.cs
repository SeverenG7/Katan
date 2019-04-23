using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katan.Core.Extensions;
using Katan.Core;
using System.IO;

namespace Katan.TestConsole
{
    class Program
    {

        static void Main(string[] args)
        {


            //string h = "hello my dear friend i'm really glad to see you today";
            ////var bytes = Encoding.ASCII.GetBytes(h);
            ////List<int> bigList = new List<int>();

            Katan.Core.Katan katan32 = new Katan.Core.Katan(Katan.Core.Katan.Version.Version32, 90);
            int num = katan32.KatanEncryption(52);
            int num2 = katan32.KatanDecription(num);
            Console.WriteLine("Katan32:");
            Console.WriteLine(num);
            Console.WriteLine(num2);
            Console.WriteLine("-----------------------------");

            //Katan.Core.Katan katan64 = new Katan.Core.Katan(Katan.Core.Katan.Version.Version64, 90);
            //num = katan64.KatanEncryption(52);
            //num2 = katan64.KatanDecription(num);

            //Console.WriteLine("Katan64:");
            //Console.WriteLine(num);
            //Console.WriteLine(num2);
            //Console.WriteLine("-----------------------------");

            Console.ReadKey();
        }
    }
}
