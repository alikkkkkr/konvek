using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace конвертер
{
    public class files
    {
        public string userformat;
        private static bool result;
        private static bool result1;
        private static bool result2;

        public static void viborInput()
        {
            Console.WriteLine("введиtе путь к файлу, который хотите прочитать");
            Console.WriteLine("----------------------------");
            string userInside = Console.ReadLine();
            result = userInside.Contains(".txt");
            result1 = userInside.Contains(".json");
            result2 = userInside.Contains(".xml");

            if (result == true)
            {
                human human = new human();
                List<human> txtlist = new List<human>();
                string[] Stroki = File.ReadAllLines(userInside);
                for (int i = 0; i <= Stroki.Length; i += 3)
                {
                    human = new human(Stroki[i], Convert.ToInt32(Stroki[i += 1]), Stroki[i += 2]);
                    txtlist.Add(human);
                }
                foreach (human vivodtxt in txtlist) { Console.WriteLine(vivodtxt); }
            }

            if (result1 == true)
            {
                string text = File.ReadAllText(userInside);
                List<human> jsonlist = JsonConvert.DeserializeObject<List<human>>(text);
                foreach (human vivodjson in jsonlist)
                {
                    Console.WriteLine(human.name, human.age, human.color);
                }
            }

            if (result2 == true)
            {
                List<human> xmllist = new List<human>();

                XmlSerializer xmls = new XmlSerializer(typeof(List<human>));
                using (FileStream fs = new FileStream(userInside, FileMode.Open))
                {
                    xmllist = (List<human>)xmls.Deserialize(fs);
                }
                foreach (human vivodxml in xmllist)
                {
                    Console.WriteLine(vivodxml);
                }

                //TextReader textReader = new StreamReader(userInside);
                //List<human> xmllist;
                //xmllist = (List<human>)xmls.Deserialize(textReader);
                //textReader.Close();
                //////return humannew;
                //foreach (human vivodxml in xmllist)
                //{
                //    Console.WriteLine(human.name, human.age, human.color);
                //}
            }
        }

        public void viborFormata(List<human> humans)
        {
            Console.WriteLine("\nвведиtе путь до файла");
            Console.WriteLine("----------------------------");
            userformat = Console.ReadLine();
            result = userformat.Contains(".txt");
            result1 = userformat.Contains(".json");
            result2 = userformat.Contains(".xml");

            if (result == true)
            {
                human human = new human();
                foreach (human vivod in humans)
                {
                    File.AppendAllText(userformat, human.name + "\n" + human.age + "\n" + human.color);
                }
            }

            if (result1 == true)
            {
                human human = new human();
                string jsons = JsonConvert.SerializeObject(humans);
                File.AppendAllText(userformat, "\n" + jsons);
            }

            if (result2 == true)
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<human>));
                using (FileStream fs = new FileStream(userformat, FileMode.OpenOrCreate))
                {
                    xmls.Serialize(fs, humans);
                }
            }
        }
	}
}
// Users\alinaryzhkova\Desktop.