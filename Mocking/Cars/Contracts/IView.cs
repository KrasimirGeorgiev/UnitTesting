namespace Cars.Contracts
{
    public interface IView<out TModel> where TModel : class
    {
        TModel Model { get; }
    }
}
