using TaskManager.Comunication.Response;

namespace TaskManager.Application.UseCase.TaskManager.GetAll;
public class GetAllUseCase
{
    public TaskGetAllResponse Execute()
    {
        return new TaskGetAllResponse
        {
            Items = Global.Tasks.Select(s => new TaskShortResponse { Id = s.Id, Name = s.Name }).ToList()
        };
    }
}
