namespace StringSortingAlgorithms
{
    public class SubstringSearch
    {
        //This algorithm is better than better than naiive brute force
        //The way I came up with this algorithm is I wrote code without --i part
        //Then I did some tests and realised it fails when input string is drodroped and string to find is droped
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
                        return i - j;
                }
                else if (j != 0)
                {
                    j = 0;
                    --i; //This is important step - so that we can match drodroped and droped 
                }
            }

            return 0;
        }
    }
}
