using UnityEngine;

[CreateAssetMenu(fileName = "Character Stat", menuName = "ScriptableObject/Character Stat")]
public class CharacterStatus : ScriptableObject {
    public int maxHp;
    public int maxMp;
    public int atk;
    public int def;
}