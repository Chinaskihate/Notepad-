using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace TestNET5
{
    class Tab
    {
        // Не успел реализовать для журналирования.
        private List<string> LastData = new List<string>();

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="rTB"> Элемент RichTextBox. </param>
        /// <param name="isLoaded"> Является ли файл подгруженным. </param>
        public Tab(RichTextBox rTB, bool isLoaded)
        {
            RichTB = rTB;
            IsSaved = isLoaded;
        }

        /// <summary>
        /// Свойство с названием вкладки.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство отвечающее за то, является ли файл сохранным.
        /// </summary>
        public bool IsSaved { get; set; }

        /// <summary>
        /// К каждой вкладке привязан свой RichTextBox.
        /// </summary>
        public RichTextBox RichTB { get; set; }

        /// <summary>
        /// Сохранение содержимого вкладки.
        /// </summary>
        public void Save()
        {
            if (FilePath == null)
                throw new NullReferenceException("Отсутсвует путь сохранения");

            if (Path.GetExtension(FilePath) == ".txt")
                RichTB.SaveFile(FilePath, RichTextBoxStreamType.PlainText);
            else
                RichTB.SaveFile(FilePath, RichTextBoxStreamType.RichText);

            IsSaved = true;
            Name = Name.Replace("*",string.Empty);
        }

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public string FilePath { get; set; }
    }
}
