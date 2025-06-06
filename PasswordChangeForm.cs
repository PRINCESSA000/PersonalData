using Guna.UI2.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PD.JsonDataPass;

namespace PD
{
    public partial class PasswordChangeForm : Form
    {
        private readonly PasswordForm _passwordForm;
        public PasswordChangeForm(PasswordForm passwordForm)
        {
            InitializeComponent();
            filePath = Path.Combine(appDirectory, fileName);
            _passwordForm = passwordForm;
        }
        string fileName = "data_password.json"; // Название вашего JSON файла
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private string filePath;

        private void PasswordChangeForm_Load(object sender, EventArgs e)
        {
            CheckEnabledChangeBut();
        }

        string firstName;
        private void DeleteData()
        {
            // Чтение данных из файла
            string json = File.ReadAllText(filePath);
            List<JsonDataPass> data = JsonConvert.DeserializeObject<List<JsonDataPass>>(json);

            // Удаление пользователя с указанным Id
            JsonDataPass dataToRemove = data.Find(u => u.Name == firstName);
            if (dataToRemove != null)
            {
                data.Remove(dataToRemove);

                // Сохранение обновленных данных обратно в файл
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
            else
            {
                MessageBox.Show("Пароль не найден.");
            }
        }

        string firstLogin;
        string firstPass;
        string firstNote;
        private void PasteData()
        {
            // Чтение данных из файла
            string json = File.ReadAllText(filePath);
            List<JsonDataPass> data = JsonConvert.DeserializeObject<List<JsonDataPass>>(json);

            JsonDataPass dataToPaste = data.Find(u => u.Name == firstName);
            if (dataToPaste != null)
            {
                guna2TextBox1.Text = dataToPaste.Name;
                guna2TextBox2.Text = dataToPaste.Login;
                guna2TextBox3.Text = dataToPaste.Password;
                guna2TextBox4.Text = dataToPaste.Note;
                firstLogin = guna2TextBox2.Text;
                firstPass = guna2TextBox3.Text;
                firstNote = guna2TextBox4.Text;
            }
            else
            {
                MessageBox.Show("Не удалось найти пароль");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void NameText(string nameText)
        {
            firstName = nameText;
            PasteData();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы уверены, что хотите удалить эти данные?");
            _passwordForm.DeletePass();
            DeleteData();
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            _passwordForm.ChangeNameBut(guna2TextBox1.Text);
            UpdateData();
            this.Close();
        }

        private void UpdateData()
        {
            string json = File.ReadAllText(filePath);
            List<JsonDataPass> data = JsonConvert.DeserializeObject<List<JsonDataPass>>(json);

            JsonDataPass dataToUpdate = data.Find(u => u.Name == firstName);
            if (dataToUpdate != null)
            {
                dataToUpdate.Name = guna2TextBox1.Text;
                dataToUpdate.Login = guna2TextBox2.Text;
                dataToUpdate.Password = guna2TextBox3.Text;
                dataToUpdate.Note = guna2TextBox4.Text;

                // Сохранение обновленных данных обратно в файл
                string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
            else
            {
                MessageBox.Show("Пароль не найден.");
            }
        }

        private async void CheckEnabledChangeBut()
        {
            while (true)
            {
                if (firstName != guna2TextBox1.Text.Trim() || firstLogin != guna2TextBox2.Text.Trim() || firstPass != guna2TextBox3.Text.Trim() || firstNote != guna2TextBox4.Text.Trim())
                {
                    guna2Button3.Enabled = true;
                }
                else { guna2Button3.Enabled = false; }

                await Task.Delay(100);
            }
        }
    }
}
