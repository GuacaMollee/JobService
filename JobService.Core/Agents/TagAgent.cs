using JobService.Core.Models;
using JobService.Core.Transformers;
using JobService.Infra.Models.TagModels;
using JobService.Infra.Repositories;
using JobService.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Core.Agents
{
    public class TagAgent : IAgent<HangfireTag>
    {
        public readonly IUnitOfWork<JobTagsContext> unitOfWork;
        public readonly IRepository<HangfireJobServiceTags, JobTagsContext> repository;

        public TagAgent(IUnitOfWork<JobTagsContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.GetRepository<HangfireJobServiceTags>();
        }

        public IEnumerable<HangfireTag> GetAll()
        {
            return repository.GetAll().Select(x => x.ToCore());
        }

        public HangfireTag Get(int id)
        {
            return repository.Get(id).ToCore();
        }

        public Task Save(HangfireTag tag)
        {
            repository.Add(tag.ToInfra());

            return unitOfWork.Commit();
        }
    }
}
