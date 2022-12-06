using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyRed : MonoBehaviour
{
    public int durationPerLoop;
    
    void Start()
    {
        //Making Obstacle Moving Up and Down
        transform.DOMoveY(14f, durationPerLoop).SetLoops(-1, LoopType.Yoyo); 
    }
}
