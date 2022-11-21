using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soundOn;
    public GameObject soundOff;

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
    public void MenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SoundOff()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        // lagu mati
    }

    public void SoundOn()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        // lagu nyala
    }
    public void StopAnim()
    {
        Time.timeScale = 0;
    }
    public void PlayAnim()
    {
        Time.timeScale = 1;
    }
}
