using System;
using Newtonsoft.Json;
using Dictionary;
using TimHanewich.Toolkit;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {

            DictionaryService ds = new DictionaryService();
            DictionaryBook db = new DictionaryBook();
            ds.SetStorage(db);
            
            string[] words = JsonConvert.DeserializeObject<string[]>("[\"more\",\"than\",\"ever\",\"every\",\"business\",\"needs\",\"a\",\"holistic\",\"understanding\",\"of\",\"its\",\"data\",\"estate\",\"and\",\"azure\",\"purview\",\"now\",\"generally\",\"available\",\"is\",\"helping\",\"organizations\",\"such\",\"as\",\"fedex\",\"manage\",\"and\",\"govern\",\"onpremise\",\"multicloud\",\"and\",\"saas\",\"data\",\"now\",\"on\",\"to\",\"developers\",\"as\",\"every\",\"company\",\"becomes\",\"a\",\"digital\",\"company\",\"they\",\"will\",\"need\",\"standardized\",\"tools\",\"to\",\"modernize\",\"existing\",\"apps\",\"and\",\"build\",\"new\",\"ones\",\"from\",\"github\",\"to\",\"visual\",\"studio\",\"we\",\"have\",\"the\",\"most\",\"used\",\"and\",\"loved\",\"developer\",\"tools\",\"to\",\"build\",\"any\",\"app\",\"on\",\"any\",\"platform\",\"github\",\"is\",\"now\",\"home\",\"to\",\"73\",\"million\",\"developers\",\"up\",\"2\",\"times\",\"since\",\"our\",\"acquisition\",\"three\",\"years\",\"ago\",\"and\",\"yo\",\"my\",\"name\",\"is\",\"tim\"]");
            Console.WriteLine("Downloading... ");
            HanewichTimer ht = new HanewichTimer();
            ht.StartTimer();
            foreach (string s in words)
            {
                ds.DefineAsync(s).Wait();
            }
            ht.StopTimer();
            TimeSpan t1 = ht.GetElapsedTime();

            Console.WriteLine("READY TO REHERSE?");
            Console.ReadLine();
            ht.StartTimer();
            foreach (string s in words)
            {
                ds.DefineAsync(s).Wait();
                //Console.WriteLine(JsonConvert.SerializeObject(ds.DefineAsync(s).Result));
            }
            ht.StopTimer();
            TimeSpan t2 = ht.GetElapsedTime();
            
            Console.WriteLine("T1: " + t1.TotalSeconds.ToString("#,##0.000"));
            Console.WriteLine("T2: " + t2.TotalSeconds.ToString("#,##0.000"));
            
        }
    }
}
