using MAMAJI_APP.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAMAJI_APP
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512))
            //{
            //    // Export the public key
            //    //string publicKey = rsa.ToXmlString(false);
            //    //// Export the private key
            //    //string privateKey = rsa.ToXmlString(true);

            //    //Console.WriteLine("Public Key: ");
            //    //PublicKey.Text =  publicKey;
            //    //Console.WriteLine();
            //    //Console.WriteLine("Private Key: ");
            //    //PrivateKey.Text = privateKey;
                


            //}
            CommonClass cls = new CommonClass();
            string textToEncrypt = "Hello, World!";
            byte[] encryptedData = cls.Encrypt(textToEncrypt);

            Console.WriteLine("Encrypted Data: ");
            PublicKey.Text = Convert.ToBase64String(encryptedData);

            byte[] encryptedBytes = Convert.FromBase64String(PublicKey.Text);
            string decryptedText = cls.Decrypt(encryptedBytes);

            Console.WriteLine("Decrypted Data: ");
            PrivateKey.Text = decryptedText;
        }
    }
}