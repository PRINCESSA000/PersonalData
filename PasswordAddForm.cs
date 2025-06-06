using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static PD.JsonDataPass;
using Formatting = Newtonsoft.Json.Formatting;

namespace PD
{
    public partial class PasswordAddForm : Form
    {
        readonly PasswordForm _passwordForm;

        public PasswordAddForm(PasswordForm passwordForm)
        {
            InitializeComponent();

            _passwordForm = passwordForm;

            filePath = Path.Combine(appDirectory, fileName);

            // Проверка существования JSON-файла при запуске
            if (!File.Exists(filePath))
            {
                // Если файл не существует, создаем его с пустым содержимым
                File.WriteAllText(filePath, JsonConvert.SerializeObject(new List<string>()));
            }
        }

        private void PasswordAddForm_Load(object sender, EventArgs e)
        {
            CheckString();
        }

        private string filePath;

        // Получаем путь к директории приложения
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Задаем имя файла для сохранения
        string fileName = "data_password.json"; // Название вашего JSON файла

        private async void CheckString()
        {
            while (true) 
            {
                if (guna2TextBox1.Text.Trim() == "" || guna2TextBox2.Text.Trim() == "" || guna2TextBox3.Text.Trim() == "")
                {
                    guna2Button1.Enabled = false;
                }
                else { guna2Button1.Enabled = true; }

                await Task.Delay(100);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            _passwordForm.NewPassword(guna2TextBox1.Text);
            SaveDataPass();
            this.Close();
        }

        private void SaveDataPass()
        {
            List<JsonDataPass> getData;
            var data = new JsonDataPass
            {
                Name = guna2TextBox1.Text,
                Login = guna2TextBox2.Text,
                Password = guna2TextBox3.Text,
                Note = guna2TextBox4.Text
            };

            string jsonSaved = File.ReadAllText(filePath); //записываем имеющиеся данные
            getData = JsonConvert.DeserializeObject<List<JsonDataPass>>(jsonSaved); //Сохраняем в листе имеющиеся данные
            getData.Add(data); //Добавляем новые данные
            string json = JsonConvert.SerializeObject(getData, Formatting.Indented);

            File.WriteAllText(fileName, json);
        }
    }
}
