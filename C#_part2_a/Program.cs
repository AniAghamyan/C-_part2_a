using System;

class Program
{
    static int[,] LCSLength(string str1, string str2)
    {
        int len1 = str1.Length;
        int len2 = str2.Length;
        int[,] lcsTable = new int[len1 + 1, len2 + 1];
        for (int i = 1; i <= len1; i++)
        {
            for (int j = 1; j <= len2; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    lcsTable[i, j] = lcsTable[i - 1, j - 1] + 1;
                }
                else
                {
                    lcsTable[i, j] = Math.Max(lcsTable[i - 1, j], lcsTable[i, j - 1]);
                }
            }
        }

        return lcsTable;
    }

    static string FindLCS(string str1, string str2, int[,] lcsTable)
    {
        int i = str1.Length;
        int j = str2.Length;
        string lcs = "";
        while (i > 0 && j > 0)
        {
            if (str1[i - 1] == str2[j - 1])
            {
                lcs = str1[i - 1] + lcs; 
                i--;
                j--;
            }
            else if (lcsTable[i - 1, j] > lcsTable[i, j - 1])
            {
                i--;
            }
            else
            {
                j--;
            }
        }

        return lcs;
    }

    static void Main()
    {
        string str1 = "algorithm";
        string str2 = "rhythm";
        int[,] lcsTable = LCSLength(str1, str2);
        string lcs = FindLCS(str1, str2, lcsTable);
        Console.WriteLine($"Output: Length of the LCS is: {lcs.Length}");
        Console.WriteLine($"Longest Common Subsequence is: {lcs}");
    }
}
