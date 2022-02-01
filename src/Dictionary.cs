using System;
using System.Collections.Generic;

namespace Dictionary
{
    public class Dictionary
    {
        private List<Definition> _Definitions;

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

        public Dictionary()
        {
            _Definitions = new List<Definition>();
        }

        public void AddDefinition(Definition d)
        {
            _Definitions.Add(d);
        }


    }
}