using System.Text.RegularExpressions;

double MatchStr2Num(string s,int longestLength)
{
    string[] customSortOrder = new string[] {"", "A", "B", "G", "D", "H", "V", "Z", "J", "T", "Y", "K", "L", "M", "N", "S", "I", "P", "X", "Q", "R", "W", "U", "C", "E", "F", "O" };
    double n = 0;
    for (int i = 0; i < s.Length; i++)
    {
        n *= 100;
        n += Array.IndexOf(customSortOrder, s[i].ToString().ToUpper());
    }
    n *= Math.Pow(100 ,longestLength - s.Length);
    return n;
}

/*The custom sort done by matching a numeric value (key) for each word in the string (value), 
then the sort operate on the keys: smallest to largest,
when the values are sorted by the way due to dictionary usage*/
string CustomSort(List<string> ls)
{
    int longestLength = ls.Max(w => w.Length);
    Dictionary<double, string> dic = new Dictionary<double, string>();
    foreach (string s in ls)
        dic.Add(MatchStr2Num(s, longestLength), s);
    dic = dic.OrderBy(obj => obj.Key).ToDictionary(obj => obj.Key, obj => obj.Value);
    return string.Join(" ", dic.Values.ToArray());
}

void SortHeb(string originalStr)
{
    Regex a_zRegex = new Regex("[a-zA-Z]");
    string cleanStr = "";
    for (int i = 0; i < originalStr.Length; i++)
    {
        if (a_zRegex.IsMatch(originalStr[i].ToString()) || originalStr[i] == ' ')
            cleanStr += originalStr[i];
    }
    cleanStr = cleanStr.Trim();
    if (cleanStr.Length < 1)
        Console.WriteLine("There are no legal chars to sort");
    else
    {
        List<string> ls = cleanStr.Split(' ').ToList();
        ls.RemoveAll(s => s == "");
        cleanStr = CustomSort(ls);
        Console.WriteLine("Sorted string:" + cleanStr);
    }
}

//Main
Console.WriteLine("Please enter a string");
string originalStr = Console.ReadLine();
SortHeb(originalStr);
DateTime start = DateTime.Now;
Console.WriteLine("Sort time: " + (DateTime.Now - start).ToString());