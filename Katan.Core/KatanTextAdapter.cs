using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katan.Core.Extensions;

namespace Katan.Core
{
    public class KatanTextAdapter
    {
        public StringBuilder stringBuilder = new StringBuilder();
        public List<List<int>> blocks = new List<List<int>>();
        public Katan Katan { get; set; }
        private int _specialSymbols;

        public KatanTextAdapter(Katan katan)
        {
            Katan = katan;
        }

        public string KatanEncryptText(string text)
        {
            List<string> blocksOfText = new List<string>();
            blocks = SplitToBinaryBlock(text, Katan.KatanVersion);
            foreach (var block in blocks)
            {
                stringBuilder.Append(Cryptography.AlternativeBinaryToString(Katan.KatanEncryption(block)));
                blocksOfText.Add(Cryptography.AlternativeBinaryToString(Katan.KatanEncryption(block)));
            }
            return stringBuilder.ToString();
        }

        public string AltKatanDecryptText(string text)
        {
            List<byte[]> arr = PrepareTextToDecrypt(text);
            StringBuilder sb = new StringBuilder();
            foreach (var block in arr)
            {
                List<int> buffer = new List<int>();
                block.ToList().ForEach(x => buffer.Add(x));
                sb.Append(Cryptography.BinaryToString(Katan.KatanDecription(buffer)));
            }
            return sb.ToString();
        }

        private List<List<int>> SplitToBinaryBlock(string text, Katan.Version version)
        {
            int chunkSize = 0;
            switch (version)
            {
                case Katan.Version.Version32:
                    chunkSize = (int)version / 8;
                    break;
                case Katan.Version.Version48:
                    chunkSize = (int)version / 6;
                    break;
                case Katan.Version.Version64:
                    chunkSize = (int)version / 4;
                    break;
            }
            text = SpecialTransformText(text, chunkSize);
            var stringBlocks = Enumerable.Range(0, text.Length / chunkSize)
               .Select(i => text.Substring(i * chunkSize, chunkSize))
               .ToList();
            foreach (var strBlock in stringBlocks)
            {
                blocks.Add(Cryptography.StringToBinary(strBlock));
            }
            return blocks;
        }

        private List<byte[]> PrepareTextToDecrypt(string cryptoText)
        {
            List<byte[]> bytesBlock = new List<byte[]>();
            foreach (var block in cryptoText.Split('='))
            {
                if (block != "")
                {
                    string some = $"{ block}=";
                    bytesBlock.Add(Convert.FromBase64String(some));
                }
            }
            return bytesBlock;
        }

        private string SpecialTransformText(string text, int chunkSize)
        {
            if (text.Length % chunkSize != 0)
            {
                while (text.Length % chunkSize != 0)
                {
                    _specialSymbols++;
                    text += "#";
                }
            }
            return text;
        }

        public string SpecialRetransformText(string text) => text.Remove(text.Length - _specialSymbols, _specialSymbols);
    }
}
