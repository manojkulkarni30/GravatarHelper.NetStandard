using System;
using System.Windows.Forms;

namespace GravatarHelper.NetStandard.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gravatarimage.ImageLocation = Gravatar
                .GetGravatarImageUrl("example@test.com",imageSize:200);

            qrcodeimage.ImageLocation = Gravatar
                .GetGravatarProfileQrCodeImage("example@test.com", imageSize: 200);
        }
    }
}
