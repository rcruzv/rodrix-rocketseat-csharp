using TaskManager.Comunication.Entity;
using TaskManager.Comunication.Request;
using TaskManager.Comunication.Response;

namespace TaskManager.Application.UseCase.TaskManager.Register;
public class RegisterUseCase
{
    public TaskRegisterResponse Execute(TaskRequest request)
    {
        int Id = new Random().Next();

        Global.Tasks.Add(
            new TaskItem()
            {
                Id          = Id,
                Name        = request.Name,
                Description = request.Description,
                Priority    = request.Priority,
                StartDate   = request.StartDate,
                EndDate     = request.EndDate,
                Status      = request.Status,
                DeadEnd     = request.DeadEnd
            }
        );


        return new()
        {
            Id = Id,
        };
    }
}
