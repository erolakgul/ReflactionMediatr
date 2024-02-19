using Microsoft.Extensions.DependencyInjection;
using ReflactionMediatr.Lib.Concrete.Mediator;
using ReflactionMediatr.Lib.Helper;
using ReflactionMediatr.Lib.Interface.Mediator;
using ReflactionMediatr.Lib.Interface.Request;
using System.Reflection;

namespace ReflactionMediatr.Lib.Extentions
{
    /// <summary>
    /// custom mediatr kütüphanesini container a ekler
    /// </summary>
    public static class ServiceCollectionExtention
    {

        public static IServiceCollection AddCustomReflaction(this IServiceCollection serviceDescriptors, Assembly[] assemblies)
        {
            // assembly içindeki interface hariç tüm class ları bul
            var types = assemblies.SelectMany(assembly => assembly.GetTypes())
                                  .Where(x => !x.IsInterface && x.IsClass);

            // bu class lar içinde de IRequest veya IRequestHandler dan türemiş olanları bul
            var requestHandler = types
                                   .Where(c=> TypeComparer.IsAssignableToGenericType(c,typeof(IRequestHandler<,>)))
                                   .ToList();

            foreach (var handler in requestHandler)
            {
                //interface i al
                var handlerInterface = handler
                                        .GetInterfaces()
                                        //.Where(h => h.GetInterfaces( )
                                        .FirstOrDefault();

                //TRequest, TResponse tiplerinden TRequest ve TResponse u al
                var requestType = handlerInterface.GetGenericArguments()[0];
                var responseType = handlerInterface.GetGenericArguments()[1];

                //IRequesthandler<TRequest, TResponse> syntax ını oluştur reflaction ile
                var genericType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);

                // service e inject et
                serviceDescriptors.AddTransient(genericType,handler);
                //service.AddTransient<IRequestHandler<GetByIdQuery,UserViewModel>,GetByIdQueryHandler>();
            }

            // ICustomReflaction çağırıldığı yerde de CustomReflaction class ını dön
            serviceDescriptors.AddSingleton<ICustomReflaction,CustomReflaction>();

            return serviceDescriptors;
        }

        public static IServiceProvider UseCustomeReflaction(this IServiceProvider serviceProvider)
        {
            ServiceProvider.SetInstanse(serviceProvider);
            return serviceProvider;
        }
    }
}
