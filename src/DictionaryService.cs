using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dictionary
{
    public class DictionaryService
    {
        public async Task<Definition[]> DefineAsync(string word)
        {
            //Call the service
            HttpClient hc = new HttpClient();
            HttpResponseMessage resp = await hc.GetAsync("https://www.dictionary.com/browse/" + word);
            string content = await resp.Content.ReadAsStringAsync();

            //Get the part that contains the definitions
            int loc1 = content.IndexOf("css-1avshm7 e16867sm0");
            loc1 = content.IndexOf(">", loc1 + 1);
            int loc2 = content.IndexOf("css-ulg3l6 eljh6ml0", loc1 + 1);
            string DefinitionsSection = content.Substring(loc1 + 1, loc2 - loc1 - 1);



            //Split into parts to get definitions
            List<Definition> ToReturn = new List<Definition>();
            string[] parts = DefinitionsSection.Split(new string[]{"css-109x55k e1hk9ate4"}, StringSplitOptions.None);
            for (int t = 1; t < parts.Length; t++)
            {
                Definition wp = new Definition();
                string ThisPart = parts[t];

                //Add the word
                wp.Word = word.ToLower().Trim();

                //Get the word class
                loc1 = ThisPart.IndexOf("luna-pos");
                loc1 = ThisPart.IndexOf(">", loc1 + 1);
                loc2 = ThisPart.IndexOf("<", loc1 + 1);
                string WordClassTxt = ThisPart.Substring(loc1 + 1, loc2 - loc1 - 1);


                //Clean the word class text (if it contains paranthesis, for example: https://www.dictionary.com/browse/wow)
                if (WordClassTxt.Contains("("))
                {
                    loc1 = WordClassTxt.IndexOf("(");
                    WordClassTxt = WordClassTxt.Substring(0, loc1 - 1).Trim();
                }


                //Classify
                if (WordClassTxt.ToLower() == "noun")
                {
                    wp.Class = WordClass.Noun;
                }
                else if (WordClassTxt.ToLower() == "verb")
                {
                    wp.Class = WordClass.Verb;
                }
                else if (WordClassTxt.ToLower() == "adjective")
                {
                    wp.Class = WordClass.Adjective;
                }
                else if (WordClassTxt.ToLower() == "adverb")
                {
                    wp.Class = WordClass.Adverb;
                }
                else if (WordClassTxt.ToLower() == "pronoun")
                {
                    wp.Class = WordClass.Pronoun;
                }
                else if (WordClassTxt.ToLower() == "preposition")
                {
                    wp.Class = WordClass.Preposition;
                }
                else if (WordClassTxt.ToLower() == "conjunction")
                {
                    wp.Class = WordClass.Conjunction;
                }
                else if (WordClassTxt.ToLower() == "interjection")
                {
                    wp.Class = WordClass.Interjection;
                }

                //Get the description
                loc1 = ThisPart.IndexOf("one-click-content css-nnyc96 e1q3nk1v1");
                if (loc1 > -1)
                {
                    loc1 = ThisPart.IndexOf(">", loc1 + 1);
                    if (loc1 > -1)
                    {
                        loc2 = ThisPart.IndexOf("<", loc1 + 1);
                        if (loc2 > -1 && loc2 > loc1)
                        {
                            wp.Description = ThisPart.Substring(loc1 + 1, loc2 - loc1 - 1);
                        }
                    }
                }

                //Get the example
                loc1 = ThisPart.IndexOf("luna-example");
                if (loc1 > -1)
                {
                    loc1 = ThisPart.IndexOf(">", loc1 + 1);
                    if (loc1 > -1)
                    {
                        loc2 = ThisPart.IndexOf("<", loc1 + 1);
                        if (loc2 > -1 && loc2 > loc1)
                        {
                            wp.Example = ThisPart.Substring(loc1 + 1, loc2 - loc1 - 1);
                        }
                    }
                }

                

                ToReturn.Add(wp);
            }

            return ToReturn.ToArray();
        }
    }
}