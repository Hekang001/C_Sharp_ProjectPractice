using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RememberSystem.Class;
using System.Diagnostics;
using System.IO;

namespace RememberSystem
{
    public partial class RememberSystem : Form
    {
        public RememberSystem()
        {
            InitializeComponent();
            P_myRemeberData = new RemeberData();
        }


        //-------------------------------------------------------------------------
        //  初始化数字编码
        //-------------------------------------------------------------------------

        public RemeberData P_myRemeberData;

        /// <summary>
        /// 【录入程序】 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_insert_init_Click(object sender, EventArgs e)
        {
            int tmp_num = int.Parse(TB_num_init.Value.ToString());
            //插入以前编辑好的数据
            if (isBlank())
            {
                //MessageBox.Show("编辑框不能为空！");
                return;
            }
            P_myRemeberData.insertData( TB_man_init.Text.Trim(),
                                        TB_action_init.Text.Trim(),
                                        TB_thing_init.Text.Trim(),
                                        tmp_num);
            //如果已经到顶了
            if (109 == tmp_num)
            {
                //写入文件
                DialogResult dr = MessageBox.Show("是否要写入文件？", "提示", MessageBoxButtons.OKCancel);
                if(dr == DialogResult.OK)
                    P_myRemeberData.writeFile("DB.txt");
            }
            else
            {
                TB_num_init.Value = tmp_num + 1;
            }
        }

        /// <summary>
        /// 判断初始化录入框是否为空
        /// </summary>
        /// <returns></returns>
        private bool isBlank()
        {
            if (TB_action_init.Text.Trim() == "")
                return true;
            if (TB_man_init.Text.Trim() == "")
                return true;
            if (TB_thing_init.Text.Trim() == "")
                return true;
            return false;
        }

        /// <summary>
        /// TB_num_init的值发生改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_num_init_ValueChanged(object sender, EventArgs e)
        {
            
            int tmp_num = int.Parse(TB_num_init.Value.ToString());
         
            
            //显示数据
            //if (P_myRemeberData.P_man[tmp_num] != "")
            //{
                TB_man_init.Text = P_myRemeberData.P_man[tmp_num];
                TB_action_init.Text = P_myRemeberData.P_action[tmp_num];
                TB_thing_init.Text = P_myRemeberData.P_thing[tmp_num];
            //}

            
        }

        /// <summary>
        /// 【读取文件】  按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_readFile_Click(object sender, EventArgs e)
        {
            string ret = P_myRemeberData.readData("DB.txt");
            if ("OK" == ret)
            {
                int tmp_num = int.Parse(TB_num_init.Value.ToString());

                //显示数据
                if (P_myRemeberData.P_man[tmp_num] != "")
                {
                    TB_man_init.Text = P_myRemeberData.P_man[tmp_num];
                    TB_action_init.Text = P_myRemeberData.P_action[tmp_num];
                    TB_thing_init.Text = P_myRemeberData.P_thing[tmp_num];
                }
            }
        }



        //-------------------------------------------------------------------------
        //  单组训练  显示数字
        //-------------------------------------------------------------------------
        public int[] P_num_one = new int[3];
        public Random P_rd = new Random();
        public bool P_showCode_one = false;


        /// <summary>
        /// 单组训练
        /// 随机数字组合 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_randomNum_one_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                //minValue 返回的随机数的下界（随机数可取该下界值）。 
                //maxValue 返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于等于 minValue。 
                P_num_one[i] = P_rd.Next(0, 100);
            }
            Tb_Num_one.Text = P_myRemeberData.P_num[P_num_one[0]] + " " +
                P_myRemeberData.P_num[P_num_one[1]] + " " +
                P_myRemeberData.P_num[P_num_one[2]];

            //初始化显示编码按钮和编码显示框
            Tb_Code_one.Text = "";
            Btn_showCode_one.Text = "显示编码";
            P_showCode_one = false;
        }

        /// <summary>
        /// 单组训练
        /// 显示编码/隐藏编码 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_showCode_one_Click(object sender, EventArgs e)
        {
            if (!P_showCode_one)
            {
                //显示编码
                Tb_Code_one.Text =  P_myRemeberData.P_man[P_num_one[0]] + " -- " +
                                    P_myRemeberData.P_action[P_num_one[1]] + " -- " +
                                    P_myRemeberData.P_thing[P_num_one[2]];
                P_showCode_one = !P_showCode_one;
                Btn_showCode_one.Text = "隐藏编码";
            }
            else
            {
                //隐藏编码
                Tb_Code_one.Text = "";
                P_showCode_one = !P_showCode_one;
                Btn_showCode_one.Text = "显示编码";
            }
        }



        //-------------------------------------------------------------------------
        //  多组训练  显示数字
        //-------------------------------------------------------------------------

        public int[] P_num_more = new int[15];
        public bool P_showCode_more = false;

        /// <summary>
        /// 多组训练
        /// 随机数字 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_random_more_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                //minValue 返回的随机数的下界（随机数可取该下界值）。 
                //maxValue 返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于等于 minValue。 
                P_num_more[i] = P_rd.Next(0, 100);
            }

            Tb_num_more.Text = "";
            for (int i = 0; i < 5; i++)
            {
                Tb_num_more.Text += P_myRemeberData.P_num[P_num_more[i * 3]] +
                                    P_myRemeberData.P_num[P_num_more[i * 3 + 1]] +
                                    P_myRemeberData.P_num[P_num_more[i * 3 + 2]] + " ";
            }
            //tb
            // .Text = P_myRemeberData.P_num[P_num_one[0]] + " " +
            //    P_myRemeberData.P_num[P_num_one[1]] + " " +
            //    P_myRemeberData.P_num[P_num_one[2]];

                //初始化显示编码按钮和编码显示框

            Tb_code_more.Text = "";
            Btn_showCode_more.Text = "显示编码";
            P_showCode_more = false;
        }

        /// <summary>
        /// 多组训练
        /// 显示编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_showCode_more_Click(object sender, EventArgs e)
        {
            if (!P_showCode_more)
            {
                //显示编码
                Tb_code_more.Text = "";
                for (int i = 0; i < 5; i++)
                {
                    Tb_code_more.Text +=    P_myRemeberData.P_man[P_num_more[i * 3]] + "-" +
                                            P_myRemeberData.P_action[P_num_more[i * 3 + 1]] + "-" +
                                            P_myRemeberData.P_thing[P_num_more[i * 3 + 2]] + "\r\n\r\n";
                }
                P_showCode_more = !P_showCode_more;
                Btn_showCode_more.Text = "隐藏编码";
            }
            else
            {
                //隐藏编码
                Tb_code_more.Text = "";
                P_showCode_more = !P_showCode_more;
                Btn_showCode_more.Text = "显示编码";
            }
        }


        //-------------------------------------------------------------------------
        //  单组训练  显示编码
        //-------------------------------------------------------------------------
        public int[] P_numTest_one = new int[3];
        public bool P_showNum_one = false;

        /// <summary>
        /// 随机编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_randomCodeTest_one_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                //minValue 返回的随机数的下界（随机数可取该下界值）。 
                //maxValue 返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于等于 minValue。 
                P_numTest_one[i] = P_rd.Next(0, 100);
            }
            Tb_codetest_one.Text = P_myRemeberData.P_man[P_numTest_one[0]] + " -- " +
                                    P_myRemeberData.P_action[P_numTest_one[1]] + " -- " +
                                    P_myRemeberData.P_thing[P_numTest_one[2]];

            ////初始化显示数字按钮和数字显示框
            Tb_numtest_one.Text = "";
            Btn_showNumTest_one.Text = "显示数字";
            P_showNum_one = false;
        }

        /// <summary>
        /// 显示数字/隐藏数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_showNumTest_one_Click(object sender, EventArgs e)
        {
            if (!P_showNum_one)
            {
                //显示数字
                Tb_numtest_one.Text = P_myRemeberData.P_num[P_numTest_one[0]] + " " +
                                      P_myRemeberData.P_num[P_numTest_one[1]] + " " +
                                      P_myRemeberData.P_num[P_numTest_one[2]];
                P_showNum_one = !P_showNum_one;
                Btn_showNumTest_one.Text = "隐藏数字";
            }
            else
            {
                //隐藏数字
                Tb_numtest_one.Text = "";
                P_showNum_one = !P_showNum_one;
                Btn_showNumTest_one.Text = "显示编码";
            }
        }

        //-------------------------------------------------------------------------
        //  多组训练  显示编码
        //-------------------------------------------------------------------------

        public int[] P_numTest_more = new int[15];
        public bool P_showCodeTest_more = false;

        /// <summary>
        /// 随机多组编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_randomCodeTest_more_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                //minValue 返回的随机数的下界（随机数可取该下界值）。 
                //maxValue 返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于等于 minValue。 
                P_numTest_more[i] = P_rd.Next(0, 100);
            }

            Tb_randomCodeTest_more.Text = "";
            for (int i = 0; i < 5; i++)
            {
                Tb_randomCodeTest_more.Text += P_myRemeberData.P_man[P_numTest_more[i * 3]] + "-" +
                                                P_myRemeberData.P_action[P_numTest_more[i * 3 + 1]] + "-" +
                                                P_myRemeberData.P_thing[P_numTest_more[i * 3 + 2]] + "\r\n\r\n";
            }

            //初始化显示数字按钮和数字显示框
            Tb_numTest_more.Text = "";
            Btn_showCodeTest_more.Text = "显示数字";
            P_showCodeTest_more = false;
        }


        /// <summary>
        /// 显示多组数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_showCodeTest_more_Click(object sender, EventArgs e)
        {
            if (!P_showCodeTest_more)
            {
                //显示数字
                Tb_numTest_more.Text = "";
                for (int i = 0; i < 5; i++)
                {
                    Tb_numTest_more.Text += P_myRemeberData.P_num[P_numTest_more[i * 3]] +
                                            P_myRemeberData.P_num[P_numTest_more[i * 3 + 1]] +
                                            P_myRemeberData.P_num[P_numTest_more[i * 3 + 2]] + " ";
                }
                P_showCodeTest_more = !P_showCodeTest_more;
                Btn_showCodeTest_more.Text = "隐藏数字";
            }
            else
            {
                //隐藏数字
                Tb_numTest_more.Text = "";
                P_showCodeTest_more = !P_showCodeTest_more;
                Btn_showCodeTest_more.Text = "显示数字";
            }
        }



        //-------------------------------------------------------------------------
        //  测试反应时间
        //-------------------------------------------------------------------------

        /// <summary>
        /// 随机数字按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_randomNum_race_Click(object sender, EventArgs e)
        {
            TB_num1.Text = getRandom();
            TB_num2.Text = getRandom();
            TB_num3.Text = getRandom();
            TB_num4.Text = getRandom();
            TB_num5.Text = getRandom();
        }

        /// <summary>
        /// 获取一串随机数字（6*5）
        /// </summary>
        /// <returns></returns>
        public string getRandom()
        {
            int[] tmp = new int[15];
            for (int i = 0; i < 15; i++)
            {
                tmp[i] = P_rd.Next(0,100);
            }

            string ret_str = "";
            for (int i = 0; i < 5; i++)
            {
                ret_str += P_myRemeberData.P_num[tmp[i * 3]] +
                           P_myRemeberData.P_num[tmp[i * 3 + 1]] +
                           P_myRemeberData.P_num[tmp[i * 3 + 2]] + " ";
            }
            return ret_str;
        }


        private Timer P_time = new Timer();   //timer对象，当然你也可以添加timer控件。
        private Stopwatch sw; //秒表对象
        private TimeSpan ts;
        private static int P_count = 1;


        /// <summary>
        /// 添加纪录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_addRecord_Click(object sender, EventArgs e)
        {
            string[] arry = { (P_count++).ToString(), string.Format("{0}:{1}:{2}:{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds) };
            dataGridView1.Rows.Add(arry);
        }

        /// <summary>
        /// 开始/暂停 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_startStop_time_Click(object sender, EventArgs e)
        {
            sw = new Stopwatch();
            P_time.Tick += new EventHandler(time_Tick);
            P_time.Interval = 100;
            sw.Start();
            P_time.Start();
            Btn_reset_time.Enabled = true;
            Btn_stop_time.Enabled = true;
            Btn_addRecord.Enabled = true;
            Btn_stop_time.Text = "暂停";
        }

        /// <summary>
        /// 时间刷新函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void time_Tick(object sender, EventArgs e)
        {
            ts = sw.Elapsed;
            Lab_time.Text = string.Format("{0}:{1}:{2}:{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        /// <summary>
        /// 复位  按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_reset_time_Click(object sender, EventArgs e)
        {
            sw.Stop();
            P_time.Stop();
            Lab_time.Text = string.Format("{0}:{1}:{2}:{3}", 0, 0, 0, 0);
            dataGridView1.Rows.Clear();
            P_count = 1;
        }

        /// <summary>
        /// 暂停 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_stop_time_Click(object sender, EventArgs e)
        {
            if (Btn_stop_time.Text == "暂停")
            {
                sw.Stop();
                P_time.Stop();
                Btn_stop_time.Text = "继续";
            }
            else
            {
                sw.Start();
                P_time.Start();
                Btn_stop_time.Text = "暂停";
            }

        }


        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_saveRecord_Click(object sender, EventArgs e)
        {
            if (P_count <= 1)
            {
                MessageBox.Show("没有记录~！");
                return;
            }
            WriteToCSV("record_num.csv");
            MessageBox.Show("保存成功！");
        }

        /// <summary>
        /// 写入 csv文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private bool WriteToCSV(string filePath)
        {
            try
            {
                FileStream aFile = new FileStream(filePath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);

                sw.WriteLine("id,time");
                for (int i = 0; i < P_count - 1; i++)
                {
                    string strline = dataGridView1[0, i].Value + "," + dataGridView1[1, i].Value;
                    sw.WriteLine(strline);
                }
                sw.Close();
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 窗口关闭前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RememberSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.S_numSystemIsShow = false;
        }
    }
}
