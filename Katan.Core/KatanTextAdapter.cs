using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katan.Core.Extensions;

namespace Katan.Core
{
    public class KatanTextAdapter
    {
        public StringBuilder stringBuilder = new StringBuilder();
        public List<List<int>> blocks = new List<List<int>>();
        public Katan Katan { get; set; }

        public KatanTextAdapter(Katan katan)
        {
            Katan = katan;
        }

        public List<List<int>> SplitToBinaryBlock(string text, Katan.Version version)
        {
            int chunkSize = (int)version / 8;
            var stringBlocks = Enumerable.Range(0, text.Length / chunkSize)
               .Select(i => text.Substring(i * chunkSize, chunkSize))
               .ToList();
            foreach (var strBlock in stringBlocks)
            {
                blocks.Add(Cryptography.StringToBinary(strBlock));
            }
            return blocks;
        }

        public List<string> KatanEncryptText(string text)
        {
            List<string> blocksOfText = new List<string>();
            blocks = SplitToBinaryBlock(text, Katan.KatanVersion);
            foreach (var block in blocks)
            {
                //stringBuilder.Append(Cryptography.AlternativeBinaryToString(Katan.KatanEncryption(block)));
                blocksOfText.Add(Cryptography.AlternativeBinaryToString(Katan.KatanEncryption(block)));
            }
            return blocksOfText;
        }

        public string KatanDecryptText(string text)
        {
            var bytes = Convert.FromBase64String(text);
            blocks = SplitToBinaryBlock(text, Katan.KatanVersion);
            foreach (var block in blocks)
            {
                stringBuilder.Append(Cryptography.BinaryToString(Katan.KatanDecription(block)));
            }
            return stringBuilder.ToString();
        }

        public string AltKatanDecryptText(byte[] arr)
        {
            var some = arr.ToList();
            List<int> someSpecial = new List<int>();
            some.ForEach(x => someSpecial.Add(x));
            return Cryptography.BinaryToString(Katan.KatanDecription(someSpecial));
        }
    }
}
