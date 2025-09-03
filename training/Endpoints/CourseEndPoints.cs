using training.Data;

namespace training.Endpoints;

public static class CourseEndpoints
{
    public static void AddCourseEndpoints(this WebApplication app)
    {
        app.MapGet("/courses", LoadAllCourses);
        app.MapGet("/courses/{id}", LoadCourseById);
    }

    private static IResult LoadAllCourses(
        CourseData data,
        string? courseType,
        string? search)
    {
        var output = data.Courses;
        if (!string.IsNullOrWhiteSpace(courseType))
        {
            output.RemoveAll(x => string.Compare(
                x.courseType,
                courseType,
                StringComparison.OrdinalIgnoreCase) != 0);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            output.RemoveAll(x => !x.courseName.Contains(search, StringComparison.OrdinalIgnoreCase) &&
                !x.shortDescription.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        return Results.Ok(output);
    }

    private static IResult LoadCourseById(CourseData data, int id)
    {
        var output = data.Courses.SingleOrDefault(x => x.Id == id);
        if (output is null)
            return Results.NotFound();

        return Results.Ok(output);
    }
}