namespace LegoCollectionChecker.Common;

public static class RepoPaths
{
    private const string SolutionFileName = "LegoCollectionChecker.sln";

    private static readonly Lazy<string> _root = new(FindRoot);

    public static string Root => _root.Value;

    public static string CompleteCollection => Common("Complete Collection.xml");
    public static string CompletedModels => Common("CompletedModels");
    public static string IncompleteModels => Common("IncompleteModels");
    public static string MissingModels => Common("MissingModels");

    public static string Common(string? relative = null) =>
        relative is null ? Path.Combine(Root, "Common") : Path.Combine(Root, "Common", relative);

    public static string Project(string projectName, string? relative = null) =>
        relative is null ? Path.Combine(Root, projectName) : Path.Combine(Root, projectName, relative);

    private static string FindRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir is not null)
        {
            if (dir.GetFiles(SolutionFileName).Length > 0)
            {
                return dir.FullName;
            }
            dir = dir.Parent;
        }
        throw new DirectoryNotFoundException(
            $"Could not locate {SolutionFileName} walking up from '{AppContext.BaseDirectory}'.");
    }
}
