using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PD
{
    public partial class PCForm : Form
    {
        public PCForm()
        {
            InitializeComponent();
            LoadInfo();
            ButCopyCreate();
        }

        private void PCForm_Load(object sender, EventArgs e)
        {
            
        }

        List<IconButton> buttons = new List<IconButton>();
        private void ButCopyCreate()
        {
            for (int i = 0; i < 7; i++)
            {
                IconButton iconButton = new IconButton();
                iconButton.Size = new Size(25, 25);
                //iconButton.Location = new Point(25, 25);
                iconButton.IconColor = Color.FromArgb(31, 31, 31);
                iconButton.BackColor = Color.Transparent;
                iconButton.IconChar = IconChar.Copy;
                iconButton.IconSize = 25;
                iconButton.FlatStyle = FlatStyle.Flat;
                iconButton.FlatAppearance.BorderSize = 0;
                iconButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                iconButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
                iconButton.Cursor = Cursors.Hand;
                iconButton.MouseDown += Button_MouseDown;
                iconButton.MouseUp += Button_MouseUp;
                iconButton.MouseEnter += IconButton_MouseEnter;
                iconButton.MouseLeave += IconButton_MouseLeave;
                iconButton.Click += IconButton_CopyClick;
                panel1.Controls.Add(iconButton);
                buttons.Add(iconButton);
            }
            int x, y;
            int w;
            x = label12.Location.X;
            y = label12.Location.Y;
            w = label12.Width;
            buttons[0].Location = new Point(x + w, y);

            x = label13.Location.X;
            y = label13.Location.Y;
            w = label13.Width;
            buttons[1].Location = new Point(x + w, y);

            x = label14.Location.X;
            y = label14.Location.Y;
            w = label14.Width;
            buttons[2].Location = new Point(x + w, y);

            x = label15.Location.X;
            y = label15.Location.Y;
            w = label15.Width;
            buttons[3].Location = new Point(x + w, y);

            x = label16.Location.X;
            y = label16.Location.Y;
            w = label16.Width;
            buttons[4].Location = new Point(x + w, y);

            buttons[5].Visible = false;

            x = label18.Location.X;
            y = label18.Location.Y;
            w = label18.Width;
            buttons[6].Location = new Point(x + w, y);
        }

        private void IconButton_CopyClick(object sender, EventArgs e)
        {
            if (sender is IconButton button)
            {
                if (button == buttons[0]) { Clipboard.SetText(label12.Text); }
                else if (button == buttons[1]) { Clipboard.SetText(label13.Text); }
                else if (button == buttons[2]) { Clipboard.SetText(label14.Text); }
                else if (button == buttons[3]) { Clipboard.SetText(label15.Text); }
                else if (button == buttons[4]) { Clipboard.SetText(label16.Text); }
                else if (button == buttons[5]) { Clipboard.SetText(label20.Text); }
                else if (button == buttons[6]) { Clipboard.SetText(label18.Text); }
            }
        }

        private void IconButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is IconButton button)
            {
                button.IconColor = Color.FromArgb(31, 31, 31);
            }
        }

        private void IconButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is IconButton button)
            {
                button.IconColor = Color.FromArgb(56, 56, 56);
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is IconButton button)
            {
                button.IconColor = Color.FromArgb(31, 31, 31);
            }
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is IconButton button)
            {
                button.IconColor = Color.FromArgb(56, 56, 56);
            }
        }

        private void ShowIpInfo()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) // IPv4
                {
                    output = ip.ToString();
                }
            }
            label20.Text = output;
            output = null;
        }
        int x = 0;
        int xForBut = 0;
        private void label21_Click(object sender, EventArgs e)
        {
            if (label21.Text == "Показать")
            {
                label21.Text = "Скрыть";
                ShowIpInfo();
                x = label20.Width;
                label21.Location = new Point(label21.Location.X + x, label21.Location.Y);

                xForBut = label21.Size.Width;
                buttons[5].Visible = true;
                buttons[5].Location = new Point(label21.Location.X + xForBut, label21.Location.Y);
            }
            else if (label21.Text == "Скрыть")
            {
                label21.Text = "Показать";
                label21.Location = new Point(label21.Location.X - x, label21.Location.Y);
                label20.Text = "";

                buttons[5].Visible = false;
            }
        }

        string output;
        string[] lines;
        string temp = null;
        int tempINT = 0;

        private string Cmd(string arguments)
        {
            Process cmd = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = arguments,
                RedirectStandardOutput = true, // Перенаправляем вывод
                UseShellExecute = false, // Не использовать оболочку Windows
                CreateNoWindow = true, // Не создавать окно
            });
            return cmd.StandardOutput.ReadToEnd();
        }

        private void LoadInfo()
        {
            // ищем ОС
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            
            try
            {
                foreach (ManagementObject os in searcher.Get())
                {
                    if (os["Name"].ToString().Contains('|'))
                    {
                        temp = os["Name"].ToString().Substring(0, os["Name"].ToString().IndexOf("|"));
                    }
                }
                label12.Text = $"{temp} ({(Environment.Is64BitOperatingSystem ? "x64" : "x32")})";
            }
            catch (Exception)
            {
                label12.Text = "Чёт пошло не так";
            }
            temp = null;


            // ищем мать
            /*Process mother = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c chcp 65001 & wmic baseboard get product,Manufacturer",
                RedirectStandardOutput = true, // Перенаправляем вывод
                UseShellExecute = false, // Не использовать оболочку Windows
                CreateNoWindow = true, // Не создавать окно
            });*/
            try
            {
                //output = mother.StandardOutput.ReadToEnd();
                output = Cmd("/c chcp 65001 & wmic baseboard get product, Manufacturer");

                lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(line => line.Trim()).ToArray();

                if (lines.Length > 1)
                {
                    label13.Text = lines[2];
                }
                else
                {
                    label13.Text = "Чёт пошло не так";
                }
            }
            catch (Exception)
            {
                label13.Text = "Чёт пошло не так";
            }
            output = null;
            lines = new string[0];


            // ищем процессор
            /*Process processor = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c chcp 65001 & wmic cpu get name",
                RedirectStandardOutput = true, // Перенаправляем вывод
                UseShellExecute = false, // Не использовать оболочку Windows
                CreateNoWindow = true, // Не создавать окно
            });*/
            try
            {
                output = Cmd("/c chcp 65001 & wmic cpu get name");

                lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(line => line.Trim()).ToArray();

                if (lines.Length > 1)
                {
                    label14.Text = lines[2];
                }
                else
                {
                    label14.Text = "Чёт пошло не так";
                }
            }
            catch (Exception)
            {
                label14.Text = "Чёт пошло не так";
            }
            output = null;
            lines = new string[0];


            // ищем видеокарту
            /*Process vc = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c chcp 65001 & wmic path win32_VideoController get name",
                RedirectStandardOutput = true, // Перенаправляем вывод
                UseShellExecute = false, // Не использовать оболочку Windows
                CreateNoWindow = true, // Не создавать окно
            });*/
            try
            {
                output = Cmd("/c chcp 65001 & wmic path win32_VideoController get name");

                lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(line => line.Trim()).ToArray();

                if (lines.Length > 1)
                {
                    label15.Text = lines[2];
                }
                else
                {
                    label15.Text = "Чёт пошло не так";
                }
            }
            catch (Exception)
            {
                label15.Text = "Чёт пошло не так";
            }
            output = null;
            lines = new string[0];


            // монитор
            DEVMODE dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));

            if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref dm) != 0)
            {
                label16.Text = $"{dm.dmDisplayFrequency}Гц ({dm.dmPelsWidth}x{dm.dmPelsHeight})";
            }
            else
            {
                label16.Text = "Не удалось получить информацию о дисплее.";
            }

            // ОЗУ
            /*Process ozy = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c chcp 65001 & systeminfo",
                RedirectStandardOutput = true, // Перенаправляем вывод
                UseShellExecute = false, // Не использовать оболочку Windows
                CreateNoWindow = true, // Не создавать окно
            });*/
            try
            {
                output = Cmd("/c chcp 65001 & systeminfo");

                lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                var outputs = lines.Where(line => line.Contains("Total Physical Memory")).Select(line => line.Trim()).ToList();

                if (outputs.Count > 0)
                {
                    temp = string.Join(Environment.NewLine, outputs).Replace("Total Physical Memory:", string.Empty).Trim();
                    label17.Text = (Convert.ToInt32(new string(temp.Where(t => char.IsDigit(t)).ToArray())) / 1000).ToString() + " ГБ";
                }
                else
                {
                    label17.Text = "Чёт пошло не так";
                }
            }
            catch (Exception)
            {
                label17.Text = "Чёт пошло не так";
            }
            temp = null;
            output = null;
            lines = new string[0];

            // Хранение данных

            // Создаем StringBuilder для формирования текста
            StringBuilder sb = new StringBuilder();

            // Получаем информацию о всех логических дисках
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Перебираем диски и собираем информацию
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady) // Проверяем, готов ли диск
                {
                    sb.AppendLine($"{drive.Name} {drive.TotalSize / (1024 * 1024 * 1024)} ГБ (Свободно: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ)");
                }
            }
            label18.Text = sb.ToString();
        }

        // Структура для получения информации о видеодисплее
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            public const int CCHDEVICENAME = 0x20;
            public const int CCHFORMNAME = 0x20;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency; // Частота обновления
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        // Импортируем необходимые WinAPI функции
        [DllImport("user32.dll")]
        private static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        private const int ENUM_CURRENT_SETTINGS = -1;
    }
}
