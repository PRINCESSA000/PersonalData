using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PD
{
    public partial class NotesChangeForm : Form
    {
        private readonly NotesForm _notesForm;
        public NotesChangeForm(NotesForm notesForm)
        {
            InitializeComponent();
            _notesForm = notesForm;
            filePath = Path.Combine(appDirectory, fileName);
        }

        string fileName = "data_notes.json"; // Название вашего JSON файла
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private string filePath;

        private void NotesChangeForm_Load(object sender, EventArgs e)
        {
            CheckEnabledChangeBut();
        }

        private void DeleteData()
        {
            // Чтение данных из файла
            string json = File.ReadAllText(filePath);
            List<JsonDataNotes> data = JsonConvert.DeserializeObject<List<JsonDataNotes>>(json);

            // Удаление пользователя с указанным Id
            JsonDataNotes dataToRemove = data.Find(u => u.Title == firstTitle);
            if (dataToRemove != null)
            {
                data.Remove(dataToRemove);

                // Сохранение обновленных данных обратно в файл
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
            else
            {
                MessageBox.Show("Заметка не найдена");
            }
        }

        private void PasteData()
        {
            // Чтение данных из файла
            string json = File.ReadAllText(filePath);
            List<JsonDataNotes> data = JsonConvert.DeserializeObject<List<JsonDataNotes>>(json);

            JsonDataNotes dataToPaste = data.Find(u => u.Title == firstTitle);
            if (dataToPaste != null)
            {
                guna2TextBox1.Text = dataToPaste.Title;
                guna2TextBox2.Text = dataToPaste.Description;
                label3.Text = dataToPaste.Create;
                label4.Text = dataToPaste.LastChanged;
                firstDesc = guna2TextBox2.Text;
            }
            else
            {
                MessageBox.Show("Не удалось найти заметку");
            }
        }
        string firstTitle;
        string firstDesc;

        public void NameText(string nameText)
        {
            firstTitle = nameText;
            PasteData();
        }

        private void UpdateData()
        {
            string json = File.ReadAllText(filePath);
            List<JsonDataNotes> data = JsonConvert.DeserializeObject<List<JsonDataNotes>>(json);

            JsonDataNotes dataToUpdate = data.Find(u => u.Title == firstTitle);
            if (dataToUpdate != null)
            {
                dataToUpdate.Title = guna2TextBox1.Text;
                dataToUpdate.Description = guna2TextBox2.Text;
                dataToUpdate.LastChanged = UpdateDate();

                // Сохранение обновленных данных обратно в файл
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
            else
            {
                MessageBox.Show("Заметка не найдена");
            }
        }

        private string UpdateDate()
        {
            string output;
            string[] lines;
            Process date = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c chcp 65001 & date /t",
                RedirectStandardOutput = true, // Перенаправляем вывод
                UseShellExecute = false, // Не использовать оболочку Windows
                CreateNoWindow = true, // Не создавать окно
            });
            try
            {
                output = date.StandardOutput.ReadToEnd();

                lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(line => line.Trim()).ToArray();

                if (lines.Length >= 1)
                {
                    return lines[1];
                }
                else
                {
                    return "Чёт пошло не так";
                }
            }
            catch (Exception ex)
            {
                return "Ошибка: " + ex.Message;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            _notesForm.ChangeNameBut(guna2TextBox1.Text);
            UpdateData();
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы уверены, что хотите удалить эти данные?");
            _notesForm.DeleteNotes();
            DeleteData();
            this.Close();
        }

        private async void CheckEnabledChangeBut()
        {
            while (true)
            {
                if (firstTitle != guna2TextBox1.Text.Trim() || firstDesc != guna2TextBox2.Text.Trim())
                {
                    guna2Button1.Enabled = true;
                }
                else { guna2Button1.Enabled = false; }

                await Task.Delay(100);
            }
        }
    }
}
