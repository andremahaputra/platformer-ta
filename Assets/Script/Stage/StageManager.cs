using UnityEngine;

public class StageManager : MonoBehaviour {
    public delegate void StageStartDelegate(StageData stage);
    public delegate void StageCompletedDelegate(StageData stage);

    

    void Awake() {
        
    }
}