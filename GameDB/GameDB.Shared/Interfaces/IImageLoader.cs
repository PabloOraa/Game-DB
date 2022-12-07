using Microsoft.UI.Xaml.Media.Imaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDB.Interfaces;

public interface IImageLoader
{
    public Task<BitmapImage> ImageLoader(string url);

    public Task<List<BitmapImage>> MultipleImageLoader(List<string> urlList);
}
