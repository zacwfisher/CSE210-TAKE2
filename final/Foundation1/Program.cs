using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("The Wonders of Nature", "Alice Smith", 300);
        video1.AddComment(new Comment("JohnDoe", "Amazing video!"));
        video1.AddComment(new Comment("NatureLover", "Loved the scenery."));
        videos.Add(video1);

        Video video2 = new Video("Tech Innovations 2024", "Bob Johnson", 450);
        video2.AddComment(new Comment("TechGuru", "Very informative."));
        video2.AddComment(new Comment("Innovator", "Can't wait to see what's next!"));
        video2.AddComment(new Comment("FutureFan", "Great insights."));
        videos.Add(video2);

        Video video3 = new Video("Cooking 101: Basics", "Chef Emma", 200);
        video3.AddComment(new Comment("Foodie", "Yummy recipes!"));
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine("================================");
            Console.WriteLine(video.GetVideoInfo());
            Console.WriteLine($"Comments: ({video.GetCommentCount()})");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine("================================");
            Console.WriteLine();
        }
    }
}    