using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundConfiguration : MonoBehaviour
{
    public static SoundConfiguration instance; //menyimpan objek
 
    //void awake dijalankan ketika scene dimuat
    void Awake()
    {
        // mengecek agar tidak terjadi duplikasi objek pada DontDestroyOnLoad
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            // objek akan tetap berjalan ketika berpindah scene
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
