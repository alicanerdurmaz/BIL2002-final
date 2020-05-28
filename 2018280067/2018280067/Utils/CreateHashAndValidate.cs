using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _2018280067.Utils
{
	public static class CreateHashAndValidate
	{   
        public static bool CheckPassword(string source,string accountId)
		{
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = GetHash(sha256Hash, source);

                if (VerifyHash(hash, accountId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
		}

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyHash(string generatedHash, string accountId)
        {
            string hashFromDb = "";
            string[] lines = { };

			try
			{
                lines = File.ReadAllLines(@"C:\final\auth.txt");
            }
			catch (Exception e)
			{
                Debug.WriteLine(e.Message);
			}

            foreach (string line in lines)
            {   
                string[] lineParse = line.Split(',');

				if (lineParse[0].Equals(accountId))
				{
					hashFromDb = lineParse[1];
                    break;
                }
			}

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashFromDb, generatedHash) == 0;
        }
    }
}
