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
        private Dictionary<T, int> dict;


        public int getGroups()
        {
            HashSet<int> groups = new HashSet<int>();
            for (int i = 0; i < sets.Length; i++)
            {
                groups.Add(sets[i]);
            }
            return groups.Count;
        }

        public QuickFind(List<T> items)
        {
            sets = new int[items.Count];
            dict = new Dictionary<T, int>(items.Count);

            for (int i = 0; i < sets.Length; i++)
            {
                dict.Add(items[i], i);
                sets[i] = i;
            }
        }

        public int Find(T p) => sets[dict[p]];
        public bool Union(T p, T q) 
        {
            if (AreConnected(p, q))
            {
                return false; 
            }
            else
            {
                int pVal = Find(p);
                int qVal = Find(q);
                for (int i = 0; i < sets.Length; i++)
                {
                    if (sets[i] == qVal)
                    {
                        sets[i] = pVal;
                    }
                }
                return true; 
            }
        }

        public bool AreConnected(T p, T q)
        {
            return Find(p) == Find(q); 
        }

    }
}
