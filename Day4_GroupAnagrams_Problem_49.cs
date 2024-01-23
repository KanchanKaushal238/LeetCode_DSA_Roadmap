/*
 *Given an array of strings strs, group the anagrams together. You can return the answer in any order.
 *
 *An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
 *typically using all the original letters exactly once.
 *
 *
 *Example 1:
 *
 *Input: strs = ["eat","tea","tan","ate","nat","bat"]
 *Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
 *
 *
 *Example 2:
 *
 *Input: strs = [""]
 *Output: [[""]]
 *
 *
 *Example 3:
 *
 *Input: strs = ["a"]
 *Output: [["a"]]
 *
 *
 *Constraints:
 *
 *1 <= strs.length <= 104
 *0 <= strs[i].length <= 100
 *strs[i] consists of lowercase English letters. 
*/

/*---------------------------------------------------Solution 1-------------------------------------------------------*/
/*----------------------------------Not Optimize => Gives time limit exceeded exception ------------------------------*/
public class Solution1
{
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        IList<IList<string>> resp = new List<IList<string>>();
        List<string> addAnagram = new List<string>();

        for (int i = 0; i < strs.Length; i++)
        {
            if (resp.Any(x => x.Any(y => y == strs[i])))
            {
                continue;
            }

            addAnagram = new List<string>();

            char[] initialStr = strs[i].ToCharArray();
            addAnagram.Add(strs[i]);

            for (int j = i + 1; j < strs.Length; j++)
            {
                char[] secStr = strs[j].ToCharArray();

                Array.Sort(initialStr);
                Array.Sort(secStr);

                string first = new string(initialStr);
                string second = new string(secStr);

                if (first == second)
                {
                    addAnagram.Add(strs[j]);
                }
            }
            resp.Add(addAnagram);
        }

        return resp;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter length of string array: ");
        int strLength = Convert.ToInt32(Console.ReadLine());

        string[] strs = new string[strLength];

        for(int i = 0; i< strLength; i++)
        {
            strs[i] = Console.ReadLine();
        }

        IList<IList<string>> respList = GroupAnagrams(strs);

        foreach(var resp in respList)
        {
            foreach (var result in resp)
            {
                Console.WriteLine(result);
            }
        }
    }
}

/*---------------------------------------------------Solution 2-------------------------------------------------------*/
/*----------------------------------Optimized sol => Solves time limit exceeded exception ------------------------------*/
public class Solution2
{
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        IList<IList<string>> resp = new List<IList<string>>();
        var dict = new Dictionary<string, List<string>>();

        foreach (var str in strs)
        {
            var m = str.ToCharArray();
            Array.Sort(m);
            string strSorted = new string(m);

            if (dict.ContainsKey(strSorted))
            {
                dict[strSorted].Add(str);
            }
            else
            {
                dict.Add(strSorted, new List<string>() { str });
            }
        }
        foreach (var val in dict)
        {
            resp.Add(val.Value);
        }

        return resp;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter length of string array: ");
        int strLength = Convert.ToInt32(Console.ReadLine());

        string[] strs = new string[strLength];

        for(int i = 0; i< strLength; i++)
        {
            strs[i] = Console.ReadLine();
        }

        IList<IList<string>> respList = GroupAnagrams(strs);

        foreach(var resp in respList)
        {
            foreach (var result in resp)
            {
                Console.WriteLine(result);
            }
        }
    }
}
