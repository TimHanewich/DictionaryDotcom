using System;
using System.Collections.Generic;

namespace Dictionary
{
    public class DictionaryBook
    {
        private List<DefinitionSet> _DefinitionSets;

        public DefinitionSet[] DefinitionSets
        {
            get
            {
                if (_DefinitionSets == null)
                {
                    return new DefinitionSet[]{};
                }
                else
                {
                    return _DefinitionSets.ToArray();
                }
            }
        }

        public DictionaryBook()
        {
            _DefinitionSets = new List<DefinitionSet>();
        }

        public void AddDefinitionSet(DefinitionSet d)
        {
            _DefinitionSets.Add(d);
        }


        //Looks up definition. If this is on the LookedUpWordsThatReturnedNoDefinitions list, we will return a list of 0 Definitions (none available). If we have have never encountered this word before (it is not in the no definitions list and we do not have a record for it, we will return null). If we have records, return them.
        public DefinitionSet Lookup(string word)
        {
            foreach (DefinitionSet ds in DefinitionSets)
            {
                if (ds.Word.ToLower().Trim() == word.ToLower().Trim())
                {
                    return ds;
                }
            }            
            return null;
        }

    }
}