using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{

    public Text pointsTxt;
    public int threshold;
    public GameObject CongoMessage;
    public GameObject gameover;
    public GameObject levelexp;
    // Start is called before the first frame update
    public void Setup(int Points){
        gameObject.SetActive(true);
        pointsTxt.text = "Points: " + Points.ToString();
        if(Points >= threshold){
            CongoMessage.SetActive(true);
            gameover.SetActive(false);
            levelexp.SetActive(false);
        }
    
    }

    public void LevelExplorer(){
        SceneManager.LoadScene("LevelExplorer");
    }

    public void MainMenu(){
        SceneManager.LoadScene("Menu");
    }
}
