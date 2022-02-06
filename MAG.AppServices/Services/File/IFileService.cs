using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public interface IFileService
    {
        Task<string> InsertGameImage(long gameId, IFormFile file);
        FileDTO GetGameImage(string imageName);
        Task<string> UpdateGameImage(long gameId, string imageName, IFormFile file);
        void DeleteGameImage(string imageName);
    }
}
