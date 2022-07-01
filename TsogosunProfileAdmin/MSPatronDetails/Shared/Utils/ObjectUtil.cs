
using System.Collections;

namespace tsogosun.com.MSPatronDetails.Shared.Utils
{
    public static class ObjectUtil
    {
        public static bool IsCollectionValid(this ICollection collection)
        {
            if (collection == null)
                return false;
            if (collection.Count == 0)
                return false;
            return true;
        }
    }
}
