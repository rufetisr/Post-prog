using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_hw
{
    class Post
    {
        public Post(int likeCount, int viewCount)
        {
            LikeCount = likeCount;
            ViewCount = viewCount;
        }

        public Post(int id, string content, DateTime creationDateTime)
        {
            Id = id;
            Content = content;
            CreationDateTime = creationDateTime;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }


        public void Show()
        {
            Console.Write($"{Id}. {Content}.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" {LikeCount} likes" + $", {ViewCount} views");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{CreationDateTime}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
