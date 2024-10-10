using System;
class Comment
{
    // Properties for the commenter's name and comment text
    public string Name { get; private set; }
    public string Text { get; private set; }

    // Constructor to initialize comment details
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}