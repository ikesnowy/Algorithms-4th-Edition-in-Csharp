namespace _2._5._26
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.InputX = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.InputY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // InputX
            // 
            this.InputX.Location = new System.Drawing.Point(99, 96);
            this.InputX.Name = "InputX";
            this.InputX.Size = new System.Drawing.Size(100, 44);
            this.InputX.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 58);
            this.button1.TabIndex = 3;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(54, 173);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 36);
            this.ErrorLabel.TabIndex = 3;
            // 
            // InputY
            // 
            this.InputY.Location = new System.Drawing.Point(328, 96);
            this.InputY.Name = "InputY";
            this.InputY.Size = new System.Drawing.Size(100, 44);
            this.InputY.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(643, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 58);
            this.button2.TabIndex = 5;
            this.button2.Text = "添加随机点";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(896, 236);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.InputY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputX);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.Text = "2.5.26";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.TextBox InputY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

