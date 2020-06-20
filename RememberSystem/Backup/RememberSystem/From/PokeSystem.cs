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

namespace RememberSystem.From
{
    public partial class PokeSystem : Form
    {
        public PokeSystem()
        {
            InitializeComponent();
            P_pokeSystem = new PokeData();
            pictureBox_one_init.Image = P_pokeSystem.P_pokeImage[0];
            init_PBGroup_poke();
            init_PBGroup_code();
            init_54Poke();
        }

        public PokeData P_pokeSystem;


        //---------------------------------------------------------
        //   初始化
        //---------------------------------------------------------

        /// <summary>
        /// 录入程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_loadin_init_Click(object sender, EventArgs e)
        {
            int num = int.Parse(TB_pokeNum.Value.ToString());
            if (isBlank())
            {
                return;
            }
            P_pokeSystem.insert_pokeData(   TB_man_poke_init.Text.Trim(),
                                            TB_action_poke_init.Text.Trim(),
                                            num );

            //如果已经到顶了
            if (54 == num)
            {
                //写入文件
                DialogResult dr = MessageBox.Show("是否要写入文件？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    string rtn = P_pokeSystem.writeToFile("pokeData.txt");
                    if ("OK" == rtn)
                        MessageBox.Show("保存成功");
                    else
                        MessageBox.Show("保存失败！ " + rtn);
                }
            }
            else
            {
                TB_pokeNum.Value = num + 1;
            }
        }

        /// <summary>
        /// 判断编辑框是否为空
        /// </summary>
        /// <returns></returns>
        private bool isBlank()
        {
            if (TB_action_poke_init.Text.Trim() == "")
                return true;
            if (TB_man_poke_init.Text.Trim() == "")
                return true;
            return false;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_readfile_init_Click(object sender, EventArgs e)
        {
            string rnt = P_pokeSystem.readFile("pokeData.txt");
            if ("OK" == rnt)
            {
                MessageBox.Show("读取成功！");

                int tmp_num = int.Parse(TB_pokeNum.Value.ToString());
                //显示数据
                if (P_pokeSystem.P_man[tmp_num-1] != "")
                {
                    TB_man_poke_init.Text = P_pokeSystem.P_man[tmp_num-1];
                    TB_action_poke_init.Text = P_pokeSystem.P_action[tmp_num - 1];
                    pictureBox_one_init.Image = P_pokeSystem.P_pokeImage[tmp_num - 1];
                }
            }
            else
            {
                MessageBox.Show("读取失败！" + rnt);
            }
        }


        /// <summary>
        /// 值发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_pokeNum_ValueChanged(object sender, EventArgs e)
        {
            int num = int.Parse(TB_pokeNum.Value.ToString());
            TB_man_poke_init.Text = P_pokeSystem.P_man[num - 1];
            TB_action_poke_init.Text = P_pokeSystem.P_action[num - 1];
            pictureBox_one_init.Image = P_pokeSystem.P_pokeImage[num - 1];
        }


        //---------------------------------------------------------
        //   随机扑克 （单组）
        //---------------------------------------------------------
        public Random P_myRd = new Random();
        public int P_currentNum_poke = 0;
        public bool isShowPokeCode = false;

        /// <summary>
        /// 随机扑克
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_codeToPoke_random_one_Click(object sender, EventArgs e)
        {
            P_currentNum_poke = P_myRd.Next(0, 54);
            PB_codeToPoke_one.Image = P_pokeSystem.P_pokeImage[P_currentNum_poke];

            isShowPokeCode = false;
            TB_codeToPoke_man_one.Text = "";
            TB_codeToPoke_action_one.Text = "";
            BTN_codeToPoke_show_one.Text = "显示编码";
        }

        /// <summary>
        /// 显示编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_codeToPoke_show_one_Click(object sender, EventArgs e)
        {
            if (!isShowPokeCode)
            {
                isShowPokeCode = !isShowPokeCode;
                TB_codeToPoke_man_one.Text = P_pokeSystem.P_man[P_currentNum_poke];
                TB_codeToPoke_action_one.Text = P_pokeSystem.P_action[P_currentNum_poke];
                BTN_codeToPoke_show_one.Text = "隐藏编码";
            }
            else
            {
                isShowPokeCode = !isShowPokeCode;
                TB_codeToPoke_man_one.Text = "";
                TB_codeToPoke_action_one.Text = "";
                BTN_codeToPoke_show_one.Text = "显示编码";
            }
        }


        //---------------------------------------------------------
        //   随机编码 （单组）
        //---------------------------------------------------------

        public int P_currentNum_code = 0;
        public bool isShowCodePoke = false;

        /// <summary>
        /// 随机编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_PokeTocode_randomCode_one_Click(object sender, EventArgs e)
        {
            P_currentNum_code = P_myRd.Next(0,54);
            TB_PokeTocode_man_one.Text = P_pokeSystem.P_man[P_currentNum_code];
            TB_PokeTocode_action_one.Text = P_pokeSystem.P_action[P_currentNum_code];

            isShowCodePoke = false;
            TB_PokeTocode_showPoke_one.Text = "显示扑克";
            PB_PokeTocode_one.Image = null;
        }

        /// <summary>
        /// 显示扑克
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_PokeTocode_showPoke_one_Click(object sender, EventArgs e)
        {
            if (!isShowCodePoke)
            {
                isShowCodePoke = !isShowCodePoke;
                TB_PokeTocode_showPoke_one.Text = "隐藏扑克";
                PB_PokeTocode_one.Image = P_pokeSystem.P_pokeImage[P_currentNum_code];
            }
            else
            {
                isShowCodePoke = !isShowCodePoke;
                TB_PokeTocode_showPoke_one.Text = "显示扑克";
                PB_PokeTocode_one.Image = null;
            }
        }


        //---------------------------------------------------------
        //   随机扑克 (多组)
        //---------------------------------------------------------

        public PictureBox[] P_PBGroup_poke = new PictureBox[12];
        public TextBox[] P_TBGroup_poke = new TextBox[6];
        public int[] P_numGroup_poke = new int[12];
        public bool is_ShowCode_more = false;

        /// <summary>
        /// 随机图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_randomPoke_more_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                P_numGroup_poke[i] = P_myRd.Next(0,54);
                P_PBGroup_poke[i].Image = P_pokeSystem.P_pokeImage[P_numGroup_poke[i]];
            }
            //PB_code1_more.Image = P_pokeSystem.P_pokeImage[0];

            is_ShowCode_more = false;
            Btn_showCode_more.Text = "显示编码";
            for (int i = 0; i < 6; i++)
            {
                P_TBGroup_poke[i].Text = "";
            }

        }

        /// <summary>
        /// 初始化PictureBox
        /// </summary>
        private void init_PBGroup_poke()
        {
           // P_PBGroup_poke = new PictureBox[12];
            P_PBGroup_poke[0] = PB_code1_more;
            P_PBGroup_poke[1] = PB_code2_more;
            P_PBGroup_poke[2] = PB_code3_more;
            P_PBGroup_poke[3] = PB_code4_more;
            P_PBGroup_poke[4] = PB_code5_more;
            P_PBGroup_poke[5] = PB_code6_more;
            P_PBGroup_poke[6] = PB_code7_more;
            P_PBGroup_poke[7] = PB_code8_more;
            P_PBGroup_poke[8] = PB_code9_more;
            P_PBGroup_poke[9] = PB_code10_more;
            P_PBGroup_poke[10] = PB_code11_more;
            P_PBGroup_poke[11] = PB_code12_more;


           // P_TBGroup_poke = new TextBox[6];
            P_TBGroup_poke[0] = textBox1;
            P_TBGroup_poke[1] = textBox2;
            P_TBGroup_poke[2] = textBox3;
            P_TBGroup_poke[3] = textBox4;
            P_TBGroup_poke[4] = textBox5;
            P_TBGroup_poke[5] = textBox6;

        }

        /// <summary>
        /// 显示编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_showCode_more_Click(object sender, EventArgs e)
        {
            if (!is_ShowCode_more)
            {
                is_ShowCode_more = !is_ShowCode_more;
                Btn_showCode_more.Text = "隐藏编码";
                for (int i = 0; i < 6; i++)
                {
                    P_TBGroup_poke[i].Text = P_pokeSystem.P_man[P_numGroup_poke[2*i]] + "-" +
                                             P_pokeSystem.P_action[P_numGroup_poke[2*i+1]];
                }
            }
            else
            {
                is_ShowCode_more = !is_ShowCode_more;
                Btn_showCode_more.Text = "显示编码";
                for (int i = 0; i < 6; i++)
                {
                    P_TBGroup_poke[i].Text = "";
                }
            }
        }


        //---------------------------------------------------------
        //   随机编码 (多组)
        //---------------------------------------------------------

        public PictureBox[] P_PBGroup_code = new PictureBox[12];
        public TextBox[] P_TBGroup_code = new TextBox[6];
        public int[] P_numGroup_code = new int[12];
        public bool is_ShowPoke_more = false;

        /// <summary>
        /// 随机编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_randomCode_more_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                P_numGroup_code[i] = P_myRd.Next(0, 54);
            }

            for (int i = 0; i < 6; i++)
            {
                P_TBGroup_code[i].Text = P_pokeSystem.P_man[P_numGroup_code[i * 2]] + "-" +
                                         P_pokeSystem.P_action[P_numGroup_code[i * 2 + 1]];
            }

            is_ShowPoke_more = false;
            BTN_showPoke_more.Text = "显示扑克";
            for (int i = 0; i < 12; i++)
            {
                P_PBGroup_code[i].Image = null;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init_PBGroup_code()
        {
           // P_PBGroup_code = new PictureBox[12];
            P_PBGroup_code[0] = pictureBox_1;
            P_PBGroup_code[1] = pictureBox_2;
            P_PBGroup_code[2] = pictureBox_3;
            P_PBGroup_code[3] = pictureBox_4;
            P_PBGroup_code[4] = pictureBox_5;
            P_PBGroup_code[5] = pictureBox_6;
            P_PBGroup_code[6] = pictureBox_7;
            P_PBGroup_code[7] = pictureBox_8;
            P_PBGroup_code[8] = pictureBox_9;
            P_PBGroup_code[9] = pictureBox_10;
            P_PBGroup_code[10] = pictureBox_11;
            P_PBGroup_code[11] = pictureBox_12;

           // P_TBGroup_code = new TextBox[6];
            P_TBGroup_code[0] = textBox_1;
            P_TBGroup_code[1] = textBox_2;
            P_TBGroup_code[2] = textBox_3;
            P_TBGroup_code[3] = textBox_4;
            P_TBGroup_code[4] = textBox_5;
            P_TBGroup_code[5] = textBox_6;
        }


        /// <summary>
        /// 显示扑克
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_showPoke_more_Click(object sender, EventArgs e)
        {
            if (!is_ShowPoke_more)
            {
                is_ShowPoke_more = !is_ShowPoke_more;
                BTN_showPoke_more.Text = "隐藏扑克";
                for (int i = 0; i < 12; i++)
                {
                    P_PBGroup_code[i].Image = P_pokeSystem.P_pokeImage[P_numGroup_code[i]];
                }
            }
            else
            {
                is_ShowPoke_more = !is_ShowPoke_more;
                BTN_showPoke_more.Text = "显示扑克";
                for (int i = 0; i < 12; i++)
                {
                    P_PBGroup_code[i].Image = null;
                }
            }
        }


        //---------------------------------------------------------
        //   计时训练
        //---------------------------------------------------------

        public PictureBox[] P_PBGroup_54Poke = new PictureBox[54];
        public int[] P_numGroup_54Poke = new int[54];

        /// <summary>
        /// 随机54张扑克
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_random_54Poke_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 300; i++ )
            {
                int a = P_myRd.Next(0,54);
                int b = P_myRd.Next(0,54);
                if (a == b)
                    continue;

                int tmp = P_numGroup_54Poke[a];
                P_numGroup_54Poke[a] = P_numGroup_54Poke[b];
                P_numGroup_54Poke[b] = tmp;
            }

            for (int i = 0; i < 54; i++)
            {
                P_PBGroup_54Poke[i].Image = P_pokeSystem.P_pokeImage[P_numGroup_54Poke[i]];
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init_54Poke()
        {
            for (int i = 0; i < 54; i++)
            {
                P_numGroup_54Poke[i] = i;
            }

            P_PBGroup_54Poke[0] = pictureBox1;
            P_PBGroup_54Poke[1] = pictureBox2;
            P_PBGroup_54Poke[2] = pictureBox3;
            P_PBGroup_54Poke[3] = pictureBox4;
            P_PBGroup_54Poke[4] = pictureBox5;
            P_PBGroup_54Poke[5] = pictureBox6;
            P_PBGroup_54Poke[6] = pictureBox7;
            P_PBGroup_54Poke[7] = pictureBox8;
            P_PBGroup_54Poke[8] = pictureBox9;
            P_PBGroup_54Poke[9] = pictureBox10;
            P_PBGroup_54Poke[10] = pictureBox11;
            P_PBGroup_54Poke[11] = pictureBox12;
            P_PBGroup_54Poke[12] = pictureBox13;
            P_PBGroup_54Poke[13] = pictureBox14;
            P_PBGroup_54Poke[14] = pictureBox15;
            P_PBGroup_54Poke[15] = pictureBox16;
            P_PBGroup_54Poke[16] = pictureBox17;
            P_PBGroup_54Poke[17] = pictureBox18;
            P_PBGroup_54Poke[18] = pictureBox19;
            P_PBGroup_54Poke[19] = pictureBox20;
            P_PBGroup_54Poke[20] = pictureBox21;
            P_PBGroup_54Poke[21] = pictureBox22;
            P_PBGroup_54Poke[22] = pictureBox23;
            P_PBGroup_54Poke[23] = pictureBox24;
            P_PBGroup_54Poke[24] = pictureBox25;
            P_PBGroup_54Poke[25] = pictureBox26;
            P_PBGroup_54Poke[26] = pictureBox27;
            P_PBGroup_54Poke[27] = pictureBox28;
            P_PBGroup_54Poke[28] = pictureBox29;
            P_PBGroup_54Poke[29] = pictureBox30;
            P_PBGroup_54Poke[30] = pictureBox31;
            P_PBGroup_54Poke[31] = pictureBox32;
            P_PBGroup_54Poke[32] = pictureBox33;
            P_PBGroup_54Poke[33] = pictureBox34;
            P_PBGroup_54Poke[34] = pictureBox35;
            P_PBGroup_54Poke[35] = pictureBox36;
            P_PBGroup_54Poke[36] = pictureBox37;
            P_PBGroup_54Poke[37] = pictureBox38;
            P_PBGroup_54Poke[38] = pictureBox39;
            P_PBGroup_54Poke[39] = pictureBox40;
            P_PBGroup_54Poke[40] = pictureBox41;
            P_PBGroup_54Poke[41] = pictureBox42;
            P_PBGroup_54Poke[42] = pictureBox43;
            P_PBGroup_54Poke[43] = pictureBox44;
            P_PBGroup_54Poke[44] = pictureBox45;
            P_PBGroup_54Poke[45] = pictureBox46;
            P_PBGroup_54Poke[46] = pictureBox47;
            P_PBGroup_54Poke[47] = pictureBox48;
            P_PBGroup_54Poke[48] = pictureBox49;
            P_PBGroup_54Poke[49] = pictureBox50;
            P_PBGroup_54Poke[50] = pictureBox51;
            P_PBGroup_54Poke[51] = pictureBox52;
            P_PBGroup_54Poke[52] = pictureBox53;
            P_PBGroup_54Poke[53] = pictureBox54;
        }


        private Timer P_time = new Timer();   //timer对象，当然你也可以添加timer控件。
        private Stopwatch sw; //秒表对象
        private TimeSpan ts;
        private static int P_count = 1;

        /// <summary>
        /// 开始计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_start_time_Click(object sender, EventArgs e)
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
        /// 暂停/继续
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
        /// 清空记录
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
        /// 添加一条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_addRecord_Click(object sender, EventArgs e)
        {
            string[] arry = { (P_count++).ToString(), string.Format("{0}:{1}:{2}:{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds) };
            dataGridView1.Rows.Add(arry);
        }

        /// <summary>
        /// 保存文件
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
            WriteToCSV("record_poke.csv");
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
        private void PokeSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("窗口要关闭了！！");
            main.S_pokeSystemIsShow = false;
        }

    }
}
