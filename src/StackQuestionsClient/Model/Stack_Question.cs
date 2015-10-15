using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQuestionsClient.Model
{
    public class Stack_Question
    {
        public string[] Tags { get; set; }

        public string TagString
        {
            get
            {
                return string.Join(", ", Tags);
            }
        }

        public string Timestamp
        {
            get
            {
                return DateTime.Now.TimeOfDay.ToString();
            }
        }

        public Owner Owner { get; set; }
        public bool Is_answered { get; set; }
        public int View_count { get; set; }
        public int Answer_count { get; set; }
        public int Score { get; set; }
        public int Last_activity_date { get; set; }
        public int Creation_date { get; set; }
        public int Question_id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
    }
    public class Item
    {
        public string[] Tags { get; set; }
        public Owner Owner { get; set; }
        public bool Is_answered { get; set; }
        public int View_count { get; set; }
        public int Answer_count { get; set; }
        public int Score { get; set; }
        public int Last_activity_date { get; set; }
        public int Creation_date { get; set; }
        public int Question_id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }

    }

    public class Rootobject
    {
        public Item[] items { get; set; }
    }

    public class Owner
    {
        public int reputation { get; set; }
        public int user_id { get; set; }
        public string user_type { get; set; }
        public int accept_rate { get; set; }
        public string profile_image { get; set; }
        public string display_name { get; set; }
        public string link { get; set; }
    }


}
