namespace _2._1._32
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
            this.InputN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectionSortRadio = new System.Windows.Forms.RadioButton();
            this.insertionSortRadio = new System.Windows.Forms.RadioButton();
            this.shellSortRadio = new System.Windows.Forms.RadioButton();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "N:";
            // 
            // InputN
            // 
            this.InputN.Location = new System.Drawing.Point(91, 53);
            this.InputN.Name = "InputN";
            this.InputN.Size = new System.Drawing.Size(100, 44);
            this.InputN.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(232, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "绘图";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shellSortRadio);
            this.groupBox1.Controls.Add(this.selectionSortRadio);
            this.groupBox1.Controls.Add(this.insertionSortRadio);
            this.groupBox1.Location = new System.Drawing.Point(46, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 206);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "排序算法";
            // 
            // selectionSortRadio
            // 
            this.selectionSortRadio.AutoSize = true;
            this.selectionSortRadio.Location = new System.Drawing.Point(16, 54);
            this.selectionSortRadio.Name = "selectionSortRadio";
            this.selectionSortRadio.Size = new System.Drawing.Size(152, 40);
            this.selectionSortRadio.TabIndex = 4;
            this.selectionSortRadio.TabStop = true;
            this.selectionSortRadio.Text = "选择排序";
            this.selectionSortRadio.UseVisualStyleBackColor = true;
            // 
            // insertionSortRadio
            // 
            this.insertionSortRadio.AutoSize = true;
            this.insertionSortRadio.Location = new System.Drawing.Point(16, 100);
            this.insertionSortRadio.Name = "insertionSortRadio";
            this.insertionSortRadio.Size = new System.Drawing.Size(152, 40);
            this.insertionSortRadio.TabIndex = 5;
            this.insertionSortRadio.TabStop = true;
            this.insertionSortRadio.Text = "插入排序";
            this.insertionSortRadio.UseVisualStyleBackColor = true;
            // 
            // shellSortRadio
            // 
            this.shellSortRadio.AutoSize = true;
            this.shellSortRadio.Location = new System.Drawing.Point(16, 146);
            this.shellSortRadio.Name = "shellSortRadio";
            this.shellSortRadio.Size = new System.Drawing.Size(152, 40);
            this.shellSortRadio.TabIndex = 6;
            this.shellSortRadio.TabStop = true;
            this.shellSortRadio.Text = "希尔排序";
            this.shellSortRadio.UseVisualStyleBackColor = true;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(46, 112);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 36);
            this.ErrorLabel.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(460, 392);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputN);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.Text = "2.1.32";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton shellSortRadio;
        private System.Windows.Forms.RadioButton selectionSortRadio;
        private System.Windows.Forms.RadioButton insertionSortRadio;
        private System.Windows.Forms.Label ErrorLabel;
    }
}

