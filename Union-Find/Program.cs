using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Union_Find
{
    class relationship
    {
        public string FriendA { get; set; } 
        public string FriendB { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var friends = JsonSerializer.Deserialize<List<string>>(File.ReadAllText("Friends.txt"));
            var friendsR = JsonSerializer.Deserialize<List<relationship>>(File.ReadAllText("TextFile1.txt"));
            QuickFind<string> quickFind = new QuickFind<string>(friends);
            QuickUnion<string> quickUnion = new QuickUnion<string>(friends);

            for (int i = 0; i < friendsR.Count; i++)
            {
                quickFind.Union(friendsR[i].FriendA, friendsR[i].FriendB);
                quickUnion.Union(friendsR[i].FriendA, friendsR[i].FriendB); 
            }
            var groups = quickUnion.returnGroups();

        }
    }
}