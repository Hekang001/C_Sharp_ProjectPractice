using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using LifeStateSystem.AllClass;

namespace RememberSystem.Class
{
    public class PokeData
    {
        public Image[] P_pokeImage = new Image[58];
        public string[] P_man = new string[58];
        public string[] P_action = new string[58];
        public string[] P_pokeFile = { 
                                     "11","12","13","14","15","16","17","18","19","10","51","61","71",
                                     "21","22","23","24","25","26","27","28","29","20","52","62","72",
                                     "31","32","33","34","35","36","37","38","39","30","53","63","73",
                                     "41","42","43","44","45","46","47","48","49","40","54","64","74",
                                     "大王","小王"};

        public PokeData()
        {
            for (int i = 0; i < 54; i++)
            {
                P_pokeImage[i] = Image.FromFile("poke_image\\" + P_pokeFile[i] + ".jpg");
            }

           //string imgUrl = @"http://picview01.baomihua.com/photos/20120819/m_14_634810049071093750_35996743.jpg";
           //P_pokeImage[0] = MD5_APP.LoadImageInNetOrFile(imgUrl);
        }


        /// <summary>
        /// 录入一个编码
        /// </summary>
        /// <param name="T_man">人物</param>
        /// <param name="T_action">行为</param>
        /// <param name="T_num">序号</param>
        /// <returns></returns>
        public bool insert_pokeData(string T_man, string T_action, int T_num)
        {
            if (T_num > 54 || T_num < 1)
                return false;

            P_man[T_num - 1] = T_man;
            P_action[T_num - 1] = T_action;

            return true;
        }


        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="T_filePath"></param>
        /// <returns></returns>
        public string writeToFile(string T_filePath)
        {
            try
            {
                FileStream aFile = new FileStream(T_filePath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);

                for (int i = 0; i < 54; i++)
                {
                    string strline = (i+1).ToString() + "-" + P_man[i] + "-" + P_action[i];
                    sw.WriteLine(strline);
                }
                sw.Close();
                return "OK";
            }
            catch (IOException ex)
            {
                return ex.ToString();
            }
        }


        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="T_filePath"></param>
        /// <returns></returns>
        public string readFile(string T_filePath)
        {
             string strLine;
             try
             {
                 FileStream aFile = new FileStream(T_filePath, FileMode.Open);
                 StreamReader sr = new StreamReader(aFile);
                 strLine = sr.ReadLine();
                 int count = 0;
                 while (strLine != null && strLine != "")
                 {
                     string[] strs = strLine.Split('-');
                     if (strs.Length != 3)
                         continue;
                     P_man[count] = strs[1];
                     P_action[count] = strs[2];
                     count++;
                     strLine = sr.ReadLine();
                 }
                 sr.Close();
                 return "OK";
             }
             catch (IOException ex)
             {
                 return ex.ToString();
             }
        }
    }
}
