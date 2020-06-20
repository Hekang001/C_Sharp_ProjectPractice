namespace RememberSystem
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_numSystem = new System.Windows.Forms.Button();
            this.Btn_pokeSystem = new System.Windows.Forms.Button();
            this.Btn_roomSystem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_numSystem
            // 
            this.Btn_numSystem.BackColor = System.Drawing.Color.LightBlue;
            this.Btn_numSystem.Location = new System.Drawing.Point(198, 41);
            this.Btn_numSystem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Btn_numSystem.Name = "Btn_numSystem";
            this.Btn_numSystem.Size = new System.Drawing.Size(215, 47);
            this.Btn_numSystem.TabIndex = 0;
            this.Btn_numSystem.Text = "数字系统";
            this.Btn_numSystem.UseVisualStyleBackColor = false;
            this.Btn_numSystem.Click += new System.EventHandler(this.Btn_numSystem_Click);
            // 
            // Btn_pokeSystem
            // 
            this.Btn_pokeSystem.BackColor = System.Drawing.Color.LightBlue;
            this.Btn_pokeSystem.Location = new System.Drawing.Point(198, 147);
            this.Btn_pokeSystem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Btn_pokeSystem.Name = "Btn_pokeSystem";
            this.Btn_pokeSystem.Size = new System.Drawing.Size(215, 47);
            this.Btn_pokeSystem.TabIndex = 0;
            this.Btn_pokeSystem.Text = "扑克系统";
            this.Btn_pokeSystem.UseVisualStyleBackColor = false;
            this.Btn_pokeSystem.Click += new System.EventHandler(this.Btn_pokeSystem_Click);
            // 
            // Btn_roomSystem
            // 
            this.Btn_roomSystem.BackColor = System.Drawing.Color.LightBlue;
            this.Btn_roomSystem.Location = new System.Drawing.Point(198, 249);
            this.Btn_roomSystem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Btn_roomSystem.Name = "Btn_roomSystem";
            this.Btn_roomSystem.Size = new System.Drawing.Size(215, 47);
            this.Btn_roomSystem.TabIndex = 0;
            this.Btn_roomSystem.Text = "地点系统";
            this.Btn_roomSystem.UseVisualStyleBackColor = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(626, 359);
            this.Controls.Add(this.Btn_roomSystem);
            this.Controls.Add(this.Btn_pokeSystem);
            this.Controls.Add(this.Btn_numSystem);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "main";
            this.Text = "主界面";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_numSystem;
        private System.Windows.Forms.Button Btn_pokeSystem;
        private System.Windows.Forms.Button Btn_roomSystem;
    }
}

