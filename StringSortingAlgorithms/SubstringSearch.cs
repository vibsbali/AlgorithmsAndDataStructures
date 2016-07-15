namespace StringSortingAlgorithms
{
    public class SubstringSearch
    {
        public int BruteForce(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern))
            {
                return 0;
            }
            if(input.Length < pattern.Length)
            {
                return 0;
            }

            var j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == pattern[j])
                {
                    j++;
                    if (j == pattern.Length)
                        return i;
                }
                else
                {
                    j = 0;
                }
            }

            return 0;
        }
    }
}
