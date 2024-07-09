using System;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using JakondaNoteJ2K.Core;
using JakondaNoteJ2K;
using System.Drawing;
using JakondaNoteJ2K.Properties;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Drawing.Printing;


namespace JakondaNote
{
    public partial class MainFormj2k : Form
    {
        private string _fileName;

        private TextBox textBox;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
       
        private int currentSearchIndex = 0;
        private List<int> searchWordIndices = new List<int>();

        private string currentFilePath = null;
        private bool isFileModified = false;

        private SettingsForm settingsForm;

        public MainFormj2k()
        {
           
            settingsForm = new SettingsForm(this.LineNumberTextBox);

            InitializeComponent();
            InitializeStatusStrip();
          
                SettingsKeyboard.Initialize(LineNumberTextBox);
          
          
        
        

    }
      
        private void ApplySettings()
        {
            LineNumberTextBox.Font = Settings.Default.Font;
            LineNumberTextBox.ForeColor = Settings.Default.ForeColor;
            LineNumberTextBox.BackColor = Settings.Default.BackColor;
        }

        private void MainFormj2k_Load(object sender, EventArgs e)
        {
            ApplySettings();
        }
       
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }



        private void InitializeStatusStrip()
        {
            this.statusStrip = new StatusStrip();
            this.toolStripStatusLabel = new ToolStripStatusLabel();

            this.statusStrip.Items.Add(this.toolStripStatusLabel);
            this.Controls.Add(this.statusStrip);
        }
        // Обработчик события MouseDown


        private void createFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|J2K files (*.j2k)|*.j2k|All files (*.*)|*.*";
            saveFileDialog.Title = "Create File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Предполагаем, что у вас есть доступ к LineNumberTextBox через переменную lineNumberTextBox.
                    string contentToSave = LineNumberTextBox.Text;
                    LineNumberTextBox.Focus();

                    // Создание файла с выбранным расширением и запись текста в файл
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        if (saveFileDialog.FileName.EndsWith(".j2k"))
                        {
                            // Шифрование текста перед записью в файл
                            string encryptedContent = EncryptString(contentToSave);
                            writer.Write(encryptedContent);
                        }
                        else
                        {
                            // Для других расширений (*.txt, *.*) записываем текст без шифрования
                            writer.Write(contentToSave);
                        }
                    }

                    // Обновляем заголовок формы с именем сохраненного файла
                    this.Text = $"JakondaNote - {System.IO.Path.GetFileName(saveFileDialog.FileName)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving the file: " + ex.Message);
                }
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|J2K files (*.j2k)|*.j2k|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileContent;
                        if (openFileDialog.FileName.EndsWith(".j2k"))
                        {
                            // Читаем содержимое файла и расшифровываем его
                            string encryptedContent = File.ReadAllText(openFileDialog.FileName);
                            fileContent = DecryptString(encryptedContent);
                        }
                        else
                        {
                            // Для других расширений (*.txt, *.*) читаем текст без расшифровки
                            fileContent = File.ReadAllText(openFileDialog.FileName);
                        }

                        // Предполагаем, что у вас есть доступ к LineNumberTextBox через переменную lineNumberTextBox.
                        LineNumberTextBox.Text = fileContent;

                        // Обновляем заголовок формы с именем открытого файла
                        this.Text = $"JakondaNote - {System.IO.Path.GetFileName(openFileDialog.FileName)}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening the file: " + ex.Message);
                    }
                }
            }
        }




        private void SaveFile_Click(object sender, EventArgs e)
        {
            
        }


        private void LineNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            isFileModified = true;
        }


        private string EncryptString(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;

                // Генерируем случайный ключ и вектор инициализации
                aes.GenerateKey();
                aes.GenerateIV();

                // Шифруем данные
                byte[] encryptedBytes;
                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                }

                // Конвертируем зашифрованные данные в строку
                string cipherText = Convert.ToBase64String(encryptedBytes);

                // Возвращаем зашифрованную строку вместе с ключом и вектором инициализации
                return $"{cipherText}|{Convert.ToBase64String(aes.Key)}|{Convert.ToBase64String(aes.IV)}";
            }
        }

        private string DecryptString(string cipherText)
        {
            // Разделяем зашифрованный текст, ключ и вектор инициализации
            string[] parts = cipherText.Split('|');
            string encryptedText = parts[0];
            byte[] key = Convert.FromBase64String(parts[1]);
            byte[] iv = Convert.FromBase64String(parts[2]);

            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;

                // Расшифровываем данные
                byte[] decryptedBytes;
                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                }

                // Конвертируем расшифрованные данные в строку
                string plainText = Encoding.UTF8.GetString(decryptedBytes);
                return plainText;
            }
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new Form();
            aboutForm.Size = new Size(400, 380);
            aboutForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            aboutForm.MaximizeBox = false;
            aboutForm.MinimizeBox = false;
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.Text = "About the program";

            // Создаем PictureBox для отображения фотографии
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(200, 180);
            pictureBox.Location = new Point(aboutForm.Width / 2 - pictureBox.Width / 2, 50);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Формируем путь к изображению
            string imagePath = Path.Combine(Application.StartupPath, "info.jpeg");

            try
            {
                // Попытаемся загрузить фотографию
                pictureBox.Image = Image.FromFile(imagePath);
            }
            catch (System.IO.FileNotFoundException)
            {
                // Если файл не найден, используем стандартное изображение
                
            }

            // Создаем Label для текста
            Label aboutLabel = new Label();
            aboutLabel.AutoSize = true;
            aboutLabel.Text = "JakondaNoteJ2K is your reliable text editor\n" +
                              "Create, edit and securely store your documents\n" +
                              "Developed in 2024 by the Jake(Twiks228)\n " +
                              "Contact: Jakej2k@yandex.ru ";
            aboutLabel.Location = new Point(80, 240);
            aboutLabel.ForeColor = Color.Black; // Устанавливаем черный цвет текста

           

           
          

            aboutForm.Controls.Add(pictureBox);
            aboutForm.Controls.Add(aboutLabel);

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(aboutForm.Width / 2 - okButton.Width / 2, 300);
            aboutForm.Controls.Add(okButton);
            aboutForm.AcceptButton = okButton;

            aboutForm.ShowDialog();
        }





        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Показываем диалоговое окно для ввода искомого слова
            string searchWord = Microsoft.VisualBasic.Interaction.InputBox("Enter a search word:", "Search", "", -1, -1);

            if (!string.IsNullOrEmpty(searchWord))
            {
                // Получаем текущий текст из текстового блокнота
                string currentText = this.LineNumberTextBox.Text;

                // Сохраняем начальные позиции выделения
                int selectionStart = this.LineNumberTextBox.SelectionStart;
                int selectionLength = this.LineNumberTextBox.SelectionLength;

                // Ищем все вхождения слова в тексте
                searchWordIndices.Clear();
                int startIndex = 0;
                int wordIndex = currentText.IndexOf(searchWord, startIndex, StringComparison.OrdinalIgnoreCase);
                while (wordIndex != -1)
                {
                    searchWordIndices.Add(wordIndex);
                    startIndex = wordIndex + searchWord.Length;
                    wordIndex = currentText.IndexOf(searchWord, startIndex, StringComparison.OrdinalIgnoreCase);
                }

                // Если есть найденные вхождения
                if (searchWordIndices.Count > 0)
                {
                    // Выделяем все вхождения
                    this.LineNumberTextBox.SelectionStart = 0;
                    this.LineNumberTextBox.SelectionLength = 0;
                    foreach (int index in searchWordIndices)
                    {
                        this.LineNumberTextBox.Select(index, searchWord.Length);
                        this.LineNumberTextBox.SelectionBackColor = this.LineNumberTextBox.SelectionBackColor;
                        this.LineNumberTextBox.SelectionForeColor = this.LineNumberTextBox.SelectionForeColor;
                        System.Threading.Thread.Sleep(1000); // Ждём 1 секунду, чтобы выделение было более заметным
                        this.LineNumberTextBox.SelectionStart = 0;
                        this.LineNumberTextBox.SelectionLength = 0;
                    }

                    // Сохраняем индекс текущего вхождения
                    currentSearchIndex = 0;
                }
                else
                {
                    MessageBox.Show("The word was not found in the text.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Восстанавливаем предыдущее выделение
                this.LineNumberTextBox.SelectionStart = selectionStart;
                this.LineNumberTextBox.SelectionLength = selectionLength;

                // Возвращаем фокус на текстовый блокнот
                this.LineNumberTextBox.Focus();
            }
        }

        private void nextSearchResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searchWordIndices.Count > 0)
            {
                // Переходим к следующему вхождению
                currentSearchIndex = (currentSearchIndex + 1) % searchWordIndices.Count;

                // Выделяем текущее вхождение
                this.LineNumberTextBox.SelectionStart = searchWordIndices[currentSearchIndex];
                this.LineNumberTextBox.SelectionLength = this.LineNumberTextBox.Text.Substring(searchWordIndices[currentSearchIndex]).IndexOf(" ");
                this.LineNumberTextBox.SelectionBackColor = this.LineNumberTextBox.SelectionBackColor;
                this.LineNumberTextBox.SelectionForeColor = this.LineNumberTextBox.SelectionForeColor;

                // Ждём 1 секунду, чтобы выделение было более заметным
                System.Threading.Thread.Sleep(1000);

                // Сбрасываем выделение
                this.LineNumberTextBox.SelectionStart = 0;
                this.LineNumberTextBox.SelectionLength = 0;

                // Возвращаем фокус на текстовый блокнот
                this.LineNumberTextBox.Focus();
            }
        }



   







        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Создаем экземпляр формы настроек и передаем в нее экземпляр LineNumberTextBox
            settingsForm.ShowDialog();
            ApplySettings();


         
        }


        

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаем объект класса PrintDocument
            PrintDocument printDoc = new PrintDocument();

            // Подписываемся на событие PrintPage
            printDoc.PrintPage += PrintDoc_PrintPage;

            // Создаем объект класса PrintDialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            // Показываем диалоговое окно печати
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Запускаем процесс печати
                printDoc.Print();
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Получаем текст из richTextBox1
            string text = LineNumberTextBox.Text;

            // Устанавливаем шрифт и цвет для печати
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            // Печатаем текст на странице
            e.Graphics.DrawString(text, font, brush, 20, 20);

            // Указываем, что страница напечатана
            e.HasMorePages = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Закрывает приложение
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, есть ли уже открытый файл
                if (!string.IsNullOrEmpty(this.FileName))
                {
                    // Если файл уже открыт, то перезаписываем его содержимое
                    File.WriteAllText(this.FileName, this.LineNumberTextBox.Text);
                }
                else
                {
                    // Если файл не открыт, то запрашиваем имя файла у пользователя
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|J2K files (*.j2k)|*.j2k|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = ".j2k";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Обновляем заголовок формы с именем сохраненного файла
                        this.Text = $"JakondaNote - {System.IO.Path.GetFileName(saveFileDialog.FileName)}";
                        // Сохраняем содержимое текстового поля в новый файл
                        File.WriteAllText(saveFileDialog.FileName, this.LineNumberTextBox.Text);
                        this.FileName = saveFileDialog.FileName;
                    }
                }
            }

            catch (Exception ex)
            {
                // Обрабатываем ошибки, которые могут возникнуть при записи в файл
                MessageBox.Show($"Error saving the file: {ex.Message}");
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|J2K files (*.j2k)|*.j2k|All files (*.*)|*.*";
            saveFileDialog.Title = "Create File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Предполагаем, что у вас есть доступ к LineNumberTextBox через переменную lineNumberTextBox.
                    string contentToSave = LineNumberTextBox.Text;
                    LineNumberTextBox.Focus();

                    // Создание файла с выбранным расширением и запись текста в файл
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        if (saveFileDialog.FileName.EndsWith(".j2k"))
                        {
                            // Шифрование текста перед записью в файл
                            string encryptedContent = EncryptString(contentToSave);
                            writer.Write(encryptedContent);
                        }
                        else
                        {
                            // Для других расширений (*.txt, *.*) записываем текст без шифрования
                            writer.Write(contentToSave);
                        }
                    }

                    // Обновляем заголовок формы с именем сохраненного файла
                    this.Text = $"JakondaNote - {System.IO.Path.GetFileName(saveFileDialog.FileName)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving the file: " + ex.Message);
                }
            }
        }







        // Другие методы и обработчики событий
    }
}
