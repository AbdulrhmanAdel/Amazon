using Core.Entities.Products;

namespace core.Helpers;

public static class LocalizedObjectExtensions
{
    public static LocalizedObject<T> PopulateNullableLanguages<T>(this LocalizedObject<T> obj)
    {
        var firstNonNullValue = obj.En ?? obj.Ar;

        obj.En ??= firstNonNullValue;
        obj.Ar ??= firstNonNullValue;

        return obj;
    }
}