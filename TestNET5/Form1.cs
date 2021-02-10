using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TestNET5
{
    public partial class Form1 : Form
    {
        #region
        // Количество созданных вкладок.
        private int _tabCreatedCount = 0;
        // Коллекция вкладок.
        private List<Tab> tabs = new List<Tab>();
        // Текущий RichTextBox(для удобства).
        private RichTextBox currentRichTB;
        // Является ли окно сохранения открытым(возможно костыль).
        private bool isSaveDialogOpen = false;
        #endregion

        /// <summary>
        /// Конструктор главной формы.
        /// </summary>
        public Form1()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            contextMenuStrip1.Items.AddRange(new[] { selectAllToolStripMenuItemCopy, cutToolStripMenuItemCopy, 
                copyToolStripMenuItemCopy, pasteToolStripMenuItemCopy, fontToolStripMenuItemCopy, colorToolStripMenuItemCopy });
        }

        /// <summary>
        /// Создание нового файла.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createRichTextBox();

            Tab newTab = new Tab(currentRichTB, false);
            tabs.Add(newTab);

            TabPage tabPage = new TabPage();
            newTab.Name = tabPage.Text = $"NewFile{++_tabCreatedCount}*.txt";
            newTab.IsSaved = false;
            tabControl1.TabPages.Add(tabPage);
            tabControl1.SelectedTab = tabPage;
        }

        /// <summary>
        /// Выбрать весь текст.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Обработчик событий. </param>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentRichTB.SelectAll();
        }

        /// <summary>
        /// Не успел доделать.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void codeFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Вырезать текст.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentRichTB.Cut();
        }

        /// <summary>
        /// Копировать текст.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentRichTB.Cut();
        }

        /// <summary>
        /// Вставить текст.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentRichTB.Paste();
        }

        /// <summary>
        /// Нажатие кнопки настройки.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            BackColor = Color.FromArgb(int.Parse(File.ReadAllText("BackColorForm.txt")));

            timer1.Interval = int.Parse(File.ReadAllText("AutoSaveOptions.txt"));
        }

        /// <summary>
        /// Открыть файл.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileContent = string.Empty;

            openFileDialog1.Title = "Открыть";
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Text files (*.txt;*.rtf)|*.txt; *.rtf|Code files (*.cs)|*.cs";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                    var fileStream = openFileDialog1.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            if (filePath != string.Empty)
            {
                createRichTextBox();
                if (Path.GetExtension(filePath) == ".rtf")
                    try
                    {
                        currentRichTB.LoadFile(filePath, RichTextBoxStreamType.RichText);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " Возможно .rtf файл был сломанным");
                        currentRichTB.Text = fileContent;
                    }
                else
                    currentRichTB.Text = fileContent;

                Tab newTab = new Tab(currentRichTB, true);
                newTab.FilePath = filePath;
                tabs.Add(newTab);

                TabPage tabPage = new TabPage();
                newTab.Name = tabPage.Text = filePath.Split(Path.DirectorySeparatorChar)[^1];
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage;
            }
        }

        /// <summary>
        /// Создание нового RichTextBox при открытии вкладки.
        /// </summary>
        private void createRichTextBox()
        {
            currentRichTB = new RichTextBox();
            currentRichTB.TextChanged += new EventHandler(this.CheckTextChanged);
            currentRichTB.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y + tabControl1.ItemSize.Height);
            currentRichTB.Name = "richTextBox1";
            currentRichTB.Size = new Size(tabControl1.Size.Width, tabControl1.Size.Height - tabControl1.ItemSize.Height);
            currentRichTB.TabIndex = 1;
            currentRichTB.Anchor = tabControl1.Anchor;
            currentRichTB.Text = "";
            Controls.Add(currentRichTB);
            currentRichTB.ContextMenuStrip = contextMenuStrip1;
            currentRichTB.BringToFront();
        }

        /// <summary>
        /// Проверка изменения текста(для подстановки *)
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void CheckTextChanged(object sender, EventArgs e)
        {
            string fileContent = string.Empty;
            if (tabs.Count != 0 && tabs[tabControl1.SelectedIndex].FilePath != null)
            {
                try
                {
                    fileContent = File.ReadAllText(tabs[tabControl1.SelectedIndex].FilePath);
                    if (tabs[tabControl1.SelectedIndex].RichTB.Text != fileContent && !tabs[tabControl1.SelectedIndex].Name.Contains("*"))
                    {
                        int lastIndex = tabControl1.SelectedTab.Text.LastIndexOf(".");
                        tabControl1.SelectedTab.Text = tabControl1.SelectedTab.Text[0..lastIndex] + "*." + tabControl1.SelectedTab.Text[(lastIndex + 1)..];
                        tabs[tabControl1.SelectedIndex].Name = tabControl1.SelectedTab.Text;
                        tabs[tabControl1.SelectedIndex].IsSaved = false;
                    }
                    if (tabs[tabControl1.SelectedIndex].RichTB.Text == fileContent)
                    {
                        tabControl1.SelectedTab.Text = tabControl1.SelectedTab.Text.Replace("*", string.Empty);
                        tabs[tabControl1.SelectedIndex].Name = tabControl1.SelectedTab.Text;
                        tabs[tabControl1.SelectedIndex].IsSaved = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }

        /// <summary>
        /// Закрыть вкладку.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            if (tabs.Count != 0)
            {
                Controls.Remove(tabs[index].RichTB);
                tabs.RemoveAt(index);
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }

            if (tabs.Count != 0)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[index == 0 ? 0 : index - 1];
                _tabCreatedCount--;
            }
        }

        /// <summary>
        /// Нажатие кнопки сохранить.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabs.Count != 0)
            {
                if (tabs[tabControl1.SelectedIndex].FilePath == null)
                    saveAsToolStripMenuItem.PerformClick();
                else
                {
                    try
                    {
                        if (Path.GetExtension(tabs[tabControl1.SelectedIndex].FilePath) == ".rtf")
                        {
                            tabs[tabControl1.SelectedIndex].RichTB.SaveFile(tabs[tabControl1.SelectedIndex].FilePath);
                            tabs[tabControl1.SelectedIndex].Name = tabs[tabControl1.SelectedIndex].Name.Replace("*", string.Empty);
                            tabs[tabControl1.SelectedIndex].IsSaved = true;
                        }
                        else
                        {
                            tabs[tabControl1.SelectedIndex].Save();
                            tabs[tabControl1.SelectedIndex].Name = tabs[tabControl1.SelectedIndex].Name.Replace("*", string.Empty);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
                CheckTextChanged(sender, e);
            }
        }

        /// <summary>
        /// Нажатие кнопки отмена.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentRichTB.Undo();
        }

        /// <summary>
        /// Нажатие кнопки возврат.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentRichTB.CanRedo == true)
                if (currentRichTB.RedoActionName != "Delete")
                    currentRichTB.Redo();
        }

        /// <summary>
        /// Нажатие кнопки шрифт.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabs.Count != 0)
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                    currentRichTB.SelectionFont = fontDialog1.Font;
        }

        /// <summary>
        /// Нажатие кнопки цвет.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabs.Count != 0)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    currentRichTB.SelectionColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// Нажатие кнопки сохранить как.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSaveDialogOpen && tabs.Count!=0)
            {
                saveFileDialog1.Title = "Сохранить как";
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|Rich text files (*.rtf)|*.rtf|Code files (*.cs)|*.cs";
                saveFileDialog1.FilterIndex = 2;
                isSaveDialogOpen = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.Create))
                        {
                            if (Path.GetExtension(saveFileDialog1.FileName) == ".rtf")
                                currentRichTB.SaveFile(s, RichTextBoxStreamType.RichText);
                            else
                                currentRichTB.SaveFile(s, RichTextBoxStreamType.PlainText);
                            tabs[tabControl1.SelectedIndex].FilePath = saveFileDialog1.FileName;
                            tabs[tabControl1.SelectedIndex].Name = tabControl1.SelectedTab.Text = saveFileDialog1.FileName.Split(Path.DirectorySeparatorChar)[^1];
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
                CheckTextChanged(sender, e);
                isSaveDialogOpen = false;
            }
        }

        /// <summary>
        /// Метод вызываемый при изменении вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            if (tabs.Count != 0)
            {
                currentRichTB = tabs[index].RichTB;
                currentRichTB.BringToFront();
            }
        }

        /// <summary>
        /// Метод вызываемый при закрытии формы.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isAllSaved = tabs.TrueForAll(x => x.IsSaved == true);
            string text = isAllSaved ? "Вы точно хотите выйти?" : "Остались несохранненые данные. Вы хотите их сохранить?";
            if (isAllSaved)
                if (DialogResult.Yes == MessageBox.Show(text, "Выход", MessageBoxButtons.YesNo))
                    SaveAllTabsForOpening();
                else
                    e.Cancel = true;
            else
            {
                DialogResult dialogResult = MessageBox.Show(text, "Выход", MessageBoxButtons.YesNoCancel);
                if (DialogResult.Yes == dialogResult)
                {
                    saveAllToolStripMenuItem.PerformClick();
                    SaveAllTabsForOpening();
                }
                else if (DialogResult.No == dialogResult)
                    SaveAllTabsForOpening();
                else
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Метод вызываемый при загрузке формы.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void Form1_Load(object sender, EventArgs e)
        {
            OpenSavedTabs();

            BackColor = Color.FromArgb(int.Parse(File.ReadAllText("BackColorForm.txt")));

            timer1.Interval = int.Parse(File.ReadAllText("AutoSaveOptions.txt"));
            timer1.Enabled = true;
            timer1.Start();
        }

        /// <summary>
        /// Открытие вкладок с предыдущей работы приложения.
        /// </summary>
        private void OpenSavedTabs()
        {
            try
            {
                string[] files = Directory.GetFiles("SavedTabs");

                foreach (var file in files)
                {
                    string filePath = File.ReadAllText(file);
                    string fileContent = string.Empty;
                    if (File.Exists(filePath))
                        fileContent = File.ReadAllText(filePath);
                    else
                        continue;
                    createRichTextBox();
                    if (Path.GetExtension(filePath) == ".rtf")
                        try
                        {
                            currentRichTB.LoadFile(filePath, RichTextBoxStreamType.RichText);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " Возможно .rtf файл был сломанным");
                            currentRichTB.Text = fileContent;
                        }
                    else
                        currentRichTB.Text = fileContent;

                    Tab newTab = new Tab(currentRichTB, true);
                    newTab.FilePath = filePath;
                    tabs.Add(newTab);

                    TabPage tabPage = new TabPage();
                    newTab.Name = tabPage.Text = filePath.Split(Path.DirectorySeparatorChar)[^1];
                    tabControl1.TabPages.Add(tabPage);
                    tabControl1.SelectedTab = tabPage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        /// <summary>
        /// Сохранение вкладок(их путей), для их открытия.
        /// </summary>
        private void SaveAllTabsForOpening()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo("SavedTabs");
                foreach (var file in di.GetFiles())
                    file.Delete();

                foreach (var tab in tabs)
                    if (tab.IsSaved)
                        File.WriteAllText($"SavedTabs{Path.DirectorySeparatorChar}{tab.Name}", tab.FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        /// <summary>
        /// Метод вызываемый при тике таймера.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            saveAllToolStripMenuItem.PerformClick();
        }

        /// <summary>
        /// Сохранение всех вкладок.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[i];
                saveToolStripMenuItem.PerformClick();
            }
        }

        /// <summary>
        /// Открыть новое окно.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void openWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender"> Отправитель. </param>
        /// <param name="e"> Аргумент событий. </param>
        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
