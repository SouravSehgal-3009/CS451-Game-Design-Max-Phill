using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameOver gameOver;

    [SerializeField]
    private GameObject[] prefabs;
    public int left;
    private int randomInt;

    private Vector2 mousePos;
    private bool hold;

    void Start(){
        hold = false;
        PlayerPrefs.SetInt("left", left);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0 && hold == false){
            hold = true;
            if(left > 0) spawn();
            else gameOver.Setup(PlayerPrefs.GetInt("points"));
        }
        else if(Input.GetAxis("Horizontal") == 0) hold = false;
    }

    void spawn(){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        randomInt = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[randomInt], mousePos, Quaternion.identity);

        int points = PlayerPrefs.GetInt("points");
        points = points + PlayerPrefs.GetInt(prefabs[randomInt].name);
        PlayerPrefs.SetInt("points", points);
        
        left = left - 1; 
        PlayerPrefs.SetInt("left", left);
    }
}
