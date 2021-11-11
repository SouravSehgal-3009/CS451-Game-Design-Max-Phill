using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Text pointsTxt;
    public int threshold;
    public GameObject nextButton;
    // Start is called before the first frame update
    public void Setup(int Points){
        gameObject.SetActive(true);
        pointsTxt.text = "Points: " + Points.ToString();

        if(Points >= threshold){
            int maxlevel = PlayerPrefs.GetInt("maxlevel");
            int currlevel = PlayerPrefs.GetInt("currlevel");
            maxlevel = Mathf.Max(maxlevel, currlevel + 1);

            PlayerPrefs.SetInt("maxlevel", maxlevel);
            nextButton.SetActive(true);
        }
    }

    public void LevelExplorer(){
        SceneManager.LoadScene("LevelExplorer");
    }

    public void MainMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void nextLevel(){
        int current = PlayerPrefs.GetInt("currlevel");

        PlayerPrefs.SetInt("points", 0);
        PlayerPrefs.SetInt("currLevel", current + 1);

        SceneManager.LoadScene("Level"+(current+1));
    }
}
