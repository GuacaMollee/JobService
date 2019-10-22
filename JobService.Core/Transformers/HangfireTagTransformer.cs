using JobService.Core.Models;
using JobService.Infra.Models.TagModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobService.Core.Transformers
{
    public static class HangfireTagTransformer
    {
        public static HangfireTag ToCore(this HangfireJobServiceTags tag)
        {
            return new HangfireTag()
            {
                Id = tag.Id,
                Name = tag.TagName
            };
        }

        public static HangfireJobServiceTags ToInfra(this HangfireTag tag)
        {
            return new HangfireJobServiceTags()
            {
                Id = tag.Id,
                TagName = tag.Name
            };
        }
    }
}
