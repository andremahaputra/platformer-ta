using UnityEngine;

[CreateAssetMenu(fileName = "Character Stat", menuName = "ScriptableObject/Character Stat")]
public class CharacterStatus : ScriptableObject {
    public int maxHp;
    public int atk;
}