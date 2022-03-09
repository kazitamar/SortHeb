﻿using System.Text.RegularExpressions;

double ConvertStr2Num(string s,int longestLength)
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

string CustomSort(List<string> ls)
{
    int longestLength = ls.Max(w => w.Length);
    Dictionary<double, string> dic = new Dictionary<double, string>();
    foreach (string s in ls)
        dic.Add(ConvertStr2Num(s, longestLength), s);
    dic = dic.OrderBy(obj => obj.Key).ToDictionary(obj => obj.Key, obj => obj.Value);
    return string.Join(" ", dic.Values.ToArray());
}

//Main
Console.WriteLine("Please enter a string");
Regex re = new Regex("[a-zA-Z]");
string originalStr = Console.ReadLine();
string cleanStr="";
for (int i = 0; i < originalStr.Length; i++)
{
    if (re.IsMatch(originalStr[i].ToString()) || originalStr[i] == ' ')
        cleanStr += originalStr[i];
}
cleanStr = cleanStr.Trim();
if (cleanStr.Length < 1)
    Console.WriteLine("There are no legal chars to sort");
else
{
    DateTime start = DateTime.Now;
    List<string> ls = cleanStr.Split(' ').ToList();
    ls.RemoveAll(s => s == "");
    cleanStr = CustomSort(ls);
    Console.WriteLine("Sorted string:" + cleanStr);
    Console.WriteLine("Sort time: " + (DateTime.Now - start).ToString());
}