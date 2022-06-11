using UnityEngine;

[CreateAssetMenu(fileName = "Scene Config", menuName ="ScriptableObject/Scene Config")]
public class SceneContainer : ScriptableObject {
    public SceneReference mainMenu;
    public SceneReference worldMap;
    public SceneReference ui_controller;
    public SceneReference ui_enemyHealth;
    public SceneReference ui_playerHealth;
    public SceneReference prolog;
}