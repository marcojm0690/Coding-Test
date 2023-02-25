using Coding_Test.Model;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace Coding_Test
{
    /// <summary>
    /// Acceptance Criteria
    //[X] The output should be printed to the console. 
    //[X] Each pair of names should only appear once in the list, the order does not matter.
    //[X] The json can be included as string or object in the file or loaded externally.
    //[X] You may assume all tags are lowercase and are distinct per user (promo may only appear once in a list)
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Call the model to get a List of recipients from the JSON file
                Recipient? recipient = Recipient.LoadJson();

                List<string> names = GetRecipients(recipient).ToList();
                // Print the names that are not duplicated
                Console.WriteLine(String.Join("|", names.Distinct()));
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }
        /// <summary>
        /// Get the recipients
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns>Collection of the recipients</returns>
        static IEnumerable<string> GetRecipients(Recipient? recipient)
        {
            // I use yield return to indicate that is an iterator, so I don't need to create another 
            // list to save the result
            if (recipient != null)
            {
                for (int i = 0; i <= recipient.Recipients.Count() - 1; i++)
                {
                    foreach (var promo in recipient.Recipients)
                    {
                        if (promo.Id != recipient.Recipients[i].Id)
                        {
                            //get the count of elements that are equal in two lists.
                            int count = promo.Tags!.Intersect(recipient.Recipients[i].Tags!).Count();
                            if (count >= 2)
                            {
                                //Temp List to order, so there are no duplicates after
                                List<string> temp = new List<string>
                                    {
                                        promo.Name!,
                                        recipient.Recipients[i].Name!
                                    }.OrderBy(c => c).ToList();

                                yield return String.Join(", ", temp);

                            }
                        }
                    }

                }
            }
        }
    }
}