using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;


namespace GravatarHelper.NetStandard.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            gravatarimage.Source = new BitmapImage(new Uri(Gravatar.GetGravatarImageUrl("example@test.com", imageSize: 200), UriKind.Absolute));
            qrcodeimage.Source = new BitmapImage(new Uri(Gravatar.GetGravatarProfileQrCodeImage("example@test.com", imageSize: 200), UriKind.Absolute));
        }
    }
}
