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
        //Making animation for UI
        TitleGame.DOScale(new Vector3(10f, 2f, 1f), 2).SetLoops(-1, LoopType.Yoyo);
        playButton.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 2).SetLoops(-1, LoopType.Yoyo);
        
    }
}
