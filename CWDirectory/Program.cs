using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CWDirectory
{
    public class Program
    {

        public static List<string> phoneNumberList = new List<string>();
        public static void Main(string[] args)
        {
            string fullContacts = "";

            string rawContacts = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010\n"
                + "+1-541-984-3012 <P Reed> /PO Box 530; Pollocksville, NC-28573\n :+1-321-512-2222 <Paul Dive> Sequoia Alley PQ-67209\n"
                + "+1-741-984-3090 <Peter Reedgrave> _Chicago\n :+1-921-333-2222 <Anna Stevens> Haramburu_Street AA-67209\n"
                + "+1-111-544-8973 <Peter Pan> LA\n +1-921-512-2222 <Wilfrid Stevens> Wild Street AA-67209\n"
                + "<Peter Gone> LA ?+1-121-544-8974 \n <R Steell> Quora Street AB-47209 +1-481-512-2222\n"
                + "<Arthur Clarke> San Antonio $+1-121-504-8974 TT-45120\n <Ray Chandler> Teliman Pk. !+1-681-512-2222! AB-47209,\n"
                + "<Sophia Loren> +1-421-674-8974 Bern TP-46017\n <Peter O'Brien> High Street +1-908-512-2222; CC-47209\n"
                + "<Anastasia> +48-421-674-8974 Via Quirinal Roma\n <P Salinger> Main Street, +1-098-512-2222, Denver\n"
                + "<C Powel> *+19-421-674-8974 Chateau des Fosses Strasbourg F-68000\n <Bernard Deltheil> +1-498-512-2222; Mount Av.  Eldorado\n"
                + "+1-099-500-8000 <Peter Crush> Labrador Bd.\n +1-931-512-4855 <William Saurin> Bison Street CQ-23071\n"
                + "<P Salinge> Main Street, +1-098-512-2222, Denve\n" + "<P Salinge> Main Street, +1-098-512-2222, Denve\n";

            string[] contactList = rawContacts.Split("\n");

            foreach (var item in contactList)
            {
                if(item.Length > 0)
                {
                    fullContacts += sortContact(item);
                }
            }

            Console.WriteLine(fullContacts);
        }

        public static string sortContact(string contact)
        {
            Regex phoneRegex =new Regex("(\\+?)(1+?\\([0-9]{3}\\)( |)|(1-|1)?[0-9]{3}-?)[0-9]{3}-?[0-9]{4}");
            Regex nameRegex = new Regex("(\\<)([a-zA-Z])+( |)([a-zA-Z][\\']?[a-zA-Z]?)+(\\>)");
            //string contactString = "+1-541-984-3012 <P Reed> /PO Box 530; Pollocksville, NC-28573\n";
            string contactString = contact;

            contactString = removeSpecialCharacters(contactString);

            Console.WriteLine(contactString);

            Match phoneMatch = phoneRegex.Match(contactString);

            string numberToMatch = phoneMatch.Value.Replace("+1-", "");
            if (!phoneNumberList.Contains(numberToMatch))
            {
                phoneNumberList.Add(numberToMatch);
            }
            else
            {
                return "Error => Too many people: " + numberToMatch + "\n";
            }

            contactString = contactString.Replace(phoneMatch.Value + " ", "");
            contactString = contactString.Replace(phoneMatch.Value, "");
           
            Match nameMatch = nameRegex.Match(contactString);
            
            contactString = contactString.Replace(nameMatch.Value, "");
            contactString = contactString.Replace(nameMatch.Value + " ", "");
            Console.WriteLine(contactString);
            //char[] temp = phoneMatch[0].ToString().ToCharArray();


            string phone = phoneMatch.Value.Replace("+", "");
            string name = nameMatch.Value.Replace("<", "");
            contactString = contactString.Replace("+", "");
            name = name.Replace(">", "");
            contactString = contactString.Replace("-", " ");



            //string[] temp2 = contactString.Split();

            //Console.WriteLine(temp2[0]);
            //Console.WriteLine(temp2[1]);
            string result = $"Phone => {phone}, Name =>{name}, Address => {contactString}\n";
            return result;
        }

        private static string removeSpecialCharacters(string contactString)
        {
            contactString = contactString.Replace("/", "");
            contactString = contactString.Replace(",", "");
            contactString = contactString.Replace(";", "");
            contactString = contactString.Replace(":", "");
            contactString = contactString.Replace("?", "");
            contactString = contactString.Replace("*", "");
            contactString = contactString.Replace("$", "");
            contactString = contactString.Replace("!", "");
            contactString = contactString.Replace("!", "");
            contactString = contactString.Replace("_", " ");

            return contactString;
        }
    }
}