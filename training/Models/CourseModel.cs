namespace training.Models;

public class CourseModel
{
    public int Id { get; set; }
    public bool isPreorder { get; set; }
    public string? courseURL { get; set; }
    public string? courseType { get; set; }
    public string? courseName { get; set; }
    public int courseLessonCount { get; set; }
    public double courseLengthInHours { get; set; }
    public string? shortDescription { get; set; }
    public string? courseImage { get; set; }
    public int priceInUSD { get; set; }
    public string? coursePreviewLink { get; set; }
    
}