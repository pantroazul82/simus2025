using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SM.Utilidades.Seguridad
{
    public class Encriptar
    {
        static private Byte[] m_Key = new Byte[8];
        static private Byte[] m_IV = new Byte[8]; 
        public static string GetKeyValue(string pstrKey)
        {
            // AppSettingsReader objSettingsReader = new AppSettingsReader();

            // object objValue = objSettingsReader.GetValue(pstrKey, typeof(string));
            object objValue = (object)@"098#7UI#OPPDFG";

            if (objValue != null)
                return objValue.ToString();
            else
                return string.Empty;
        }
        public static string encryptar(string x)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider objCryptography = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(x);
            data = objCryptography.ComputeHash(data);
            String md5Hash = System.Text.Encoding.ASCII.GetString(data);

            return md5Hash;
        }

        public static string DecryptData(String strKey, String strData)
        {
            string strResult;

            strKey = "098#7UI#OPPDFG";
           // strData = "DUa3cdrKssni7wkwY/10yg==";
            //1. Generate the Key used for decrypting
            if (!InitKey(strKey))
            {
                strResult = "Error. Fail to generate key for decryption";
                return strResult;
            }

            //2. Initialize the service provider
            int nReturn = 0;
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
            ICryptoTransform desDecrypt = descsp.CreateDecryptor(m_Key, m_IV);

            //3. Prepare the streams:
            //	mOut is the output stream. 
            //	cs is the transformation stream.
            MemoryStream mOut = new MemoryStream();
            CryptoStream cs = new CryptoStream(mOut, desDecrypt, CryptoStreamMode.Write);

            //4. Remember to revert the base64 encoding into a byte array to restore the original encrypted data stream
            byte[] bPlain = new byte[strData.Length];
            try
            {
                bPlain = Convert.FromBase64CharArray(strData.ToCharArray(), 0, strData.Length);
            }
            catch (Exception)
            {
                strResult = "Error. Input Data is not base64 encoded.";
                return strResult;
            }

            long lRead = 0;
            long lTotal = strData.Length;

            try
            {
                //5. Perform the actual decryption
                while (lTotal >= lRead)
                {
                    cs.Write(bPlain, 0, (int)bPlain.Length);
                    //descsp.BlockSize=64
                    lRead = mOut.Length + Convert.ToUInt32(((bPlain.Length / descsp.BlockSize) * descsp.BlockSize));
                };

                /*ASCIIEncoding aEnc = new ASCIIEncoding();
                strResult = aEnc.GetString(mOut.GetBuffer(), 0, (int)mOut.Length);*/

                strResult = ByteArrayTostring(mOut.GetBuffer());

                //6. Trim the string to return only the meaningful data
                //	Remember that in the encrypt function, the first 5 character holds the length of the actual data
                //	This is the simplest way to remember to original length of the data, without resorting to complicated computations.
                String strLen = strResult.Substring(0, 5);
                int nLen = Convert.ToInt32(strLen);
                strResult = strResult.Substring(5, nLen);
                nReturn = (int)mOut.Length;

                return strResult;
            }
            catch (Exception)
            {
                strResult = "Error. Decryption Failed. Possibly due to incorrect Key or corrputed data";
                return strResult;
            }
        }

        //Function to encrypt data
        public static string EncryptData(String strKey, String strData)
        {
            string strResult;		//Return Result

            //1. String Length cannot exceed 90Kb. Otherwise, buffer will overflow. See point 3 for reasons
            if (strData.Length > 92160)
            {
                strResult = "Error. Data String too large. Keep within 90Kb.";
                return strResult;
            }

            //2. Generate the Keys
            if (!InitKey(strKey))
            {
                strResult = "Error. Fail to generate key for encryption";
                return strResult;
            }

            //3. Prepare the String
            //	The first 5 character of the string is formatted to store the actual length of the data.
            //	This is the simplest way to remember to original length of the data, without resorting to complicated computations.
            //	If anyone figure a good way to 'remember' the original length to facilite the decryption without having to use additional function parameters, pls let me know.
            strData = String.Format("{0,5:00000}" + strData, strData.Length);


            //4. Encrypt the Data
            /*byte[] rbData = new byte[strData.Length];
            ASCIIEncoding aEnc = new ASCIIEncoding();
            aEnc.GetBytes(strData, 0, strData.Length, rbData, 0);*/

            byte[] rbData = StringToByteArray(strData);


            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();

            ICryptoTransform desEncrypt = descsp.CreateEncryptor(m_Key, m_IV);


            //5. Perpare the streams:
            //	mOut is the output stream. 
            //	mStream is the input stream.
            //	cs is the transformation stream.
            MemoryStream mStream = new MemoryStream(rbData);
            CryptoStream cs = new CryptoStream(mStream, desEncrypt, CryptoStreamMode.Read);
            MemoryStream mOut = new MemoryStream();

            //6. Start performing the encryption
            int bytesRead;
            byte[] output = new byte[1024];
            do
            {
                bytesRead = cs.Read(output, 0, 1024);
                if (bytesRead != 0)
                    mOut.Write(output, 0, bytesRead);
            } while (bytesRead > 0);

            //7. Returns the encrypted result after it is base64 encoded
            //	In this case, the actual result is converted to base64 so that it can be transported over the HTTP protocol without deformation.
            if (mOut.Length == 0)
                strResult = "";
            else
                strResult = Convert.ToBase64String(mOut.GetBuffer(), 0, (int)mOut.Length);

            return strResult;
        }

        // Converierte matriz de byte[] en string 
        private static string ByteArrayTostring(byte[] strB)
        {
            int intL = strB.Length;
            string bytS = string.Empty;
            for (int intC = 0; intC < intL; intC++)
            {
                bytS += (char)strB[intC];

            }
            return bytS;
        }

        //Private function to generate the keys into member variables
        private static bool InitKey(String strKey)
        {
            try
            {
                // Convert Key to byte array
                byte[] bp = new byte[strKey.Length];
                ASCIIEncoding aEnc = new ASCIIEncoding();
                aEnc.GetBytes(strKey, 0, strKey.Length, bp, 0);

                //Hash the key using SHA1
                SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
                byte[] bpHash = sha.ComputeHash(bp);

                int i;
                // use the low 64-bits for the key value
                for (i = 0; i < 8; i++)
                    m_Key[i] = bpHash[i];

                for (i = 8; i < 16; i++)
                    m_IV[i - 8] = bpHash[i];

                return true;
            }
            catch (Exception)
            {
                //Error Performing Operations
                return false;
            }
        }

        // Converierte string en una matriz de byte[]
        private static byte[] StringToByteArray(string strC)
        {
            int intL = strC.Length;
            byte[] bytC = new byte[intL];
            for (int intC = 0; intC < intL; intC++)
            {
                bytC[intC] = (byte)strC[intC];

            }
            return bytC;
        }
    }
}
