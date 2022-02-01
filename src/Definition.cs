using System;

namespace Dictionary
{
    public class Definition
    {
        public string Word {get; set;} //The word this definition is for
        public WordClass Class {get; set;}
        public string Description {get; set;}
        public string Example {get; set;}
    }
}
