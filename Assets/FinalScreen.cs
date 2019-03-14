using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalScreen : MonoBehaviour
{
    public CanvasGroup canvas;
    public Transform cam;
    public Transform canvasParent;
    [Space]
    [Header("Parameters")]
    public float fadeSpeed = .2f;

    void Start()
    {
        canvas.DOFade(1, fadeSpeed);
        canvasParent.DOShakePosition(fadeSpeed, 300, 30, 90, false, true);
        cam.DOShakePosition(fadeSpeed * 2, .5f, 40, 90, false, true);
    }

}
