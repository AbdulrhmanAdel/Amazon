using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Constants
{
    public static class MongoAggregationStagesName
    {
        public const string Match = "$match";
        public const string Sort = "$sort";
        public const string Skip = "$skip";
        public const string Limit = "$limit";
        public const string Project = "$project";
    }
}