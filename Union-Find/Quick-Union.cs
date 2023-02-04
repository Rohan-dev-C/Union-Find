using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Union_Find
{
    public class QuickUnion<T>
    {

        private int[] sets;

        private Dictionary<T, int> dict;

        public int getGroups()
        {
            HashSet<int> set = new HashSet<int>();
            foreach(var item in dict)
            {
                set.Add(Find(item.Key)); 
            }
            return set.Count;
        }

        public List<List<T>> returnGroups()
        {
            Dictionary<int, List<T>> findstuff = new Dictionary<int, List<T>>();

            List<List<T>> groups = new List<List<T>>();
            foreach (var item in dict)
            {
                var temp = Find(item.Key);
                if (!findstuff.ContainsKey(temp))
                {
                    findstuff[temp] = new List<T>();
                }
                findstuff[temp].Add(item.Key); 
            }
            return findstuff.Values.ToList();
        }


        public QuickUnion(List<T> items)
        {
            sets = new int[items.Count()];
            dict = new Dictionary<T, int>();

            for (int i = 0; i < sets.Length; i++)
            {
                dict.Add(items[i], i);
                sets[i] = i;
            }
        }

        public int Find(T p)
        {
            var temp = dict[p];
            while (sets[temp] != temp)
            {
               temp = sets[temp];
            }
            return temp;
        }
        public bool Union(T p, T q)
        {
            if (AreConnected(p, q))
            {
                return false;
            }
            else
            {
                sets[Find(p)] = sets[Find(q)];
                return true;
            }
        }
        public bool AreConnected(T p, T q)
        {
            return Find(p) == Find(q);
        }
    }
    }
