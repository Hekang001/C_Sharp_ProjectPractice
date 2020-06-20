using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;
using System.Net;


namespace LifeStateSystem.AllClass
{
    public class MD5_APP
    {
        /// <summary>
        /// 获取加密字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="type">16位，32位</param>
        /// <returns></returns>
        public static string Get_StringToMD5(string str, int type)
        {
            string password_md5;
            if (str != string.Empty)
            {
                //获取字节序列
                byte[] result = Encoding.Default.GetBytes(str);

                //建立加密服务
                MD5 md5 = new MD5CryptoServiceProvider();

                //加密数组
                byte[] output = md5.ComputeHash(result);

                //转化为字符串
                password_md5 = BitConverter.ToString(output).Replace("-", "");
            }
            else
                password_md5 = "00000000000000000000000000000000";

            switch (type)
            {
                case 16: return password_md5.Substring(8,16);
                case 32: return password_md5;
                default: return "位数不对，应该输入16位，或者32位";
            }
            
        }

        /// <summary>
        /// 根据链接获取图片，并保存在本地
        /// 如果已经存在本地，就直接打开本地图片
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public static Bitmap LoadImageInNetOrFile(string imgUrl)
        {
            string testResult = Get_StringToMD5(imgUrl, 16);
            string fileName = "image_net\\" + testResult + ".jpg";

            //创建文件夹
            if (!Directory.Exists("image_net"))
            {
                Directory.CreateDirectory("image_net");
            }

            if (!File.Exists(fileName))
            {
                //获取网络文件
                Uri myUri = new Uri(imgUrl);
                WebRequest webRequest = WebRequest.Create(myUri);
                WebResponse webResponse = webRequest.GetResponse();
                Bitmap myImage = new Bitmap(webResponse.GetResponseStream());
                myImage.Save(fileName);
                return myImage;
            }
            else
            {
                //打开本地文件
                //P_pokeImage[0] = Image.FromFile(fileName);
                Bitmap myImage = (Bitmap)Image.FromFile(fileName);
                return myImage;
            }
        }
    }
}
