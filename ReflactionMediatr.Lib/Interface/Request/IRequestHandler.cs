namespace ReflactionMediatr.Lib.Interface.Request
{
    /// <summary>
    /// TRequest , IRequest<TResponse> tipinden türetilmek zorunda
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}