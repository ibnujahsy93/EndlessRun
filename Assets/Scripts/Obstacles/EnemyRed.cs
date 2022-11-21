using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : MonoBehaviour
{
    public int speed;
    bool isMoveUp;
    
    // Start is called before the first frame update
    void Start()
    {
        //membuat variasi gerakan bila 2 objek yg sama muncul berdekatan
        isMoveUp = (Random.Range(0, 2) == 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 12f)
        {
            isMoveUp = true;
        }
        if(transform.position.y > 14f)
        {
            isMoveUp = false;
        }

        if(isMoveUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * -speed);
        }
    }
}
