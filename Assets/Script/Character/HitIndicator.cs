using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Video;
using Cysharp.Threading.Tasks;
using System;

public class HitIndicator : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = Vector3.zero;

    [SerializeField]
    private float timeToLive = 1f;
    private float floatingSpeed = .8f;
    void OnEnable()
    {
        transform.DOMove(transform.position + offset , floatingSpeed).SetEase(Ease.OutQuad);
        Destroy(this.gameObject, timeToLive);
    }
}
