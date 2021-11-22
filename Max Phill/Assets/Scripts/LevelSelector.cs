using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level1()
    {
        int maxlevel = PlayerPrefs.GetInt("maxlevel");
        if(maxlevel >= 1){
            PlayerPrefs.SetInt("points", 0);
            PlayerPrefs.SetInt("penalty", 0);
            SceneManager.LoadScene("Level1");
            Debug.Log("Loaded");
        }
    }

    public void Level2()
    {

        int maxlevel = PlayerPrefs.GetInt("maxlevel");
        if(maxlevel >= 2){
            PlayerPrefs.SetInt("currlevel", maxlevel);
            PlayerPrefs.SetInt("points", 0);
            PlayerPrefs.SetInt("penalty", 0);
            SceneManager.LoadScene("Level2");
        }
    }

    public void Level3()
    {
        int maxlevel = PlayerPrefs.GetInt("maxlevel");
        if(maxlevel >= 3){
            PlayerPrefs.SetInt("currlevel", maxlevel);
            PlayerPrefs.SetInt("points", 0);
            PlayerPrefs.SetInt("penalty", 0);
            SceneManager.LoadScene("Level3");
        }
    }

    public void Level4()
    {
        int maxlevel = PlayerPrefs.GetInt("maxlevel");
        if(maxlevel >= 4){
            PlayerPrefs.SetInt("currlevel", maxlevel);
            PlayerPrefs.SetInt("points", 0);
            PlayerPrefs.SetInt("penalty", 0);
            SceneManager.LoadScene("Level4");
        }
    }

    public void Level5()
    {
        int maxlevel = PlayerPrefs.GetInt("maxlevel");
        if(maxlevel >= 5){
            PlayerPrefs.SetInt("currlevel", maxlevel);
            PlayerPrefs.SetInt("points", 0);
            PlayerPrefs.SetInt("penalty", 0);
            SceneManager.LoadScene("Level5");
        }
    }

    public void Level6()
    {
        int maxlevel = PlayerPrefs.GetInt("maxlevel");
        if(maxlevel >= 6){
            PlayerPrefs.SetInt("currlevel", maxlevel);
            PlayerPrefs.SetInt("points", 0);
            PlayerPrefs.SetInt("penalty", 0);
            SceneManager.LoadScene("Level6");
        }
    }

    public void Store(){
        SceneManager.LoadScene("Store");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
