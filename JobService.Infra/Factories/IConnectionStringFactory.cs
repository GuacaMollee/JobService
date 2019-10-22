namespace JobService.Infra.Factories
{
    public interface IConnectionStringFactory
    {
        string Create<T>();
    }
}
