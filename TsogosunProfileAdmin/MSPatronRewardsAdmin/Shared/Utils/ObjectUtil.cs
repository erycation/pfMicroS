
using System.Collections;
using System.Linq;

namespace MSPatronRewardsAdmin.Shared.Utils
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