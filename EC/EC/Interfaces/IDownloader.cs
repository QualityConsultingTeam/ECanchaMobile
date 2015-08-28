using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EC
{
    public interface IDownloader
    {
        string PersonalFolder { get; }

        System.Threading.Tasks.Task DownloadImage(string nameForImage, string imageUrl);
        Task<ImageSource> LoadDownloadedImage(string imageName, int requestedImageHeight, int requestedImageWidth);

        string GetMapPath();
    }

}
