using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine($"  {CommenterName}: {Text}");
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthSeconds = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");

        foreach (Comment c in comments)
        {
            c.Display();
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video v1 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);
        v1.AddComment(new Comment("Alice", "Great tutorial!"));
        v1.AddComment(new Comment("Bob", "Very clear explanation."));
        v1.AddComment(new Comment("Charlie", "Thanks for the tips!"));

        Video v2 = new Video("Object-Oriented Programming Basics", "DevGuru", 900);
        v2.AddComment(new Comment("Diana", "Super helpful, thanks."));
        v2.AddComment(new Comment("Eve", "Now I understand classes better!"));
        v2.AddComment(new Comment("Frank", "Excellent content."));

        Video v3 = new Video("Abstraction Explained", "TechTalk", 750);
        v3.AddComment(new Comment("George", "Loved the real-world examples."));
        v3.AddComment(new Comment("Hannah", "This made it so easy to follow."));
        v3.AddComment(new Comment("Ian", "Clear and concise."));

        // Store videos in list
        List<Video> videos = new List<Video>() { v1, v2, v3 };

        // Display each video
        foreach (Video v in videos)
        {
            v.Display();
        }
    }
}