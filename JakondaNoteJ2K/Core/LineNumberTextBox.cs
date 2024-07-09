using System;
using System.Drawing;
using System.Windows.Forms;
using JakondaNoteJ2K.Core;

namespace JakondaNoteJ2K.Core
{
    public class LineNumberTextBox : TextBox
    {
        private LineScroll lineScroll;
        private Padding padding;
        private Color _selectionBackColor = Color.Yellow;
        private Color _selectionForeColor = Color.Black;
        private Color _lineNumberColor = Color.Gray;

        public Color LineNumberColor
        {
            get { return _lineNumberColor; }
            set { _lineNumberColor = value; }
        }
        public Color ForeColor { get; set; }

        public MenuStrip MenuStrip { get; set; }
        public LineNumberTextBox()
        {
            this.lineScroll = new LineScroll();
            this.lineScroll.Dock = DockStyle.Right;

            this.Multiline = true;
            this.ScrollBars = ScrollBars.Both;
            this.WordWrap = false;
            this.BorderStyle = BorderStyle.None;
            this.Padding = new Padding(30, 0, 0, 0);

            this.Controls.Add(this.lineScroll);

            this.TextChanged += LineNumberTextBox_TextChanged;
            this.FontChanged += LineNumberTextBox_FontChanged;
            

           
        }
        public Color SelectionBackColor
        {
            get { return _selectionBackColor; }
            set
            {
                _selectionBackColor = value;
                Invalidate(); // Вызываем перерисовку, чтобы применить новый цвет выделения
            }
        }

        public Color SelectionForeColor
        {
            get { return _selectionForeColor; }
            set
            {
                _selectionForeColor = value;
                Invalidate(); // Вызываем перерисовку, чтобы применить новый цвет текста выделения
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateScrollBarSize();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Рисование номеров строк
            int firstIndex = this.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = this.GetLineFromCharIndex(firstIndex);
            int lastLine = this.GetLineFromCharIndex(this.GetCharIndexFromPosition(new Point(0, this.Height)));

            for (int i = firstLine; i <= lastLine; i++)
            {
                e.Graphics.DrawString((i + 1).ToString(), this.Font, Brushes.Gray, this.Padding.Left - e.Graphics.MeasureString((i + 1).ToString(), this.Font).Width, this.GetPositionFromCharIndex(this.GetFirstCharIndexFromLine(i)).Y);
            }

            base.OnPaint(e);
        }

        private void UpdateScrollBarSize()
        {
            this.lineScroll.Size = new Size(this.lineScroll.Width, this.Height - this.lineScroll.Height);
        }

        private void LineNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Invalidate(); // Перерисовка номеров строк при изменении текста
        }

        private void LineNumberTextBox_FontChanged(object sender, EventArgs e)
        {
            this.Invalidate(); // Перерисовка номеров строк при изменении шрифта
        }

        private void LineNumberTextBox_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate(); // Перерисовка номеров строк при прокрутке
        }
    }
}
