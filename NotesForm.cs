using Guna.UI2.WinForms;
using Newtonsoft.Json;
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
    public partial class NotesForm : Form
    {
        public NotesForm()
        {
            InitializeComponent();
            filePath = Path.Combine(appDirectory, fileName);
        }

        string fileName = "data_notes.json"; // Название вашего JSON файла
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private string filePath;

        private void NotesForm_Load(object sender, EventArgs e)
        {
            CreateExistingNotes();
        }

        private NotesAddForm notesAddForm;
        private NotesChangeForm notesChangeForm;
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
            newButton.Click += new EventHandler(ActiveNote_Click);
            newPanel.Controls.Add(newButton);
            newButton.Dock = DockStyle.Top;
        }

        Guna2Button clickedButton;
        string clickedButText;
        Panel panelToRemove;
        private void ActiveNote_Click(object sender, EventArgs e)
        {
            clickedButton = sender as Guna2Button;
            panelToRemove = (Panel)clickedButton.Parent;
            if (panel3.Controls.Contains(notesChangeForm))
            {
                if (clickedButton.Text != clickedButText)
                {
                    clickedButText = clickedButton.Text;
                    notesChangeForm.NameText(clickedButText);
                }
            }
            else
            {
                clickedButText = clickedButton.Text;
                notesChangeForm = new NotesChangeForm(this);
                notesChangeForm.TopLevel = false;
                notesChangeForm.Dock = DockStyle.Fill;
                notesChangeForm.NameText(clickedButText);
                panel3.Controls.Add(notesChangeForm);
                notesChangeForm.BringToFront();
                notesChangeForm.Show();
            }
        }

        public void DeleteNotes()
        {
            this.Controls.Remove(panelToRemove); // Удаляем плашку с паролем
            panelToRemove.Dispose(); // Освобождаем ресурсы панели
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (panel3.Controls.Contains(notesAddForm))
            {
                return;
            }
            else
            {
                notesAddForm = new NotesAddForm(this);
                notesAddForm.TopLevel = false;
                panel3.Controls.Add(notesAddForm);
                notesAddForm.Dock = DockStyle.Fill;
                notesAddForm.BringToFront();
                notesAddForm.Show();
            }
        }
        public void ChangeNameBut(string nameBut)
        {
            clickedButton.Text = nameBut;
        }

        private void CreateExistingNotes()
        {
            string json = File.ReadAllText(filePath);
            List<JsonDataNotes> data = JsonConvert.DeserializeObject<List<JsonDataNotes>>(json);
            foreach (var valuePass in data)
            {
                NewPassword(valuePass.Title);
            }
        }
    }
}
