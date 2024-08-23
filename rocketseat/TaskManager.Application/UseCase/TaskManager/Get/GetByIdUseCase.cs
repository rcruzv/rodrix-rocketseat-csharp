using TaskManager.Comunication.Response;

namespace TaskManager.Application.UseCase.TaskManager.Get;
public class GetByIdUseCase
{
    public TaskGetByIdResponse Execute(int id)
    {
        var task = Global.Tasks.FirstOrDefault(x => x.Id == id);

        if (task == null) return null!;

        return new TaskGetByIdResponse
        {
            Name        = task.Name,
            Description = task.Description,
            StartDate   = task.StartDate,
            EndDate     = task.EndDate,
            DeadEnd     = task.DeadEnd,
            Priority    = task.Priority,
            Status      = task.Status,
        };
    }
}
