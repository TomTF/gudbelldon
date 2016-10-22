using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using Gudbelldon.Facebook.FacebookTypes;
using Newtonsoft.Json;

namespace Gudbelldon.Facebook
{
    public class PhotoProvider : IPhotoProvider
    {
        private List<string> albumNames;
        private FacebookClient fbClient;

        public PhotoProvider()
        {
            this.albumNames = new List<string>();
            var section = (FacebookSection)ConfigurationManager.GetSection("Facebook");
            var accessToken = section.AccessToken;
            foreach (FacebookAlbumElement a in section.Albums)
            {
                albumNames.Add(a.Name);
            }

            this.fbClient = new FacebookClient(accessToken);
        }

        public async Task<IEnumerable<Photo>> GetPhotoLinks()
        {
            var albumIds = await this.GetAlbumIds(this.albumNames);
            var batch = albumIds.Select(id =>
            {
                return new FacebookBatchParameter(string.Format("/{0}/photos", id));
            }).ToArray();
            var photoBatchresult = (JsonArray)await this.fbClient.BatchTaskAsync(batch);
            var photoIds = photoBatchresult
                .Select(r => JsonConvert.DeserializeObject<FacebookReponse>(r.ToString()))
                .SelectMany(r => r.Data.Select(d => d.Id))
                .ToList();

            batch = photoIds.Select(id =>
            {
                return new FacebookBatchParameter(string.Format("/{0}?fields=images", id));
            }).ToArray();
            var imageBatchResult = (JsonArray)await this.fbClient.BatchTaskAsync(batch);
            var images = imageBatchResult
                .Select(r => JsonConvert.DeserializeObject<FacebookReponse>(r.ToString()))
                .Select(r =>
                {
                    //var image = r.Images.FirstOrDefault(i => i.Source.Contains("960x960"));
                    //var image = r.Images.FirstOrDefault(i => i.Height > 700 && i.Width > 700 && i.Height < 3000 && i.Width < 3000);
                    var imagesOrdered = r.Images.OrderBy(i => i.Width * i.Height).ToList();
                    var image = imagesOrdered.FirstOrDefault();
                    var thumbnail = imagesOrdered.LastOrDefault();

                    //var thumbnail = r.Images.FirstOrDefault(i => i.Height < 500 && i.Width < 500 && i.Height > 100 && i.Width > 100);
                    if (image == null || thumbnail == null)
                    {
                        return null;
                    }
                    return new Photo
                    {
                        PhotoUrl = image.Source,
                        Height = image.Height,
                        Width = image.Width,
                        ThumbnailUrl = thumbnail.Source
                    };
                })
                .Where(p => p != null)
                .ToList();

            return images;
        }

        private async Task<IEnumerable<string>> GetAlbumIds(List<string> albumNames)
        {
            var albums = await this.fbClient.GetTaskAsync<FacebookReponse>("/gudbelldon/albums");
            return albums.Data.Where(a => this.albumNames.Contains(a.Name)).Select(a => a.Id);
        }
    }
}
