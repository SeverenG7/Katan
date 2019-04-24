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
            StringBuilder sb;
            Katan.Core.Katan katan32 = new Katan.Core.Katan(Katan.Core.Katan.Version.Version32, 90);
            Katan.Core.Katan katan48 = new Katan.Core.Katan(Katan.Core.Katan.Version.Version48, 90);
            Katan.Core.Katan katan64 = new Katan.Core.Katan(Katan.Core.Katan.Version.Version64, 90);


            KatanTextAdapter katanTextAdapter = new KatanTextAdapter(katan64);
            var secretText = katanTextAdapter.KatanEncryptText("hello my dear friend i really glad to see u today here, yea!)))09");
            var realText = katanTextAdapter.AltKatanDecryptText(secretText);
            Console.WriteLine(katanTextAdapter.SpecialRetransformText(realText));
            Console.ReadKey();
        }
    }
}
