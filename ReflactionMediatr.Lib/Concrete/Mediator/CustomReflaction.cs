using ReflactionMediatr.Lib.Helper;
using ReflactionMediatr.Lib.Interface.Mediator;
using ReflactionMediatr.Lib.Interface.Request;

namespace ReflactionMediatr.Lib.Concrete.Mediator
{
    public class CustomReflaction : ICustomReflaction
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            // request  => GetUserByIdQuery 
            // response => UserViewModel

            // istekte bulunulan query bilgisi alınır
            var reqType = request.GetType();

            // IRequest tipinde olan nesne alınır
            // IRequest<TRequest>
            var reqTypeInterface = reqType.GetInterfaces()
                                .Where(x => x.IsInterface && x.GetGenericTypeDefinition() == typeof(IRequest<>))
                                .FirstOrDefault();
            // ,nterface in ilk nesnesi alınır
            var responseType = reqTypeInterface.GetGenericArguments()[0];

            //
            var genericType = typeof(IRequestHandler<,>).MakeGenericType(reqType, responseType);

            // daha önce kaydettiğimiz bir 
            // şu servisi veriyorm, handler ı ver diyoruz
            var handler = ServiceProvider.Provider.GetService(genericType);

            // handel methodu çağırılır (alacağı parametre ile birlikte)
            var result = genericType.GetMethod("Handle").Invoke(handler,new object[] { request });

            return (Task<TResponse>) result;
        }
    }
}
