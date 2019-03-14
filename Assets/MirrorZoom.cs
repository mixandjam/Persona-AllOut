using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MirrorZoom : MonoBehaviour
{
    public Transform mirrorParent;
    public Transform[] selectedPieces;
    public Transform[] desiredPositions;

    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {

        Sequence mirrorZoom = DOTween.Sequence();
        mirrorZoom.Append(cam.transform.DOPunchPosition(Vector3.up/2, .2f,20,1,false));

        for (int i = 0; i < selectedPieces.Length; i++)
        {
            selectedPieces[i].parent = null;
        }

         for (int i = 0; i < selectedPieces.Length; i++)
        {
            Transform charPiece = selectedPieces[i];
            charPiece.GetChild(0).gameObject.SetActive(true);

            mirrorZoom.Join(charPiece.DOScale(charPiece.localScale * 1.1f, .15f));
            mirrorZoom.Join(charPiece.DOMove(desiredPositions[i].position, .15f).SetEase(Ease.InExpo));
            mirrorZoom.Join(charPiece.DORotate(desiredPositions[i].eulerAngles, .15f));
            mirrorZoom.Join(charPiece.DOBlendableLocalRotateBy(new Vector3(Random.Range(0,10),0,0), 2));

            for (int j = 0; j < mirrorParent.childCount; j++)
            {
                Transform mirrorPiece = mirrorParent.GetChild(j);

                mirrorZoom.Join(mirrorPiece.DOLocalRotate(new Vector3(Random.Range(0, 30), Random.Range(0, 40), Random.Range(0, 30)), 2f));
                mirrorZoom.Join(mirrorPiece.DOScale(mirrorPiece.localScale / 1.1f, .2f));
            }

        }

        mirrorZoom.Append(mirrorParent.DOMoveZ(-50, .3f));
        mirrorZoom.Join(mirrorParent.DOBlendableRotateBy(Vector3.right * 30, .3f));
        for (int i = 0; i < selectedPieces.Length; i++)
        {
            mirrorZoom.Join(selectedPieces[i].DOMoveZ(-50, .8f));
            mirrorZoom.Join(selectedPieces[i].DOBlendableLocalRotateBy(Vector3.right * 90, .3f));
        }

    }
}
