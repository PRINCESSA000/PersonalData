namespace PD
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcButton = new FontAwesome.Sharp.IconButton();
            this.passwordButton = new FontAwesome.Sharp.IconButton();
            this.financeButton = new FontAwesome.Sharp.IconButton();
            this.mainButton = new FontAwesome.Sharp.IconButton();
            this.centerWindow = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.notesButton = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.centerWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.HasFormShadow = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.iconButton3);
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 30);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // iconButton3
            // 
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.Language;
            this.iconButton3.IconColor = System.Drawing.Color.White;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 40;
            this.iconButton3.Location = new System.Drawing.Point(880, 0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(40, 30);
            this.iconButton3.TabIndex = 2;
            this.iconButton3.UseVisualStyleBackColor = true;
            // 
            // iconButton2
            // 
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 25;
            this.iconButton2.Location = new System.Drawing.Point(920, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(40, 30);
            this.iconButton2.TabIndex = 1;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.X;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 25;
            this.iconButton1.Location = new System.Drawing.Point(960, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(40, 30);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel2.Controls.Add(this.notesButton);
            this.panel2.Controls.Add(this.pcButton);
            this.panel2.Controls.Add(this.passwordButton);
            this.panel2.Controls.Add(this.financeButton);
            this.panel2.Controls.Add(this.mainButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 470);
            this.panel2.TabIndex = 1;
            // 
            // pcButton
            // 
            this.pcButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcButton.FlatAppearance.BorderSize = 0;
            this.pcButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pcButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pcButton.ForeColor = System.Drawing.Color.White;
            this.pcButton.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.pcButton.IconColor = System.Drawing.Color.White;
            this.pcButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pcButton.IconSize = 25;
            this.pcButton.Location = new System.Drawing.Point(0, 430);
            this.pcButton.Name = "pcButton";
            this.pcButton.Size = new System.Drawing.Size(175, 40);
            this.pcButton.TabIndex = 4;
            this.pcButton.Text = "Системная информация";
            this.pcButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.pcButton.UseVisualStyleBackColor = true;
            this.pcButton.Click += new System.EventHandler(this.pcButton_Click);
            // 
            // passwordButton
            // 
            this.passwordButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordButton.FlatAppearance.BorderSize = 0;
            this.passwordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passwordButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordButton.ForeColor = System.Drawing.Color.White;
            this.passwordButton.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.passwordButton.IconColor = System.Drawing.Color.White;
            this.passwordButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.passwordButton.IconSize = 25;
            this.passwordButton.Location = new System.Drawing.Point(0, 80);
            this.passwordButton.Name = "passwordButton";
            this.passwordButton.Size = new System.Drawing.Size(175, 40);
            this.passwordButton.TabIndex = 2;
            this.passwordButton.Text = "Пароли";
            this.passwordButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.passwordButton.UseVisualStyleBackColor = true;
            this.passwordButton.Click += new System.EventHandler(this.passwordButton_Click);
            // 
            // financeButton
            // 
            this.financeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.financeButton.FlatAppearance.BorderSize = 0;
            this.financeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.financeButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.financeButton.ForeColor = System.Drawing.Color.White;
            this.financeButton.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckDollar;
            this.financeButton.IconColor = System.Drawing.Color.White;
            this.financeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.financeButton.IconSize = 25;
            this.financeButton.Location = new System.Drawing.Point(0, 40);
            this.financeButton.Name = "financeButton";
            this.financeButton.Size = new System.Drawing.Size(175, 40);
            this.financeButton.TabIndex = 1;
            this.financeButton.Text = "Финансы";
            this.financeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.financeButton.UseVisualStyleBackColor = true;
            this.financeButton.Click += new System.EventHandler(this.financeButton_Click);
            // 
            // mainButton
            // 
            this.mainButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.mainButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainButton.FlatAppearance.BorderSize = 0;
            this.mainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainButton.ForeColor = System.Drawing.Color.White;
            this.mainButton.IconChar = FontAwesome.Sharp.IconChar.House;
            this.mainButton.IconColor = System.Drawing.Color.White;
            this.mainButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.mainButton.IconSize = 25;
            this.mainButton.Location = new System.Drawing.Point(0, 0);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(175, 40);
            this.mainButton.TabIndex = 0;
            this.mainButton.Text = "Главная";
            this.mainButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mainButton.UseVisualStyleBackColor = false;
            this.mainButton.Click += new System.EventHandler(this.mainButton_Click);
            // 
            // centerWindow
            // 
            this.centerWindow.Controls.Add(this.panel4);
            this.centerWindow.Controls.Add(this.panel3);
            this.centerWindow.Controls.Add(this.label1);
            this.centerWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerWindow.Location = new System.Drawing.Point(175, 30);
            this.centerWindow.Name = "centerWindow";
            this.centerWindow.Size = new System.Drawing.Size(825, 470);
            this.centerWindow.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(824, 1);
            this.panel4.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 470);
            this.panel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(294, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ТУТ ПОКА ЧТО НИХУЯШЕНЬКИ НЕТ";
            // 
            // notesButton
            // 
            this.notesButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.notesButton.FlatAppearance.BorderSize = 0;
            this.notesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notesButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notesButton.ForeColor = System.Drawing.Color.White;
            this.notesButton.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.notesButton.IconColor = System.Drawing.Color.White;
            this.notesButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.notesButton.IconSize = 25;
            this.notesButton.Location = new System.Drawing.Point(0, 120);
            this.notesButton.Name = "notesButton";
            this.notesButton.Size = new System.Drawing.Size(175, 40);
            this.notesButton.TabIndex = 5;
            this.notesButton.Text = "Заметки";
            this.notesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.notesButton.UseVisualStyleBackColor = true;
            this.notesButton.Click += new System.EventHandler(this.notesButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.centerWindow);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.centerWindow.ResumeLayout(false);
            this.centerWindow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton mainButton;
        private FontAwesome.Sharp.IconButton pcButton;
        private FontAwesome.Sharp.IconButton passwordButton;
        private FontAwesome.Sharp.IconButton financeButton;
        private System.Windows.Forms.Panel centerWindow;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton notesButton;
    }
}

