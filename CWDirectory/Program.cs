using System;
using System.Text.RegularExpressions;

namespace CWDirectory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string contactString = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n";

            string phonePattern = @"^(\/)?(\+?)(1?\([0-9]{3}\)( |)|(1-|1)?[0-9]{3}-?)[0-9]{3}-?[0-9]{4}";
            string namePattern = @"^(\<)([a-zA-Z])+( |)([a-zA-Z][\']?[a-zA-Z]?)+(\>)";
            MatchCollection phoneMatch = Regex.Matches("/+1-541-754-3010 156 Alphand_St. <J Steeve>\n", phonePattern);
            MatchCollection nameMatch = Regex.Matches("<Peter O'Brian>", namePattern);
            Console.WriteLine("{0} matches", phoneMatch.Count);
            Console.WriteLine("{0} matches", nameMatch.Count);

            char[] temp = phoneMatch[0].ToString().ToCharArray();


            string[] temp2 = contactString.Split(;

            Console.WriteLine(temp2[0]);
            Console.WriteLine(temp2[1]);
        }
    }
}