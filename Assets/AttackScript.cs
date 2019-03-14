using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackScript : MonoBehaviour
{

    public Transform monsters;
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        monsters.DOMoveZ(monsters.transform.position.z + 10, 1).OnComplete(()=>cam.DOShakePosition(4, 1, 10, 90, false));
        monsters.DOMoveX(monsters.transform.position.x - .5f,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
