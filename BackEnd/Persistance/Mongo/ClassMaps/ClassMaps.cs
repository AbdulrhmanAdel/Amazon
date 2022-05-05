using Persistance.Mongo.ClassMaps;

namespace Persistance.Mongo.ClassMaps;

public class ClassMaps
{
    public static void Register()
    {
        ProductClassMap.RegisterProductClassMap();
    }
}