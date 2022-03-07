using GifSample.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GifSample
{
    public partial class Form1 : Form
    {
        private Image _splash;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _splash = Resources._7304_thumbnail;
            this.Paint += new PaintEventHandler(this.Form1_Paint);

            ImageAnimator.Animate(_splash, new EventHandler(this.Image_FrameChanged));
        }

        private void Image_FrameChanged(object o, EventArgs e)
        {
            // PaintイベントハンドラをCall
            this.Invalidate();
        }

        // FormのPaintイベントハンドラ
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // フレームの更新
            ImageAnimator.UpdateFrames(_splash);

            e.Graphics.DrawImage(_splash, 0, 0);
        }
    }
}
