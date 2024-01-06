using System;

class Program
{
    static void Main()
    {
        string originalText = "HELLO WORLD";
        string encryptedText = Encrypt(originalText);
        string decryptedText = Decrypt(encryptedText);

        Console.WriteLine("Original Text: " + originalText);
        Console.WriteLine("Encrypted Text: " + encryptedText);
        Console.WriteLine("Decrypted Text: " + decryptedText);
    }

    static string Encrypt(string input)
    {
        input = input.ToUpper();
        char[,] polybiusSquare = {
            {'A', 'B', 'C', 'D', 'E'},
            {'F', 'G', 'H', 'I', 'K'},
            {'L', 'M', 'N', 'O', 'P'},
            {'Q', 'R', 'S', 'T', 'U'},
            {'V', 'W', 'X', 'Y', 'Z'}
        };

        string encryptedText = "";

        foreach (char c in input)
        {
            if (c == 'J') // Handling the special case for 'J' (I and J share the same cell)
            {
                encryptedText += "24 ";
                continue;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (polybiusSquare[i, j] == c)
                    {
                        encryptedText += (i + 1).ToString() + (j + 1).ToString() + " ";
                    }
                }
            }
        }

        return encryptedText.Trim();
    }

    static string Decrypt(string input)
    {
        string[] pairs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        char[,] polybiusSquare = {
            {'A', 'B', 'C', 'D', 'E'},
            {'F', 'G', 'H', 'I', 'K'},
            {'L', 'M', 'N', 'O', 'P'},
            {'Q', 'R', 'S', 'T', 'U'},
            {'V', 'W', 'X', 'Y', 'Z'}
        };

        string decryptedText = "";

        foreach (string pair in pairs)
        {
            int row = int.Parse(pair[0].ToString()) - 1;
            int col = int.Parse(pair[1].ToString()) - 1;

            if (row == 4 && col == 2) // Handling the special case for 'J' (I and J share the same cell)
            {
                decryptedText += "I";
            }
            else
            {
                decryptedText += polybiusSquare[row, col];
            }
        }

        return decryptedText;
    }
}
