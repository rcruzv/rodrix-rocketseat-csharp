namespace TaskManager.Application.UseCase.TaskManager.Delete;
public partial class DeleteUseCase
{
    public void Execute(int id)
    {
        var task = Global.Tasks.FirstOrDefault(x => x.Id == id);

        if (task == null) return;

        Global.Tasks.Remove(task);
    }
}
