using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour 
{

    public int scissors;
    public int cover;
    public int coins;

    void Start(){
        Debug.Log(coins);
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("cover", cover);
        PlayerPrefs.SetInt("scissors", scissors);
        PlayerPrefs.SetInt("currlevel", 1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelExplorer");
    }

    public void QuitGame()
    {
        Debug.Log("Quit the Game!");
        Application.Quit();
    } 
}
