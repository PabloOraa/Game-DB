using GameDB.Interfaces;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace GameDB.Services;

public class ImageLoaderService : IImageLoader
{
    public async Task<List<BitmapImage>> MultipleImageLoader(List<string> urlList)
    {
        List<BitmapImage> bitmapImages = new();

        foreach(var url in urlList)
        {
            bitmapImages.Add(await ImageLoader(url));
        } 

        return bitmapImages;
    }

    public async Task<BitmapImage> ImageLoader(string url)
    {
        var imgUrl = new Uri(url);
        var responseIm = await new HttpClient().GetAsync(imgUrl);
        byte[] img = await responseIm.Content.ReadAsByteArrayAsync();

        InMemoryRandomAccessStream randomAccessStream = new();

        DataWriter writer = new(randomAccessStream.GetOutputStreamAt(0));

        writer.WriteBytes(img);

        await writer.StoreAsync();

        BitmapImage b = new();

        b.SetSource(randomAccessStream);
        return b;
    }
}
