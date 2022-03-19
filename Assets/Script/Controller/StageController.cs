public class StageController {
    public delegate void StageStartDelegate(StageData stage);
    public delegate void StageCompletedDelegate(StageData stage);

    public event StageStartDelegate OnStageStarted;
    public event StageCompletedDelegate OnStageCompleted;

    public void StartStage(StageData stage) {
        
    }

    public void CompleteStage(StageData stage) {
        
    }
}