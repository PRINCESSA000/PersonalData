using Guna.UI2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace PD
{
    public partial class NotesAddForm : Form
    {
        private readonly NotesForm _notesForm;
        public NotesAddForm(NotesForm notesForm)
        {
            InitializeComponent();
            filePath = Path.Combine(appDirectory, fileName);
            _notesForm = notesForm;

            // Проверка существования JSON-файла при запуске
            if (!File.Exists(filePath))
            {
                // Если файл не существует, создаем его с пустым содержимым
                File.WriteAllText(filePath, JsonConvert.SerializeObject(new List<string>()));
            }
        }

        string fileName = "data_notes.json"; // Название вашего JSON файла
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private string filePath;

        private void NotesAddForm_Load(object sender, EventArgs e)
        {
            CheckString();
        }

        private string DateCreate()
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

        private void SaveDataPass()
        {
            List<JsonDataNotes> getData;
            var data = new JsonDataNotes
            {
                Title = guna2TextBox1.Text,
                Description = guna2TextBox2.Text,
                Create = DateCreate(),
                LastChanged = DateCreate()
            };

            string jsonSaved = File.ReadAllText(filePath); //записываем имеющиеся данные
            getData = JsonConvert.DeserializeObject<List<JsonDataNotes>>(jsonSaved); //Сохраняем в листе имеющиеся данные
            getData.Add(data); //Добавляем новые данные
            string json = JsonConvert.SerializeObject(getData, Formatting.Indented);

            File.WriteAllText(fileName, json);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            _notesForm.NewPassword(guna2TextBox1.Text);
            SaveDataPass();
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void CheckString()
        {
            while (true)
            {
                if (guna2TextBox1.Text.Trim() == "")
                {
                    guna2Button1.Enabled = false;
                }
                else { guna2Button1.Enabled = true; }

                await Task.Delay(100);
            }
        }
    }
}
