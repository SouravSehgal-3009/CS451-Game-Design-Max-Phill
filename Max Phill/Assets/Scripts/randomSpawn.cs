﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public OverlapManager om;
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

        Debug.Log("ScreenWidth and ScreenHeight");
        Debug.Log(om.sw + ", " + om.sh);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0 && hold == false){
            hold = true;
            if(left > 0){
                spawn();
                // om.increment();
            }
            else { 
                om.display();
                gameOver.Setup(PlayerPrefs.GetInt("points"));
            }
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
        
        Debug.Log(mousePos.x + ", " + mousePos.y);
        
        int x = (int)((mousePos.x + om.sw/2)*om.N/om.sw);
        int y = (int)((mousePos.y + om.sh/2)*om.N/om.sh);

        int overlaps = om.getValue(x, y);
        float penalty = om.getPenalty(x, y, prefabs[randomInt].name);

        points = (int)(PlayerPrefs.GetInt("points") - penalty);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetFloat("penalty", penalty + PlayerPrefs.GetFloat("penalty"));

        om.increment(x, y);

        Debug.Log(x + ", " + y);

        left = left - 1; 
        PlayerPrefs.SetInt("left", left);
    }
}
