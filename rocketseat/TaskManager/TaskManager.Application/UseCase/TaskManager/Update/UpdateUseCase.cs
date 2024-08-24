using TaskManager.Comunication.Request;

namespace TaskManager.Application.UseCase.TaskManager.Update;
public class UpdateUseCase
{
    public void Execute(int id, TaskRequest request)
    {
        var task = Global.Tasks.FirstOrDefault(x => x.Id == id);

        if (task == null) return;

        task.Name = request.Name;
        task.Description = request.Description;
        task.Status = request.Status;
        task.Priority = request.Priority;
        task.StartDate = request.StartDate;
        task.EndDate = request.EndDate;
        task.DeadEnd = request.DeadEnd;
    }
}
