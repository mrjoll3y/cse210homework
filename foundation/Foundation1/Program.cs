using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a few video instances
        Video video1 = new Video("Exploring Space", "SpaceX", 600);
        Video video2 = new Video("Learning Guitar", "John Doe", 300);
        Video video3 = new Video("Cooking Pasta", "Chef Mario", 200);

        // Add comments to video 1
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "Can't wait to see more!"));

        // Add comments to video 2
        video2.AddComment(new Comment("Danielle", "Loved the tutorial."));
        video2.AddComment(new Comment("Eve", "Could you show more finger exercises?"));
        video2.AddComment(new Comment("Frank", "This was really helpful, thanks!"));

        // Add comments to video 3
        video3.AddComment(new Comment("George", "I tried the recipe, it was delicious."));
        video3.AddComment(new Comment("Helen", "Can you make a vegetarian version?"));
        video3.AddComment(new Comment("Irene", "Awesome! Keep it up."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display details of each video and their comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); // Add a blank line between videos for better readability
        }
    }
}