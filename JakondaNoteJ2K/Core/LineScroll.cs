using System;
using System.Windows.Forms;

namespace JakondaNoteJ2K.Core
{
    public class LineScroll : Control
    {
        private VScrollBar vScrollBar;
        private HScrollBar hScrollBar;

        public ScrollBars ScrollBars
        {
            get { return GetVisibleScrollBars(); }
            set
            {
                UpdateScrollBars(value);
            }
        }

        public LineScroll()
        {
            this.vScrollBar = new VScrollBar
            {
                Dock = DockStyle.Right,
                Visible = false
            };

            this.hScrollBar = new HScrollBar
            {
                Dock = DockStyle.Bottom,
                Visible = false
            };

            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);

            this.vScrollBar.Scroll += VScrollBar_Scroll;
            this.hScrollBar.Scroll += HScrollBar_Scroll;
        }

        public int VerticalScrollValue
        {
            get { return this.vScrollBar.Value; }
            set { this.vScrollBar.Value = value; }
        }

        public int HorizontalScrollValue
        {
            get { return this.hScrollBar.Value; }
            set { this.hScrollBar.Value = value; }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // Синхронизация размеров и позиций дочерних элементов
            this.vScrollBar.Height = this.Height - this.hScrollBar.Height;
            this.hScrollBar.Width = this.Width - this.vScrollBar.Width;
        }

        private void UpdateScrollBars(ScrollBars scrollBars)
        {
            bool showVScrollBar = scrollBars == ScrollBars.Vertical || scrollBars == ScrollBars.Both;
            bool showHScrollBar = scrollBars == ScrollBars.Horizontal || scrollBars == ScrollBars.Both;

            this.vScrollBar.Visible = showVScrollBar;
            this.hScrollBar.Visible = showHScrollBar;
        }

        private ScrollBars GetVisibleScrollBars()
        {
            if (this.vScrollBar.Visible && this.hScrollBar.Visible)
                return ScrollBars.Both;
            else if (this.vScrollBar.Visible)
                return ScrollBars.Vertical;
            else if (this.hScrollBar.Visible)
                return ScrollBars.Horizontal;
            else
                return ScrollBars.None;
        }

        private void VScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }

        private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }
    }
}
