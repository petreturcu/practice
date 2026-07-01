namespace Algs
{
    public class Sets
    {
        public static void PermuteSimple(string set, string prefix = "")
        {
            if (set.Length == 0) Console.WriteLine(prefix);
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    prefix = prefix + set[i];
                    PermuteSimple(set.Remove(i, 1), prefix);
                    prefix = prefix.Remove(prefix.Length - 1, 1);
                }
            }
        }
    }
}
