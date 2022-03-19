using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "StageData", menuName ="ScriptableObject/Stage Data")]
public class StageData : ScriptableObject {
    public string stageName;
    
    public SceneReference scene;
} 
