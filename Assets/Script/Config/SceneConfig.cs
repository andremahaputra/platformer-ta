using UnityEngine;

[CreateAssetMenu(fileName = "Scene Config", menuName ="ScriptableObject/Scene Config")]
public class SceneConfig : ScriptableObject {
    public SceneReference mainMenuScene;
    public SceneReference worldMapScene;
    public SceneReference uiInGameScene;
}