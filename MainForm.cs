using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace PD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //Нужно чтобы открывать формы по кнопке
        private readonly FinanceForm financeForm = new FinanceForm();
        private readonly PasswordForm passwordForm = new PasswordForm();
        private readonly NotesForm notesForm = new NotesForm();
        private readonly PCForm pcForm = new PCForm();

        //Для перетаскивания формы
        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;

        //Глобальные цвета. Активная кнопка
        private readonly Color activeBgColor = Color.FromArgb(44, 44, 44);
        //Глобальные цвета. Дефолтной кнопки
        private readonly Color defaultBgColor = Color.FromArgb(31, 31, 31);
        
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void SetButtonColors(IconButton but, Color backColor)
        {
            but.BackColor = backColor;
        }

        Form activeForm = null;
        private void ShowForm(Form childForm)
        {
            if (activeForm == null && childForm == this)
            {
                return;
            }

            if (activeForm != null && childForm == this)
            {
                activeForm.Hide();
                return;
            }

            if (activeForm != null)
            {
                activeForm.Hide();
            }
            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            centerWindow.Controls.Add(childForm);
            childForm.Dock = DockStyle.Fill;
            //centerWindow.Controls.Clear();
            childForm.Show();
            childForm.BringToFront();

            //childForm.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            //Устанавливаем цвет активной кнопки
            IconButton activeBut = (IconButton)sender;
            SetButtonColors(activeBut, activeBgColor);
            //Сбрасывем у других
            SetButtonColors(financeButton, defaultBgColor);
            SetButtonColors(passwordButton, defaultBgColor);
            SetButtonColors(notesButton, defaultBgColor);
            SetButtonColors(pcButton, defaultBgColor);

            ShowForm(this);
        }

        private void financeButton_Click(object sender, EventArgs e)
        {
            //Устанавливаем цвет активной кнопки
            IconButton activeBut = (IconButton)sender;
            SetButtonColors(activeBut, activeBgColor);
            //Сбрасывем у других
            SetButtonColors(mainButton, defaultBgColor);
            SetButtonColors(passwordButton, defaultBgColor);
            SetButtonColors(notesButton, defaultBgColor);
            SetButtonColors(pcButton, defaultBgColor);

            ShowForm(financeForm);
        }

        private void passwordButton_Click(object sender, EventArgs e)
        {
            //Устанавливаем цвет активной кнопки
            IconButton activeBut = (IconButton)sender;
            SetButtonColors(activeBut, activeBgColor);
            //Сбрасывем у других
            SetButtonColors(mainButton, defaultBgColor);
            SetButtonColors(financeButton, defaultBgColor);
            SetButtonColors(notesButton, defaultBgColor);
            SetButtonColors(pcButton, defaultBgColor);

            ShowForm(passwordForm);
        }

        private void notesButton_Click(object sender, EventArgs e)
        {
            //Устанавливаем цвет активной кнопки
            IconButton activeBut = (IconButton)sender;
            SetButtonColors(activeBut, activeBgColor);
            //Сбрасывем у других
            SetButtonColors(mainButton, defaultBgColor);
            SetButtonColors(financeButton, defaultBgColor);
            SetButtonColors(passwordButton, defaultBgColor);
            SetButtonColors(pcButton, defaultBgColor);

            ShowForm(notesForm);
        }

        private void pcButton_Click(object sender, EventArgs e)
        {
            //Устанавливаем цвет активной кнопки
            IconButton activeBut = (IconButton)sender;
            SetButtonColors(activeBut, activeBgColor);
            //Сбрасывем у других
            SetButtonColors(mainButton, defaultBgColor);
            SetButtonColors(financeButton, defaultBgColor);
            SetButtonColors(passwordButton, defaultBgColor);
            SetButtonColors(notesButton, defaultBgColor);

            ShowForm(pcForm);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
    }
}
