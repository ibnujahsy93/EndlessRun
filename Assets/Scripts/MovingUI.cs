using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingUI : MonoBehaviour
{
    public RectTransform playButton;
    
    // Start is called before the first frame update
    void Start()
    {
        playButton.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 2).SetLoops(-1, LoopType.Yoyo);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
