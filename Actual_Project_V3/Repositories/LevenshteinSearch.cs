namespace Actual_Project_V3.Repositories
{
    public class LevenshteinSearch
    {
        public static bool IsSimilar(string source, string target, int threshold)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
                return false;

            if (Math.Abs(source.Length - target.Length) > threshold)
                return false;

            int n = source.Length;
            int m = target.Length;

            int[,] distance = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
                distance[i, 0] = i;

            for (int j = 0; j <= m; j++)
                distance[0, j] = j;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (source[i - 1] == target[j - 1]) ? 0 : 1;

                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[n, m] <= threshold;
        }
    }
}
