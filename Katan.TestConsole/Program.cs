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
            StringBuilder sb = new StringBuilder();
            Katan.Core.Katan katan32 = new Katan.Core.Katan(Katan.Core.Katan.Version.Version32, 90);

            KatanTextAdapter katanTextAdapter = new KatanTextAdapter(katan32);
            var secretText = katanTextAdapter.KatanEncryptText("hello my dear freinds");
            foreach (var block in secretText)
            {
               sb.Append(katanTextAdapter.AltKatanDecryptText(Convert.FromBase64String(block)));
            }
            Console.WriteLine(sb.ToString());
            //var bytes = Convert.FromBase64String(secretStr);
            //Console.WriteLine(katanTextAdapter.KatanDecryptText(secretStr));


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
