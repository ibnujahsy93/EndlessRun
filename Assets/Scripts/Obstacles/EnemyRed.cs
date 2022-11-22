using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyRed : MonoBehaviour
{
    public int durationPerLoop;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(14f, durationPerLoop).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
