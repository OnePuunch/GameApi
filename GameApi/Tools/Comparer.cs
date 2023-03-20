namespace GameApi.Tools
{
    public static class Comparer
    {
        public static bool IsEqualOrEmpty<T>(T a, T b)
        {
            if (a == null)
                return true;

            if (a.GetType() == typeof(string) && a.Equals(string.Empty))
                return true;

            return a.Equals(b);
        }
    }
}
