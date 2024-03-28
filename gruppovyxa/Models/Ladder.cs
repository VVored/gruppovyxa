using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruppovyxa.Models
{
    internal class Ladder
    {

        private List<User> Top100 = new List<User>();



        public void AddUser(User user)
        {
            Top100.Add(user);
        }


        public void RemoveUser(User user)
        {
            Top100.Remove(user);
        }


        public void UpdateLeaderboard()
        {
            SortTop100ByPoints();
            UpdatePlaces(); 
        }
        public void SortTop100ByPoints()
        {
            Top100.Sort((x, y) =>
            {
                if (x is User userX && y is User userY)
                {
                    return userY.Points.CompareTo(userX.Points); 
                }
                return 0; 
            });
            Top100 = Top100.Take(100).ToList(); 
        }

        private void UpdatePlaces()
        {
            for (int i = 0; i < Top100.Count; i++)
            {
                Top100[i].Place = i + 1;
            }
        }


        public List<User> GetTop100()
        {
            UpdateLeaderboard();
            return Top100;
        }
    }
}
