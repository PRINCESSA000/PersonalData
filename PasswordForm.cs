using Guna.UI2.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PD
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            filePath = Path.Combine(appDirectory, fileName);
        }

        string fileName = "data_password.json"; // Название вашего JSON файла
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private string filePath;

        private void PasswordForm_Load(object sender, EventArgs e)
        {
            CreateExistingPass();
        }

        private PasswordAddForm passwordAddForm;
        private PasswordChangeForm passwordChangeForm;
        Panel newPanel;
        Guna2Button newButton;

        public void NewPassword(string name)
        {
            newPanel = new Panel();
            newPanel.Size = new Size(0, 42);
            panelWithPass.Controls.Add(newPanel);
            newPanel.Dock = DockStyle.Top;

            newButton = new Guna2Button();
            newButton.Size = new Size(0, 40);
            newButton.FillColor = Color.FromArgb(31, 31, 31);
            newButton.BorderThickness = 2;
            newButton.BorderColor = Color.FromArgb(56, 56, 56);
            newButton.ForeColor = Color.White;
            newButton.BorderRadius = 10;
            newButton.Text = name;
            newButton.Font = new Font("Calibri", 16, FontStyle.Bold);
            newButton.HoverState.ForeColor = Color.White;
            newButton.Click += new EventHandler(ActivePass_Click);
            newPanel.Controls.Add(newButton);
            newButton.Dock = DockStyle.Top;
        }

        public void DeletePass()
        {
            this.Controls.Remove(panelToRemove); // Удаляем плашку с паролем
            panelToRemove.Dispose(); // Освобождаем ресурсы панели
        }

        Guna2Button clickedButton;
        string clickedButText;
        Panel panelToRemove;
        private void ActivePass_Click(object sender, EventArgs e)
        {
            clickedButton = sender as Guna2Button;
            panelToRemove = (Panel)clickedButton.Parent;
            if (panel3.Controls.Contains(passwordChangeForm))
            {
                if (clickedButton.Text != clickedButText)
                {
                    clickedButText = clickedButton.Text;
                    passwordChangeForm.NameText(clickedButText);
                }
            }
            else
            {
                clickedButText = clickedButton.Text;
                passwordChangeForm = new PasswordChangeForm(this);
                passwordChangeForm.TopLevel = false;
                passwordChangeForm.Dock = DockStyle.Fill;
                passwordChangeForm.NameText(clickedButText);
                panel3.Controls.Add(passwordChangeForm);
                passwordChangeForm.BringToFront();
                passwordChangeForm.Show();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (panel3.Controls.Contains(passwordAddForm))
            {
                return;
            }
            else
            {
                passwordAddForm = new PasswordAddForm(this);
                passwordAddForm.TopLevel = false;
                panel3.Controls.Add(passwordAddForm);
                passwordAddForm.Dock = DockStyle.Fill;
                passwordAddForm.BringToFront();
                passwordAddForm.Show();
            }
        }

        public void ChangeNameBut(string nameBut)
        {
            clickedButton.Text = nameBut;
        }

        private void CreateExistingPass()
        {
            string json = File.ReadAllText(filePath);
            List<JsonDataPass> data = JsonConvert.DeserializeObject<List<JsonDataPass>>(json);
            foreach (var valuePass in data)
            {
                NewPassword(valuePass.Name);
            }
        }
    }
}
