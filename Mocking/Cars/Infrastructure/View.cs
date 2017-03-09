namespace Cars.Infrastructure
{
    using Cars.Contracts;

    public class View<TModel> : IView<TModel> where TModel : class
    {
        public View(TModel model = null)
        {
            this.Model = model;
        }

        public TModel Model { get; private set; }
    }
}
