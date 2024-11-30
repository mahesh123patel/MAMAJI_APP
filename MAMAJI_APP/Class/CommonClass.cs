using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MAMAJI_APP.Class
{
    public class CommonClass
    {
        private string publickey = "<RSAKeyValue><Modulus>wbG0YKVsj27E8FJLnCabm/tgNM2o9Y5TEmRetlve6QEP7phgbZAkxJTuAroFnnMJQcx/taNorOBDOpqz2o6YkQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private string privatekey = "<RSAKeyValue><Modulus>wbG0YKVsj27E8FJLnCabm/tgNM2o9Y5TEmRetlve6QEP7phgbZAkxJTuAroFnnMJQcx/taNorOBDOpqz2o6YkQ==</Modulus><Exponent>AQAB</Exponent><P>1dUQM5QjmSsViUIxlRpXVQoutYzwadt5KuQzecrpVZs=</P><Q>5+QBMhgbupzmo2F724/zi2i/DHYvshbSP5NArsNrI0M=</Q><DP>J+qwLZC33H3odUkADH9wUhWmhomaz4gC5HjZCyFP0YU=</DP><DQ>qwrOpviJW3hn1pMNHMJtTaMRaEu0mpOiuSoQR9f0qqk=</DQ><InverseQ>fGo2lr2yRXtxd99bbnceah08F0cLsBIosBMdODPWExI=</InverseQ><D>KlinjtmbumAFPmU/kov+SUPT7Ldp0QWks8itzECZo2bumjVAbTM1/YOIAzfE+Pwur8uSvYxnIgOYwFGU8r1iYQ==</D></RSAKeyValue>";
        public byte[] Encrypt(string data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512))
            {
                rsa.FromXmlString(publickey);
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);
                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);
                return encryptedData;
            }
        }
        public string Decrypt(byte[] data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512))
            {
                rsa.FromXmlString(privatekey);
                byte[] decryptedData = rsa.Decrypt(data, false);
                return Encoding.UTF8.GetString(decryptedData);
            }
        }
    }
}