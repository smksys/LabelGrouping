using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelGrouping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var drugs = Drug.GetTestDatas2();
            PrintLabel(drugs);
            Console.WriteLine();
            drugs = Drug.GetTestDatas3();
            PrintLabel(drugs);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                drugs = Drug.GetTestDatas();
                PrintLabel(drugs);
                Console.WriteLine();
            }

            Console.ReadLine();

        }

        static void PrintLabel(List<Drug> drugs)
        {
            Console.WriteLine("####### Drugs ########");
            foreach (var drug in drugs)
            {
                Console.WriteLine(drug.ToString());
            }

            Console.WriteLine("#######################");
            Console.WriteLine();
            var drugByPattern = drugs.SelectMany(drug => drug.Patterns, (drug, pattern) => new { drug, pattern }).ToList().GroupBy(g => g.pattern)
                .Select(g => new {
                    Pattern = g.Key,
                    Drugs = g.Select(s => s.drug),
                    DrugIds = g.Select(s => s.drug.Id).OrderBy(o => o)
                .ToList()
                });

            var groupedDrugByPattern = drugByPattern.GroupBy(g => g.DrugIds, new ArrayComparer())
                .Select(g => new { DrugIds = g.Key, Drugs = g.FirstOrDefault()?.Drugs, Patterns = g.Select(s => s.Pattern).ToArray() }).ToList();

            Console.WriteLine("####### Label ########");

            foreach (var group in groupedDrugByPattern.OrderBy(o => string.Join("-", o.Patterns)))
            {
                Console.WriteLine($"  ####### Pattern  {string.Join("-", group.Patterns)} ########");
                foreach (var drug in group.Drugs)
                {
                    Console.WriteLine("    "+drug.Name);
                }
                Console.WriteLine("  #################");
            }

            Console.WriteLine("#######################");
            Console.WriteLine();
        }
    }    

    
}
