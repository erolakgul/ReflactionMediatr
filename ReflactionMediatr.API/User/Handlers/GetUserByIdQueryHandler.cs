using ReflactionMediatr.API.Models.User;
using ReflactionMediatr.API.User.Queries;
using ReflactionMediatr.Lib.Interface.Request;

namespace ReflactionMediatr.API.User.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        public Task<UserViewModel> Handle(GetUserByIdQuery request)
        {
            // db de işlemin yapıldğını varsay
            return Task.FromResult(new UserViewModel()
            {
                 Name = "ea",
                 Surname = "akgul"
            });
        }
    }
}
