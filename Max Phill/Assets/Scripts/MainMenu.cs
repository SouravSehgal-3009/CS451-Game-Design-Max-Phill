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

        PlayerPrefs.SetInt("maxlevel", 1);

        PlayerPrefs.SetInt("currlevel", 1);
        PlayerPrefs.SetFloat("penalty", 0.0f);
        PlayerPrefs.SetInt("points", 0);
        PlayerPrefs.SetInt("left", 0);

        PlayerPrefs.SetInt("Square", 20);
        PlayerPrefs.SetInt("Triangle", 24);
        PlayerPrefs.SetInt("Circle", 18);
        PlayerPrefs.SetInt("Hexagon", 40);
        PlayerPrefs.SetInt("Star", 30);
        PlayerPrefs.SetInt("Ellipse", 35);
        PlayerPrefs.SetInt("Pentagon", 45);
        PlayerPrefs.SetInt("coverarea", 50);
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
