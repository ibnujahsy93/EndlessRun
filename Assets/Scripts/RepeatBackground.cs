using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; //menyimpan posisi awal background
    private float repeatWidth; //menyimpan lebar yang akan diulang dari background

    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        //Checking if Background in half Position and repeating the backgroun
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
