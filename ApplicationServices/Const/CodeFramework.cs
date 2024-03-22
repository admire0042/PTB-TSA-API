using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Const
{
    public class CodeFramework
    {
        private static string GenTransactionCodes(int NumSides)
        {
            byte[] array = new byte[NumSides];
            using (RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(array);
            }

            StringBuilder text = new StringBuilder();
            foreach (byte b in array)
            {
                text.Append(Convert.ToInt32(b));
            }

            int startIndex = (int)Math.Round((double)NumSides / 2.0);
            return text.ToString().Substring(startIndex, NumSides);
        }

        public static string GenerateNumericTransactionCodes(int codeLength)
        {
            return GenTransactionCodes(codeLength);
        }
    }
}
