using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level1()
    {
        int currlevel = PlayerPrefs.GetInt("currlevel");
        Debug.Log(currlevel);
        if(currlevel >= 1){
            SceneManager.LoadScene("Level1");
            Debug.Log("Loaded");
        }
    }

    public void Level2()
    {
        int currlevel = PlayerPrefs.GetInt("currlevel");
        if(currlevel >= 2){
            SceneManager.LoadScene("Level2");
        }
    }

    public void Level3()
    {
        int currlevel = PlayerPrefs.GetInt("currlevel");
        if(currlevel >= 3){
            SceneManager.LoadScene("Level3");
        }
    }

    public void Store(){
        SceneManager.LoadScene("Store");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
