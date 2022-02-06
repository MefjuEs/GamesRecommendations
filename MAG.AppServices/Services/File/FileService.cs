using MAG.AppCommons;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public class FileService : IFileService
    {
        private readonly string[] enabledExtensions = new string[]
        {
            ".jpeg",
            ".jpg",
            ".png"
        };

        private readonly IAppContext appContext;

        public FileService(IAppContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<string> InsertGameImage(long gameId, IFormFile file)
        {
            if (file == null)
                return "";

            var extension = "." + file.FileName.Split(".").Last();

            if (file.Length <= 0 || file.Length > StaticValues.GameImageMaxFileSize || !enabledExtensions.Any(e => e == extension))
                return "";

            var fileName = GenerateGameImageName(gameId, file);

            var directoryToSaveTo = Path.Combine(this.appContext.ServableContentPath, "GameImages");
            if (!Directory.Exists(directoryToSaveTo))
            {
                Directory.CreateDirectory(directoryToSaveTo);
            }

            using (var stream = File.Create(Path.Combine(directoryToSaveTo, fileName)))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public FileDTO GetGameImage(string imageName)
        {
            string path = this.appContext.ServableContentPath + "\\GameImages\\" + imageName;

            if (!File.Exists(path))
                return null;

            var image = Convert.ToBase64String(File.ReadAllBytes(path));
            var extension = Path.GetExtension(path);
            var contentType = "";
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
            }

            return new FileDTO()
            {
                File = image,
                ContentType = contentType
            };
        }

        public async Task<string> UpdateGameImage(long gameId, string imageName, IFormFile file)
        {
            DeleteGameImage(imageName);
            return await InsertGameImage(gameId, file);
        }

        public void DeleteGameImage(string imageName)
        {
            if (imageName == "")
                return;

            string path = this.appContext.ServableContentPath + "\\GameImages\\";

            if (File.Exists(path + imageName))
            {
                File.Delete(path + imageName);
            }
        }

        private string GenerateGameImageName(long gameId, IFormFile file)
        {
            var extension = "." + file.FileName.Split(".").Last();
            string fileName = "Game_" + gameId;
            string path = this.appContext.ServableContentPath + "\\GameImages\\";

            if (File.Exists(path + fileName + extension))
            {
                long i = 1;
                var fileFound = true;

                do
                {
                    var tempFileName = fileName + "_" + i;

                    if (!File.Exists(path + tempFileName + extension))
                    {
                        fileFound = false;
                        fileName = tempFileName;
                    }

                    i++;
                } while (fileFound);
            }

            return $"{fileName}{extension}";
        }
    }
}
