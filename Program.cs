using System;
using System.Collections.Generic;

namespace Szyfr_Polybius
{
    class PolybiusCipher
    {
        private Dictionary<char, string> encryptionTable = new Dictionary<char, string>
        {

            {'A', "11"}, {'B', "12"}, {'C', "13"}, {'D', "14"}, {'E', "15"},
            {'F', "21"}, {'G', "22"}, {'H', "23"}, {'I', "24"}, {'J', "24"},
            {'K', "25"}, {'L', "31"}, {'M', "32"}, {'N', "33"}, {'O', "34"},
            {'P', "35"}, {'Q', "41"}, {'R', "42"}, {'S', "43"}, {'T', "44"},
            {'U', "45"}, {'V', "51"}, {'W', "52"}, {'X', "53"}, {'Y', "54"},
            {'Z', "55"}, {' ', " "}
        };

        private Dictionary<string, char> decryptionTable;

        public PolybiusCipher()
        {
            decryptionTable = new Dictionary<string, char>();
            foreach (var entry in encryptionTable)
            {
                decryptionTable[entry.Value] = entry.Key;
            }
        }

        public string Encrypt(string input)
        {
            input = input.ToUpper();
            string encryptedText = "";

            foreach (char letter in input)
            {
                if (encryptionTable.ContainsKey(letter))
                {
                    encryptedText += encryptionTable[letter];
                }
            }

            return encryptedText;
        }

        public string Decrypt(string input)
        {
            string decryptedText = "";
            for (int i = 0; i < input.Length; i += 2)
            {
                string pair = input.Substring(i, 2);
                if (decryptionTable.ContainsKey(pair))
                {
                    decryptedText += decryptionTable[pair];
                }
            }

            return decryptedText;
        }
    }

    class Program
    {
        static void Main()
        {
            PolybiusCipher cipher = new PolybiusCipher();

            string plaintext = "HELLO WORLD";
            string encryptedText = cipher.Encrypt(plaintext);
            Console.WriteLine("Zaszyfrowany tekst: " + encryptedText);

            string decryptedText = cipher.Decrypt(encryptedText);
            Console.WriteLine("Odszyfrowany tekst: " + decryptedText);
        }
    }

}