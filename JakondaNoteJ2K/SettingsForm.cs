using JakondaNoteJ2K.Core;
using JakondaNoteJ2K.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JakondaNoteJ2K
{
    public partial class SettingsForm : Form
    {
        private Button btnDefaults;
        private Button btnApply;



        private FontDialog fontDialog;
        private ColorDialog colorDialog;


        private JakondaNoteJ2K.Core.LineNumberTextBox LineNumberTextBox;
        private System.Windows.Forms.Button btnSetFont;
        private System.Windows.Forms.Button btnSetBackgroundColor;
        public SettingsForm(TextBox LineNumberTextBox)
        {
            InitializeComponent();

            // Инициализация диалоговых окон
            fontDialog = new FontDialog();
            colorDialog = new ColorDialog();
        

        }


        private void btnDefaults_Click(object sender, EventArgs e)
        {
            // Установка стандартных значений для FontDialog и ColorDialog
            fontDialog.Font = new Font("Consolas", 12.75F);
            colorDialog.Color = Color.White;

            // Установка стандартных значений для LineNumberTextBox
            LineNumberTextBox.Font = new Font("Consolas", 12.75F);
            LineNumberTextBox.ForeColor = Color.Black;
            LineNumberTextBox.BackColor = Color.White;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Применение выбранных настроек шрифта и цвета к LineNumberTextBox
            LineNumberTextBox.Font = fontDialog.Font;
            LineNumberTextBox.ForeColor = colorDialog.Color;
            LineNumberTextBox.BackColor = colorDialog.Color;

            // Сохранение настроек в Properties.Settings.Default
            Settings.Default.Font = fontDialog.Font;
            Settings.Default.ForeColor = colorDialog.Color;
            Settings.Default.BackColor = colorDialog.Color;
            Settings.Default.Save();
        }
    

    private void btnSetFont_Click(object sender, EventArgs e)
        {
            // Показать диалог выбора шрифта
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // Применить выбранный шрифт к LineNumberTextBox
                LineNumberTextBox.Font = fontDialog.Font;
            }
        }

        private void btnSetTextColor_Click(object sender, EventArgs e)
        {
            // Показать диалог выбора цвета
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Применить выбранный цвет текста к LineNumberTextBox
                LineNumberTextBox.ForeColor = colorDialog.Color;
            }
        }

        private void btnSetBackgroundColor_Click(object sender, EventArgs e)
        {
            // Показать диалог выбора цвета
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Применить выбранный цвет фона к LineNumberTextBox
                LineNumberTextBox.BackColor = colorDialog.Color;
            }
        }
        private void InitializeComponent()
        {
            this.btnSetFont = new System.Windows.Forms.Button();
            this.btnSetBackgroundColor = new System.Windows.Forms.Button();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.LineNumberTextBox = new JakondaNoteJ2K.Core.LineNumberTextBox();
            this.SuspendLayout();
            // 
            // btnSetFont
            // 
            this.btnSetFont.Location = new System.Drawing.Point(13, 265);
            this.btnSetFont.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetFont.Name = "btnSetFont";
            this.btnSetFont.Size = new System.Drawing.Size(100, 28);
            this.btnSetFont.TabIndex = 0;
            this.btnSetFont.Text = "Font";
            this.btnSetFont.UseVisualStyleBackColor = true;
            this.btnSetFont.Click += new System.EventHandler(this.btnSetFont_Click);
            // 
            // btnSetBackgroundColor
            // 
            this.btnSetBackgroundColor.Location = new System.Drawing.Point(273, 265);
            this.btnSetBackgroundColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetBackgroundColor.Name = "btnSetBackgroundColor";
            this.btnSetBackgroundColor.Size = new System.Drawing.Size(125, 28);
            this.btnSetBackgroundColor.TabIndex = 2;
            this.btnSetBackgroundColor.Text = "Background color";
            this.btnSetBackgroundColor.UseVisualStyleBackColor = true;
            this.btnSetBackgroundColor.Click += new System.EventHandler(this.btnSetBackgroundColor_Click);
            // 
            // btnDefaults
            // 
            this.btnDefaults.Location = new System.Drawing.Point(0, 305);
            this.btnDefaults.Margin = new System.Windows.Forms.Padding(4);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(248, 28);
            this.btnDefaults.TabIndex = 1;
            this.btnDefaults.Text = "Standard Settings";
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(298, 305);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 28);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNumberTextBox.LineNumberColor = System.Drawing.Color.Gray;
            this.LineNumberTextBox.Location = new System.Drawing.Point(13, 12);
            this.LineNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LineNumberTextBox.MenuStrip = null;
            this.LineNumberTextBox.Multiline = true;
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LineNumberTextBox.SelectionBackColor = System.Drawing.Color.Yellow;
            this.LineNumberTextBox.SelectionForeColor = System.Drawing.Color.Black;
            this.LineNumberTextBox.Size = new System.Drawing.Size(385, 245);
            this.LineNumberTextBox.TabIndex = 3;
            this.LineNumberTextBox.WordWrap = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(419, 346);
            this.Controls.Add(this.btnDefaults);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnSetBackgroundColor);
            this.Controls.Add(this.btnSetFont);
            this.Controls.Add(this.LineNumberTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      
    }
}
