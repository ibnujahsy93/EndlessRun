using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingUI : MonoBehaviour
{
    public RectTransform TitleGame;
    public RectTransform playButton;
    
    // Start is called before the first frame update
    void Start()
    {
        TitleGame.DOScale(new Vector3(9f, 1.75f, 1f), 2).SetLoops(-1, LoopType.Yoyo);
        playButton.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 2).SetLoops(-1, LoopType.Yoyo);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
