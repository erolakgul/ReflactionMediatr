using ReflactionMediatr.Lib.Interface.Request;

namespace ReflactionMediatr.Lib.Interface.Mediator
{
    public interface ICustomReflaction
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
