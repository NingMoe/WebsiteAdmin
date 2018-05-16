using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace XueFu.EntLib
{
    public class EncryptHelper
    {
        /// <summary>
        /// 密钥
        /// </summary>
        private static string key = "XueFu";

        #region ========MD5加密========
        public static string MD5(string encypString)
        {
            return MD5(encypString, Encoding.Default.WebName);
        }

        public static string MD5(string encypString, string _input_charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5Byte = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(encypString));
            //StringBuilder sb = new StringBuilder(32);
            //for (int i = 0; i < md5Byte.Length; i++)
            //{
            //    sb.Append(md5Byte[i].ToString("x").PadLeft(2, '0'));
            //}
            return System.BitConverter.ToString(md5Byte).Replace("-", "");
        }
        #endregion

        #region ========SHA1加密========

        /// <summary>
        /// 基于Sha1的自定义加密字符串方法：输入一个字符串，返回一个由40个字符组成的十六进制的哈希散列（字符串）。
        /// </summary>
        /// <param name="encypString">要加密的字符串</param>
        /// <returns>加密后的十六进制的哈希散列（字符串）</returns> 
        public static string SHA1(string encypString)
        {
            return SHA1(encypString, Encoding.Default.WebName);
        }

        /// <summary>
        /// 基于Sha1的自定义加密字符串方法：输入一个字符串，返回一个由40个字符组成的十六进制的哈希散列（字符串）。
        /// </summary>
        /// <param name="encypString">要加密的字符串</param>
        /// <param name="_input_charset">字符编码</param>
        /// <returns>加密后的十六进制的哈希散列（字符串）</returns> 
        public static string SHA1(string encypString, string _input_charset)
        {
            // 第一种方式
            using (SHA1 hashAlgorithm = new SHA1CryptoServiceProvider())
            {
                byte[] byteArray = hashAlgorithm.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(encypString));
                //StringBuilder sb = new StringBuilder(256);
                //foreach (byte item in byteArray)
                //{
                //    sb.AppendFormat("{0:x2}", item);
                //}
                hashAlgorithm.Clear();
                //return sb.ToString();
                return System.BitConverter.ToString(byteArray).Replace("-", "");
            }

            //// 第二种方式
            //using (SHA1 sha1 = SHA1.Create())
            //{
            //    byte[] hash = sha1.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(encypString));
            //    StringBuilder sb = new StringBuilder();
            //    for (int index = 0; index < hash.Length; ++index)
            //        sb.Append(hash[index].ToString("x2"));
            //    sha1.Clear();
            //    return sb.ToString();
            //}
        }
        #endregion

        #region ========Des加密========
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <returns></returns>
        public static string DesEncrypt(string encryptString)
        {
            return DesEncrypt(encryptString, key);
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <returns></returns>
        public static string DesEncrypt(string encryptString, string sKey)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(sKey.Substring(0, 8));
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
        #endregion

        #region ========Des解密========
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <returns></returns>
        public static string DesDecrypt(string decryptString)
        {
            return DesDecrypt(decryptString, key);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <returns></returns>
        public static string DesDecrypt(string decryptString, string sKey)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(sKey.Substring(0, 8));
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }
        #endregion

    }
}
