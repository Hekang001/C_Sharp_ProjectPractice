using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RememberSystem.Class
{
    public class RemeberData
    {
        public string[] P_num;
        public string[] P_man;
        public string[] P_action;
        public string[] P_thing;
        public int P_count = 0;

        public RemeberData()
        {
            P_num = new string[112];        //编号
            P_man = new string[112];        //人物
            P_action = new string[112];     //动作
            P_thing = new string[112];      //物品or动物

            int i = 0;
            for (i = 0; i < 10; i++)
            {
                P_num[i] = "0" + i.ToString();
            }
            for (i = 10; i < 100; i++)
            {
                P_num[i] = i.ToString();
            }
            for (i = 100; i < 109; i++)
            {
                P_num[i] = (i - 100).ToString();
            }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string readData(string filePath)
        {
            string strLine;
            try 
            {
                FileStream aFile = new FileStream(filePath, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                strLine = sr.ReadLine();
                int count = 0;
                while (strLine != null && strLine != "")
                {
                    string[] strs = strLine.Split('-');
                    if (strs.Length != 4)
                        continue;
                    P_man[count] = strs[1];
                    P_action[count] = strs[2];
                    P_thing[count] = strs[3];
                    count++;
                    strLine = sr.ReadLine();
                }
                P_count = count;
                sr.Close();
                return "OK";
            }
            catch (IOException ex)
            {
                return ex.ToString();
            }
        }


        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string writeFile(string filePath)
        {
            try 
            {
                FileStream aFile = new FileStream(filePath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);

                for (int i = 0; i < 110; i++)
                {
                    string num;
                    if (i < 10)
                        num = "0" + i.ToString();
                    else if (i < 100)
                        num = i.ToString();
                    else
                        num = (i - 100).ToString();
                    string strline = num + "-" + P_man[i] + "-" + P_action[i] + "-" + P_thing[i];
                    sw.WriteLine(strline);
                }
                sw.Close();
                return P_count.ToString() ;
            }
            catch(IOException ex)
            {
                return ex.ToString();
            }
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="T_man">人物</param>
        /// <param name="T_action">动作</param>
        /// <param name="T_thing">姓名</param>
        /// <returns></returns>
        public bool insertData(string T_man, string T_action, string T_thing, int T_num)
        {
            if (T_num >= 110 || T_num < 0)
                return false;

            P_man[T_num] = T_man;
            P_action[T_num] = T_action;
            P_thing[T_num] = T_thing;

            return true;
        }
    }
}
