using System.Collections.Generic;
using Core.Common.Query;
using MongoDB.Bson;
using Persistance.Constants;

namespace DefaultNamespace
{
    public static class PagingAggregationHelpers
    {
        public static BsonDocument PrepareLimitStage(int pageSize)
        {
            return new BsonDocument(MongoAggregationStagesName.Limit, pageSize);
        }

        public static BsonDocument PrepareSkipStage(PagedModel model)
        {
            return new BsonDocument(MongoAggregationStagesName.Skip, model.PageSize * model.CurrentPage - 1);
        }

        public static IList<BsonDocument> AddSortStage(this IList<BsonDocument> pipeline, PagedModel model)
        {
            pipeline.Add(PrepareSkipStage(model));
            pipeline.Add(PrepareLimitStage(model.PageSize));
            return pipeline;
        }
    }
}