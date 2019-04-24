using System;
using System.Collections.Generic;
using System.Text;

namespace Katan.Core.Extensions
{
    public static class Cryptography
    {
        public static List<int> StringToBinary(this string data)
        {
            StringBuilder sb = new StringBuilder();
            List<int> binaryFormat = new List<int>();
            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            foreach (var symbol in sb.ToString())
            {
                binaryFormat.Add(Int16.Parse(symbol.ToString()));
            }
            return binaryFormat;
        }

        public static string AlternativeBinaryToString(List<int> binaryList)
        {
            Byte[] bytes = new Byte[binaryList.Count];
            for (int i = 0; i < binaryList.Count; i++)
            {
                bytes[i] = (byte)binaryList[i];
            }
            return Convert.ToBase64String(bytes);
        }

        public static string BinaryToString(List<int> binaryList)
        {
            StringBuilder data = new StringBuilder();
            List<Byte> byteList = new List<Byte>();
            foreach (var num in binaryList)
            {
                data.Append(num);
            }
            for (int i = 0; i < data.ToString().Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.ToString().Substring(i, 8), 2));
            }
            return Encoding.UTF8.GetString(byteList.ToArray());
        }

        public static List<int> NumberToBits(int number, int bitLength)
        {
            List<int> bits = new List<int>();
            for (int i = 0; i < bitLength; i++)
            {
                bits.Add(number & 1);
                number >>= 1;
            }
            return bits;
        }

        public static int BitsToNumber(List<int> bits, bool flag = true)
        {
            if (flag)
            {
                int number = 0;
                for (int i = 0; i < bits.Count; i++)
                {
                    if (bits[i] == 0 || bits[i] == 1)
                    {
                        number += (bits[i] << i);
                    }
                }
                return number;
            }
            else
            {
                long number = 0;
                for (int i = 0; i < bits.Count; i++)
                {
                    if (bits[i] == 0 || bits[i] == 1)
                    {
                        number += (bits[i] << i);
                    }
                }
                Console.WriteLine($"From py: {number}");
                return 0;
            }
        }

        public static IEnumerable<int> SpecialTransform(int key)
        {
            List<int> state = NumberToBits(key, 80);
            for (int i = 0; i < 254 * 2; i++)
            {
                yield return state[0];
                state.Add(state[0] ^ state[19] ^ state[30] ^ state[67]);
                state.RemoveAt(0);
            }
        }

        public static List<int> GenerateKey(int number)
        {
            List<int> specialKey = new List<int>();
            var stream = SpecialTransform(number);
            foreach (var item in stream)
            {
                specialKey.Add(item);
            }
            return specialKey;
        }
    }

}
