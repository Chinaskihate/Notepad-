
namespace TestNET5
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton10Sec = new System.Windows.Forms.RadioButton();
            this.radioButton30Sec = new System.Windows.Forms.RadioButton();
            this.radioButtonMinute = new System.Windows.Forms.RadioButton();
            this.radioButton10Minutes = new System.Windows.Forms.RadioButton();
            this.radioButton5Minutes = new System.Windows.Forms.RadioButton();
            this.radioButton30Minutes = new System.Windows.Forms.RadioButton();
            this.groupBoxAutoSave = new System.Windows.Forms.GroupBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.backColorFormGroupBox = new System.Windows.Forms.GroupBox();
            this.backColorFormButton = new System.Windows.Forms.Button();
            this.groupBoxAutoSave.SuspendLayout();
            this.backColorFormGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton10Sec
            // 
            this.radioButton10Sec.AutoSize = true;
            this.radioButton10Sec.Location = new System.Drawing.Point(7, 39);
            this.radioButton10Sec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton10Sec.Name = "radioButton10Sec";
            this.radioButton10Sec.Size = new System.Drawing.Size(96, 24);
            this.radioButton10Sec.TabIndex = 1;
            this.radioButton10Sec.TabStop = true;
            this.radioButton10Sec.Text = "10 секунд";
            this.radioButton10Sec.UseVisualStyleBackColor = true;
            // 
            // radioButton30Sec
            // 
            this.radioButton30Sec.AutoSize = true;
            this.radioButton30Sec.Location = new System.Drawing.Point(7, 72);
            this.radioButton30Sec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton30Sec.Name = "radioButton30Sec";
            this.radioButton30Sec.Size = new System.Drawing.Size(96, 24);
            this.radioButton30Sec.TabIndex = 2;
            this.radioButton30Sec.TabStop = true;
            this.radioButton30Sec.Text = "30 секунд";
            this.radioButton30Sec.UseVisualStyleBackColor = true;
            // 
            // radioButtonMinute
            // 
            this.radioButtonMinute.AutoSize = true;
            this.radioButtonMinute.Location = new System.Drawing.Point(7, 105);
            this.radioButtonMinute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonMinute.Name = "radioButtonMinute";
            this.radioButtonMinute.Size = new System.Drawing.Size(92, 24);
            this.radioButtonMinute.TabIndex = 3;
            this.radioButtonMinute.TabStop = true;
            this.radioButtonMinute.Text = "1 минута";
            this.radioButtonMinute.UseVisualStyleBackColor = true;
            // 
            // radioButton10Minutes
            // 
            this.radioButton10Minutes.AutoSize = true;
            this.radioButton10Minutes.Location = new System.Drawing.Point(7, 172);
            this.radioButton10Minutes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton10Minutes.Name = "radioButton10Minutes";
            this.radioButton10Minutes.Size = new System.Drawing.Size(92, 24);
            this.radioButton10Minutes.TabIndex = 4;
            this.radioButton10Minutes.TabStop = true;
            this.radioButton10Minutes.Text = "10 минут";
            this.radioButton10Minutes.UseVisualStyleBackColor = true;
            // 
            // radioButton5Minutes
            // 
            this.radioButton5Minutes.AutoSize = true;
            this.radioButton5Minutes.Location = new System.Drawing.Point(7, 139);
            this.radioButton5Minutes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton5Minutes.Name = "radioButton5Minutes";
            this.radioButton5Minutes.Size = new System.Drawing.Size(84, 24);
            this.radioButton5Minutes.TabIndex = 5;
            this.radioButton5Minutes.TabStop = true;
            this.radioButton5Minutes.Text = "5 минут";
            this.radioButton5Minutes.UseVisualStyleBackColor = true;
            // 
            // radioButton30Minutes
            // 
            this.radioButton30Minutes.AutoSize = true;
            this.radioButton30Minutes.Location = new System.Drawing.Point(7, 207);
            this.radioButton30Minutes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton30Minutes.Name = "radioButton30Minutes";
            this.radioButton30Minutes.Size = new System.Drawing.Size(92, 24);
            this.radioButton30Minutes.TabIndex = 6;
            this.radioButton30Minutes.TabStop = true;
            this.radioButton30Minutes.Text = "30 минут";
            this.radioButton30Minutes.UseVisualStyleBackColor = true;
            // 
            // groupBoxAutoSave
            // 
            this.groupBoxAutoSave.Controls.Add(this.radioButtonMinute);
            this.groupBoxAutoSave.Controls.Add(this.radioButton30Minutes);
            this.groupBoxAutoSave.Controls.Add(this.radioButton10Sec);
            this.groupBoxAutoSave.Controls.Add(this.radioButton5Minutes);
            this.groupBoxAutoSave.Controls.Add(this.radioButton30Sec);
            this.groupBoxAutoSave.Controls.Add(this.radioButton10Minutes);
            this.groupBoxAutoSave.Location = new System.Drawing.Point(14, 16);
            this.groupBoxAutoSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxAutoSave.Name = "groupBoxAutoSave";
            this.groupBoxAutoSave.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxAutoSave.Size = new System.Drawing.Size(229, 339);
            this.groupBoxAutoSave.TabIndex = 7;
            this.groupBoxAutoSave.TabStop = false;
            this.groupBoxAutoSave.Text = "Частота автосохранения";
            // 
            // backColorFormGroupBox
            // 
            this.backColorFormGroupBox.Controls.Add(this.backColorFormButton);
            this.backColorFormGroupBox.Location = new System.Drawing.Point(265, 16);
            this.backColorFormGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backColorFormGroupBox.Name = "backColorFormGroupBox";
            this.backColorFormGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backColorFormGroupBox.Size = new System.Drawing.Size(147, 64);
            this.backColorFormGroupBox.TabIndex = 8;
            this.backColorFormGroupBox.TabStop = false;
            this.backColorFormGroupBox.Text = "Цвет приложения";
            // 
            // backColorFormButton
            // 
            this.backColorFormButton.Location = new System.Drawing.Point(7, 29);
            this.backColorFormButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backColorFormButton.Name = "backColorFormButton";
            this.backColorFormButton.Size = new System.Drawing.Size(86, 31);
            this.backColorFormButton.TabIndex = 0;
            this.backColorFormButton.UseVisualStyleBackColor = true;
            this.backColorFormButton.Click += new System.EventHandler(this.backColorFormButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 481);
            this.Controls.Add(this.backColorFormGroupBox);
            this.Controls.Add(this.groupBoxAutoSave);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(455, 518);
            this.Name = "Form2";
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBoxAutoSave.ResumeLayout(false);
            this.groupBoxAutoSave.PerformLayout();
            this.backColorFormGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton10Sec;
        private System.Windows.Forms.RadioButton radioButton30Sec;
        private System.Windows.Forms.RadioButton radioButtonMinute;
        private System.Windows.Forms.RadioButton radioButton10Minutes;
        private System.Windows.Forms.RadioButton radioButton5Minutes;
        private System.Windows.Forms.RadioButton radioButton30Minutes;
        private System.Windows.Forms.GroupBox groupBoxAutoSave;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox backColorFormGroupBox;
        private System.Windows.Forms.Button backColorFormButton;
    }
}