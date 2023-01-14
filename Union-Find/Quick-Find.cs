using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Union_Find
{
    public class QuickFind<T>
    {

        private int[] sets;
        private Dictionary<T, int> map;

        public QuickFind(IEnumerable<T> items)
        {

        }

        public int Find(T p) => sets[map[p]];
        public bool Union(T p, T q) 
        {
            if (AreConnected(p, q))
            {
                return false; 
            }
            else
            {
                var temp = Find(p);  
            }

        }
        public bool AreConnected(T p, T q) { }

    }
}
