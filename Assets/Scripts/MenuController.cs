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
        //Load GameScene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
    public void MenuScene()
    {
        //Load MenuScene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
    public void ExitGame()
    {
        //Exit Game
        Application.Quit();
    }

    public void SoundOff()
    {
        //Disable Sound
        AudioListener.pause = true;
        soundOn.SetActive(false);
        soundOff.SetActive(true);
    }

    public void SoundOn()
    {
        //Enable Sound
        AudioListener.pause = false;
        soundOn.SetActive(true);
        soundOff.SetActive(false);
    }
    public void StopAnim()
    {
        //Stop Time and Animation
        Time.timeScale = 0;
    }
    public void PlayAnim()
    {
        //Play Time and Animation
        Time.timeScale = 1;
    }
}
