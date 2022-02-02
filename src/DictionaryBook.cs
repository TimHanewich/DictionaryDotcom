using System;
using System.Collections.Generic;

namespace Dictionary
{
    public class DictionaryBook
    {
        private List<DefinitionSet> _DefinitionSets;
        private List<string> LookedUpWordsThatReturnedNoDefinitions; //A list of words that we looked up, but Definitions.com did not have any definitions for

        public Definition[] Definitions
        {
            get
            {
                if (_Definitions == null)
                {
                    return new Definition[]{};
                }
                else
                {
                    return _Definitions.ToArray();
                }
            }
        }

        public DictionaryBook()
        {
            _Definitions = new List<Definition>();
            LookedUpWordsThatReturnedNoDefinitions = new List<string>();
        }

        public void AddDefinition(Definition d)
        {
            _Definitions.Add(d);
        }


        //Looks up definition. If this is on the LookedUpWordsThatReturnedNoDefinitions list, we will return a list of 0 Definitions (none available). If we have have never encountered this word before (it is not in the no definitions list and we do not have a record for it, we will return null). If we have records, return them.
        public Definition[] Lookup(string word)
        {
            //First, check if this word is on the lookup words that returned no definitions list
            foreach (string nrword in LookedUpWordsThatReturnedNoDefinitions)
            {
                if (nrword.Trim().ToLower() == word.Trim().ToLower())
                {
                    return new Definition[]{}; //Return no results
                }
            }


            //Collect the definitions for this word
            List<Definition> ToReturn = new List<Definition>();
            foreach (Definition def in Definitions)
            {
                if (def.Word.Trim().ToLower() == word.Trim().ToLower())
                {
                    ToReturn.Add(def);
                }
            }


            //If we have results, return the results. If not, return NULL.
            if (ToReturn.Count > 0)
            {
                return ToReturn.ToArray();
            }
            else
            {
                return null; //A null result means we we have not confirmed with Dictionary.com that no definitions for this exist yet. Yet we do not have any definitions in our list of definitions. Therefore, this means we do not have any familiarity with this word. We cannot return definitions and we cannot guanrentee there are no valid definitions for this word. So return null.
            }

            
        }

    }
}