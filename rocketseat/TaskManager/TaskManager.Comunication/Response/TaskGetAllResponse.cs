namespace TaskManager.Comunication.Response;
public class TaskGetAllResponse
{
    public List<TaskShortResponse> Items { get; set; } = [];
}

public class TaskShortResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
