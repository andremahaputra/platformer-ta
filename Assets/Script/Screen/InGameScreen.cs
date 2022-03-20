using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameScreen : MonoBehaviour {
    public CharacterStatus status;
    public TextMeshProUGUI healthTxt;
    public Button menuBtn;
    public EventTrigger jumpBtn;
    public EventTrigger attackBtn;
    public EventTrigger crouchBtn;
    public EventTrigger moveRightBtn;
    public EventTrigger moveLeftBtn;
}
