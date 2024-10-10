using system;

class Video
{
    // Properties for video title, author, and length in seconds
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }

    // List to hold comments for the video
    public List<Comment> Comments { get; private set; }

    // Constructor to initialize the video details
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}
