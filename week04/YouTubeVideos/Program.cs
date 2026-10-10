using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "Introduction to c#",
             "Code Academy", 600
        );

        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Sarah", "Very helpful."));
        video1.AddComment(new Comment("Mike", "Thanks for sharing."));

        Video video2 = new Video(
            "Learn Object Oriented Programming",
            "Tech Guru", 900
        );

        video2.AddComment(new Comment("Emma", "Excellent explanation."));
        video2.AddComment(new Comment("David", "I understand classes better now."));
        video2.AddComment(new Comment("Sophia", "Awesome content!"));

        Video video3 = new Video(
            "Abstraction in c#",
            "Programming Hub", 720
        );

        video3.AddComment(new Comment("James", "This cleared up my confusion."));
        video3.AddComment(new Comment("Olivia", "Nice examples."));
        video3.AddComment(new Comment("Daniel", "Keep making videos!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}