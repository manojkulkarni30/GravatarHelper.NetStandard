using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Net;

namespace GravatarHelper.NetStandard.Droid
{
    [Activity(Label = "GravatarHelper.NetStandard.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
        protected override int LayoutResource
        {
            get { return Resource.Layout.main; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);

            var imageBitmap = GetImageBitmapFromUrl(Gravatar.GetGravatarImageUrl("example@test.com", imageSize: 200));
            var imageView = FindViewById<ImageView>(Resource.Id.image);
            imageView.SetImageBitmap(imageBitmap);

            imageBitmap = GetImageBitmapFromUrl(Gravatar.GetGravatarProfileQrCodeImage("example@test.com", imageSize: 200));
            var qrCodeImageView = FindViewById<ImageView>(Resource.Id.qrcodeimage);
            qrCodeImageView.SetImageBitmap(imageBitmap);


        }
    }
}

