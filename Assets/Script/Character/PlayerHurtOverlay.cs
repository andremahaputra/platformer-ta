using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHurtOverlay : MonoBehaviour
{
    private int maxHealth;
    [SerializeField] private Image overlay;
    [SerializeField] private HealthHandler healthHandler;

    private Sequence sequence;

    void OnEnable()
    {
        healthHandler.OnInitialize += Setup;
        healthHandler.OnCurrentHealthChanged += TriggerOverlay;
    }


    void OnDisable()
    {
        healthHandler.OnInitialize -= Setup;
        healthHandler.OnCurrentHealthChanged -= TriggerOverlay;
    }

    void Setup(int maxHp, int currentHp)
    {
        this.maxHealth = maxHp;
    }


    void TriggerOverlay(int currentHp)
    {
        if (currentHp < maxHealth)
        {
            if(sequence != null) sequence.Complete();

            sequence = DOTween.Sequence();
            sequence.Pause();

            sequence.Append(overlay.DOColor(new Color(1, 1, 1, 1), 0.1f));
            sequence.Append(overlay.DOColor(new Color(1, 1, 1, 0), 0.15f));
            
            sequence.Play();
        }
    }
}
