using JakondaNoteJ2K.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JakondaNote
{
    partial class MainFormj2k
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        // Поля для функционала перетаскивания окна
   
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormj2k));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитькакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineNumberTextBox = new JakondaNoteJ2K.Core.LineNumberTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.toolStripSeparator,
            this.сохранитькакToolStripMenuItem,
            this.toolStripSeparator1,
            this.печатьToolStripMenuItem,
            this.toolStripSeparator2,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Image = global::JakondaNoteJ2K.Properties.Resources.Menu_CreateFile;
            this.создатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.создатьToolStripMenuItem.Text = "Create file";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.createFileToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Image = global::JakondaNoteJ2K.Properties.Resources.Menu_OpenFile;
            this.открытьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.открытьToolStripMenuItem.Text = "Open file";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(221, 6);
            // 
            // сохранитькакToolStripMenuItem
            // 
            this.сохранитькакToolStripMenuItem.Image = global::JakondaNoteJ2K.Properties.Resources.Menu_SaveFile1;
            this.сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            this.сохранитькакToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сохранитькакToolStripMenuItem.Text = "Save as";
            this.сохранитькакToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Image = global::JakondaNoteJ2K.Properties.Resources.Menu_Pechat;
            this.печатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.печатьToolStripMenuItem.Text = "Print";
            this.печатьToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.выходToolStripMenuItem.Text = "Exit";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.сервисToolStripMenuItem.Text = "Service";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.настройкиToolStripMenuItem.Text = "Settings";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.toolStripSeparator5,
            this.опрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.справкаToolStripMenuItem.Text = "Reference";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.поискToolStripMenuItem.Text = "Search";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(226, 6);
            // 
            // опрограммеToolStripMenuItem
            // 
            this.опрограммеToolStripMenuItem.Image = global::JakondaNoteJ2K.Properties.Resources.Menu_J;
            this.опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            this.опрограммеToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.опрограммеToolStripMenuItem.Text = "About the program...";
            this.опрограммеToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // createFileToolStripMenuItem
            // 
            this.createFileToolStripMenuItem.Name = "createFileToolStripMenuItem";
            this.createFileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.BackColor = System.Drawing.Color.White;
            this.LineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineNumberTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.LineNumberTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.LineNumberTextBox.LineNumberColor = System.Drawing.Color.Gray;
            this.LineNumberTextBox.Location = new System.Drawing.Point(0, 28);
            this.LineNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LineNumberTextBox.MenuStrip = null;
            this.LineNumberTextBox.Multiline = true;
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LineNumberTextBox.SelectionBackColor = System.Drawing.Color.Yellow;
            this.LineNumberTextBox.SelectionForeColor = System.Drawing.Color.Black;
            this.LineNumberTextBox.Size = new System.Drawing.Size(1067, 710);
            this.LineNumberTextBox.TabIndex = 0;
            this.LineNumberTextBox.WordWrap = false;
            // 
            // MainFormj2k
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.LineNumberTextBox);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Purple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFormj2k";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JakondaNote";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        #endregion
        
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private JakondaNoteJ2K.Core.LineNumberTextBox LineNumberTextBox;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem сохранитькакToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem печатьToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem сервисToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem поискToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem опрограммеToolStripMenuItem;
    }
}
