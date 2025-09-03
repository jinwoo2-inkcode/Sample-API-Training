namespace training.Data;

using System.Text.Json;
using training.Models;

public class CourseData
{
    public List<CourseModel> Courses { get; set; }

    public CourseData()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        string filePath = Path.Combine(Directory.GetCurrentDirectory(),
        "Data",
        "coursedata.json");

        string json = File.ReadAllText(filePath);

        Courses = JsonSerializer.Deserialize<List<CourseModel>>(json, options) ?? new();
    }
}