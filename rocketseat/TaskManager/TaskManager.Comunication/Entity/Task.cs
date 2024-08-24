using TaskManager.Comunication.Enum;

namespace TaskManager.Comunication.Entity;
public class TaskItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public TaskPriorityType Priority { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime DeadEnd { get; set; }
    public TaskStatusType Status { get; set; }
}
