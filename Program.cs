using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_proj
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            while (true)
            {
                String name = Console.ReadLine();
                if (name == "***")
                {
                    //Breaking the loop if user enters ***
                    break;
                }
                int votes = dictionary.GetValueOrDefault(name, 0);
                // Adding a vote if it doesn't already exist otherwise  incrementing the vote
                addOrUpdate(dictionary, name, 1);
            }

            // Getting the max entry (KeyValuePair<string, value>)
            var maxVotes = dictionary.Aggregate((l, r) => l.Value > r.Value ? l : r);

            //Checking if there's a duplicate entry with same number of maximum votes.
            var lookup = dictionary.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 1);

            // Checking if duplicated list contains  array which contains all the duplicated item contains any element.
            var maxVoteDuplicates = lookup.ToLookup(x => x.Key).Where(x => x.Key >= maxVotes.Value);

            //It means there are not duplicated votes
            if (maxVoteDuplicates.Count() == 0)
            {
                Console.WriteLine("{0}", maxVotes.Key);
            }
            else
            {
                //It means there are duplicated votes
                Console.WriteLine("RunOff!");
            }

        }

        static void addOrUpdate(Dictionary<String, int> dic, String key, int newValue)
        {
            int val;
            // Get entry if value exists 
            if (dic.TryGetValue(key, out val))
            {
                // yay, value exists!
                dic[key] = val + newValue;
            }
            // Entry doesn't exist so adding it
            else
            {
                // darn, lets add the value
                dic.Add(key, newValue);
            }
        }
    }


}