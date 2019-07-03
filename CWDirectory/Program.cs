using System;
using System.Text.RegularExpressions;

namespace CWDirectory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Regex phoneRegex =new Regex("(\\+?)(1+?\\([0-9]{3}\\)( |)|(1-|1)?[0-9]{3}-?)[0-9]{3}-?[0-9]{4}");
            Regex nameRegex = new Regex("(\\<)([a-zA-Z])+( |)([a-zA-Z][\\']?[a-zA-Z]?)+(\\>)");
            string contactString = "+1-541-984-3012 <P Reed> /PO Box 530; Pollocksville, NC-28573\n";
            contactString = contactString.Replace("/", "");
            contactString = contactString.Replace("\n","");
            contactString = contactString.Replace(",", "");
            contactString = contactString.Replace(";", "");


            Console.WriteLine(contactString);

            Match phoneMatch = phoneRegex.Match(contactString);

            contactString = contactString.Replace(phoneMatch.Value + " ", "");
            contactString = contactString.Replace(phoneMatch.Value, "");
           
            Match nameMatch = nameRegex.Match(contactString);
            
            contactString = contactString.Replace(nameMatch.Value, "");
            contactString = contactString.Replace(nameMatch.Value + " ", "");
            Console.WriteLine(contactString);
            //char[] temp = phoneMatch[0].ToString().ToCharArray();

            string phone = phoneMatch.Value.Replace("+", "");
            string name = nameMatch.Value.Replace("<", "");
            name = name.Replace(">", "");

            //string[] temp2 = contactString.Split();

            //Console.WriteLine(temp2[0]);
            //Console.WriteLine(temp2[1]);

            Console.WriteLine($"Phone => {phone}, Name =>{name}, Address => {contactString}");
        }
    }
}