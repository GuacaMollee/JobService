namespace JobService.Infra.Factories
{
    public interface IContextFactory<T>
    {
        T DbContext { get; }
    }
}
