namespace JobService.Core.Agents
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAgent<T>
    {
        IEnumerable<T> GetAll();

        Task Save(T item);
    }
}
