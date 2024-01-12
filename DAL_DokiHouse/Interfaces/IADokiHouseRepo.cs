
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Repository;

namespace DAL_DokiHouse.Interfaces
{
    public interface IADokiHouseRepo
    {
        Task<PostJoinDTO?> GetPostWithComments(int userId);
        Task<UserTest?> GetInfosUserWithOwnBonsaisAndDetails(int startIndex, int pageSize);
        Task<UserTest?> GetInfosUserWithBonsaisAndDetailsById(int idUser, int startIndex, int pageSize);
        Task<UserTest2?> GetUserInfosWithOwnPostsAndComments(int userId);
    }
}
