using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MirrorBreak : MonoBehaviour
{
    public float breakDuration;
    public Transform cam;
    public Transform mirrorParent;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < mirrorParent.childCount; i++)
        {
            mirrorParent.GetChild(i).DOLocalRotate(new Vector3(Random.Range(0, 20), 0, Random.Range(0, 20)), breakDuration);
            mirrorParent.GetChild(i).DOScale(mirrorParent.GetChild(i).localScale / 1.1f, breakDuration);
        }

        cam.DOShakePosition(breakDuration, .5f, 20, 90, false, true);
    }


}
