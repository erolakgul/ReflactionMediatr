using ReflactionMediatr.API.Models.User;
using ReflactionMediatr.Lib.Interface.Request;

namespace ReflactionMediatr.API.User.Queries
{
    /// <summary>
    /// GetUserByIdQuery çağırıldığında dönüş tipi  UserViewModel olacak şekilde UserId parametresi ile çalıştır
    /// </summary>
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int UserId { get; init; }

        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
