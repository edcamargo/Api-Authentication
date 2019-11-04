using Rijndael256;

namespace Authentication.InfraEstrutura.Security
{
    /// <summary>
    /// Class used to encrypt and decrypt data
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// Password used to encrypt data
        /// </summary>
        private static string password = "the#best#developer";

        /// <summary>
        /// Receives a plaintext string and returns an encrypted string
        /// </summary>
        /// <param name="textPlan"></param>
        /// <returns></returns>
        public static string Encrypt(string textPlan)
        {
            string textEncrypted = Rijndael.Encrypt(textPlan, password, KeySize.Aes256);

            return textEncrypted;
        }

        /// <summary>
        /// Receives an encrypted text and returns a plain text string
        /// </summary>
        /// <param name="textEncrypted"></param>
        /// <returns></returns>
        public static string Decrypt(string textEncrypted)
        {
            string textPlan = "";

            if (textEncrypted != null)
            {
                textPlan = Rijndael.Decrypt(textEncrypted, password, KeySize.Aes256);
            }

            return textPlan;
        }
    }
}
