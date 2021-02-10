using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TestNET5
{
    public partial class Form2 : Form
    {
        // Интервал таймера.
        private int _timerInterval = 30000;
        
        /// <summary>
        /// Конструктор формы с настройками.
        /// </summary>
        public Form2()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
        }

        /// <summary>
        /// Свойство определяющее интервал таймера.
        /// </summary>
        public int TimerInterval
        {
            get => _timerInterval;

            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Недопустимое значение времени.");

                _timerInterval = value;
            }
        }

        /// <summary>
        /// Подгрузка настроек формы с файла.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void Form2_Load(object sender, EventArgs e)
        {
            backColorFormButton.BackColor = Color.FromArgb(int.Parse(File.ReadAllText("BackColorForm.txt")));
            int interval = int.Parse(File.ReadAllText("AutoSaveOptions.txt"));

            if (interval == 10 * 1000)
            {
                radioButton10Sec.PerformClick();
            }

            if (interval == 30 * 1000)
            {
                radioButton30Sec.PerformClick();
            }

            if (interval == 60 * 1000)
            {
                radioButtonMinute.PerformClick();
            }

            if (interval == 5 * 60 * 1000)
            {
                radioButton5Minutes.PerformClick();
            }

            if (interval == 10 * 60 * 1000)
            {
                radioButton10Minutes.PerformClick();
            }

            if (interval == 30 * 60 * 1000)
            {
                radioButton30Minutes.PerformClick();
            }
        }

        /// <summary>
        /// Передача настроек в файл.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргументы событий. </param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (radioButton10Sec.Checked)
            {
                TimerInterval = 10 * 1000;
            }

            if (radioButton30Sec.Checked)
            {
                TimerInterval = 30 * 1000;
            }

            if (radioButtonMinute.Checked)
            {
                TimerInterval = 60 * 1000;
            }

            if (radioButton5Minutes.Checked)
            {
                TimerInterval = 5 * 60 * 1000;
            }

            if (radioButton10Minutes.Checked)
            {
                TimerInterval = 10 * 60 * 1000;
            }

            if (radioButton30Minutes.Checked)
            {
                TimerInterval = 30 * 60 * 1000;
            }

            File.WriteAllText("AutoSaveOptions.txt", TimerInterval.ToString());
        }

        /// <summary>
        /// Изменение цвета формы.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void backColorFormButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                backColorFormButton.BackColor = colorDialog1.Color;
            }

            File.WriteAllText("BackColorForm.txt", backColorFormButton.BackColor.ToArgb().ToString());
        }
    }
}
