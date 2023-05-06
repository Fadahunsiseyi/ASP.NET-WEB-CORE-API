public class NameService
{
    public string[] Names { get; } = new[] { "John", "Doe", "Mark" };

    private Random random = new Random();
    public SomeOtherService SomeOtherService { get; }
    public NameService(SomeOtherService someOtherService)
    {
        SomeOtherService = someOtherService;
    }

    public string GetRandomName()
    {
        return Names[random.Next(0, Names.Length)];
    }
}
