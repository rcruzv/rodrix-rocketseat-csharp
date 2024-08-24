namespace TaskManager.Comunication.Enum;
public enum TaskStatusType
{
    NotStarted,   // Task has not been started yet
    InProgress,   // Task is currently in progress
    Pending,      // Task is waiting for something before it can proceed
    Completed,    // Task is finished
    OnHold,       // Task is temporarily paused
    Cancelled,    // Task has been called off and will not be completed
    Reviewing,    // Task is completed but under review
    Blocked,      // Task cannot proceed due to a barrier
    Deferred,     // Task is postponed to a later time
    Failed        // Task could not be completed successfully
}
