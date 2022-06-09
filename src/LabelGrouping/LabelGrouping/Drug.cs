using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelGrouping
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Drug
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Patterns { get; set; }
        public static List<Drug> GetTestDatas()
        {
            var data = new List<Drug>();

            var rnd = new Random();
            int length = rnd.Next(5, 10);

            var allPatterns = new[] { "1", "2", "3", "4", "5", "6", "7" };


            for (int i = 0; i < length; i++)
            {
                int count = rnd.Next(1, 4);
                var pattern = allPatterns.OrderBy(g => Guid.NewGuid()).Take(count).OrderBy(o => o).ToArray();
                data.Add(new Drug() { Id = i.ToString(), Name = "Drug" + i.ToString(), Patterns = pattern });
            }
            return data;
        }

        public static List<Drug> GetTestDatas2()
        {
            var data = new List<Drug>();
            data.Add(new Drug() { Id = "A", Name = "Drug_A", Patterns = new[] { "1", "2", "3", "4" } });
            data.Add(new Drug() { Id = "B", Name = "Drug_B", Patterns = new[] { "1", "2", "3", "4" } });
            data.Add(new Drug() { Id = "C", Name = "Drug_C", Patterns = new[] { "1", "3" } });
            return data;
        }

        public static List<Drug> GetTestDatas3()
        {
            var data = new List<Drug>();
            data.Add(new Drug() { Id = "A", Name = "Drug_A", Patterns = new[] { "1", "2", "3" } });
            data.Add(new Drug() { Id = "B", Name = "Drug_B", Patterns = new[] { "1", "3" } });
            data.Add(new Drug() { Id = "C", Name = "Drug_C", Patterns = new[] { "1", "3" } });
            data.Add(new Drug() { Id = "D", Name = "Drug_D", Patterns = new[] { "1" } });
            return data;
        }

        public string ToString()
        {
            return $"Id : {Id}, Name : {Name}, Pattern : {string.Join("-", Patterns)} ";
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
