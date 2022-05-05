using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using Persistance.Constants;
using MongoDB.Driver;

namespace Persistance.Mongo.Helpers.Aggregation
{
    public static class CommonAggregationHelper
    {
        public static IList<BsonDocument> AddMatchStage(this IList<BsonDocument> pipeline, BsonDocument match)
        {
            pipeline.Add(new BsonDocument(MongoAggregationStagesName.Match, match));
            return pipeline;
        }

        public static IList<BsonDocument> AddProjectStage(this IList<BsonDocument> pipeline, BsonDocument project)
        {
            pipeline.Add(new BsonDocument(MongoAggregationStagesName.Project, project));
            return pipeline;
        }
        
        public static PipelineDefinition<TIn,TOut> Build<TIn, TOut>(this IList<BsonDocument> pipeline)
        {
            return PipelineDefinition<TIn, TOut>.Create(pipeline);
        }
    }
}