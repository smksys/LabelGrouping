using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelGrouping
{
    public class ArrayComparer : IEqualityComparer<IEnumerable<string>>
    {
        public bool Equals(IEnumerable<string> x, IEnumerable<string> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(IEnumerable<string> obj)
        {
            return string.Join(",", obj).GetHashCode();

        }
    }
}
