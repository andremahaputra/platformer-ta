using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using VContainer;

public class PrologScreen : MonoBehaviour
{
    [SerializeField]
    private RawImage image;

    [SerializeField]
    private Button nextBtn;

    [SerializeField]
    private Button prevBtn;

    [SerializeField]
    private Image fader;

    [SerializeField]
    List<Texture2D> images;

    private int currentIndex = 0;

    private Sequence sequence;

    [Inject]
    private Navigator navigator;

    void Start()
    {
        image.texture = images[currentIndex];
        sequence = DOTween.Sequence().Pause();
        sequence.Append(fader.DOColor(new Color(0, 0, 0, 0), 1));
        sequence.Play();
    }

    public void NextImg()
    {
        if (currentIndex == images.Count - 1)
        {
            sequence = DOTween.Sequence().Pause();
            sequence.Append(fader.DOColor(new Color(0, 0, 0, 1), 1));
            sequence.Play().OnComplete(() => {
                Debug.Log("Navigate to another scene");
                navigator.ToWorldMap();
            });
            return;
        }
        if (sequence.IsPlaying()) return;

        sequence = DOTween.Sequence().Pause();
        sequence.Append(fader.DOColor(new Color(0, 0, 0, 1), .6f).OnComplete(() =>
        {
            currentIndex++;
            image.texture = images[currentIndex];
        }));
        sequence.Append(fader.DOColor(new Color(0, 0, 0, 0), .6f));
        sequence.Play();

    }

    public void PrevImage()
    {
        if (currentIndex == 0) return;
        if (sequence.IsPlaying()) return;

        sequence = DOTween.Sequence().Pause();
        sequence.Append(fader.DOColor(new Color(0, 0, 0, 1), .6f).OnComplete(() =>
        {
            currentIndex--;
            image.texture = images[currentIndex];
        }));
        sequence.Append(fader.DOColor(new Color(0, 0, 0, 0), .6f));
        sequence.Play();
    }
}
