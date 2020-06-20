using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RememberSystem.From;

namespace RememberSystem
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        public static bool S_numSystemIsShow = false;
        public static bool S_pokeSystemIsShow = false;
        public static bool S_roomSystemIsShow = false;
        public RememberSystem P_myRememberSystem;//数字系统
        public PokeSystem P_myPokeSystem;//扑克系统


        /// <summary>
        /// 数字系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_numSystem_Click(object sender, EventArgs e)
        {
            if (!S_numSystemIsShow)
            {
                S_numSystemIsShow = true;
                P_myRememberSystem = new RememberSystem();
                P_myRememberSystem.Show();
            }
            else
            { 
            }
        }

        /// <summary>
        /// 扑克系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_pokeSystem_Click(object sender, EventArgs e)
        {
            if (!S_pokeSystemIsShow)
            {
                S_pokeSystemIsShow = true;
                P_myPokeSystem = new PokeSystem();
                P_myPokeSystem.Show();
            }
            else
            { }
        }
    }
}
