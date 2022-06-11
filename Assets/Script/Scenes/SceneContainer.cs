using UnityEngine;

[CreateAssetMenu(fileName = "Scene Config", menuName ="ScriptableObject/Scene Config")]
public class SceneContainer : ScriptableObject {
    public SceneReference mainMenu;
    public SceneReference worldMap;
    public SceneReference ui_inGame;
    public SceneReference ui_enemyHealth;
}