using System.Security.Cryptography;
using System.Text;

namespace MetadecBackEnd.Utils
{
    public class Encriptar
    {
        public static string EncriptarPassword(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string EncriptarPasswordSesion(string input) 
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(input);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        public static string DesencriptarPasswordSesion(string input)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(input);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }


    }
}
