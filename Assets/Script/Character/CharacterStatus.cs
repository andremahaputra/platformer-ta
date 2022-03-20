using UnityEngine;

[CreateAssetMenu(fileName = "Character Stat", menuName = "ScriptableObject/Character Stat")]
public class CharacterStatus : ScriptableObject {
    public int health;
    public int attack;
    public int defense;
}