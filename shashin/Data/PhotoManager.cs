using System;
using Unsplasharp;
using System.Threading.Tasks;
using Unsplasharp.Models;

namespace shashin.Data
{
    public class PhotoManager
    {
        UnsplasharpClient client = new UnsplasharpClient("93123f0db401f8367e061a60e9b0976b9bc9c3cafe5133f344bba4010c97a4de", "b5fb7fec8401ec0727226a41f9fea4ef184c10f7efef4b009ee910dbf3ca386a");

        public async Task<Photo> RandomPhoto()
        {
            Photo randomPhoto = await client.GetRandomPhoto();
            return randomPhoto;
        }
    }
}
