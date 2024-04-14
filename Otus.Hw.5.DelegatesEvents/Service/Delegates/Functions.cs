namespace Otus.Hw._5.DelegatesEvents.Service.Delegates;

public static class Functions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber)
        where T : class
    {
        var items = collection.ToList();
        var maxResult = items.First();
        var maxResultFloat = convertToNumber(maxResult);

        foreach (var item in items)
        {
            var maxCandidateFloat = convertToNumber(item);

            if (maxCandidateFloat <= maxResultFloat)
            {
                continue;
            }

            maxResult = item;
            maxResultFloat = maxCandidateFloat;
        }

        return maxResult;
    }
}