using System.Security.Cryptography.X509Certificates;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Persistance.Mongo.Helpers.Aggregation;

public static class DocumentsCountHelper
{
    public static async Task<int> GetDocumentCountsAsync<T>(this IMongoCollection<T> collection, IList<BsonDocument> pipeline)
    {
        pipeline.AddCountStage();
        using var cursor = await collection.AggregateAsync(PipelineDefinition<T, BsonDocument>.Create(pipeline));
        var result = await cursor.FirstOrDefaultAsync();
        pipeline.RemoveAt(pipeline.Count - 1);
        return result["count"].AsInt32;
    }
    
    public static IList<BsonDocument> AddCountStage(this IList<BsonDocument> pipeline)
    {
        pipeline.Add(new BsonDocument("$count", "count"));
        return pipeline;
    }
}