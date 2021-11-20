using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PowerManager : MonoBehaviour
{

    [SerializeField]
    private GameObject cover_Prefab;

    RectTransform rf;
    float height, width;

    public OverlapManager om;

    void Start(){
        
    }

    public void Cover(){
        int cover = PlayerPrefs.GetInt("cover");

        if(cover > 0){
            cover = cover - 1;

            PlayerPrefs.SetInt("cover", cover);

            GameObject new_object = (GameObject)Instantiate(cover_Prefab, new Vector2(0, 0), Quaternion.identity);

            rf = (RectTransform)new_object.transform;

            height = rf.rect.height;
            width = rf.rect.width;

            float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + height, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - height);
            float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + width, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - width);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

            int x = (int)((spawnX + om.sw/2)*om.N/om.sw);
            int y = (int)((spawnY + om.sh/2)*om.N/om.sh);

            float penalty = om.getPenalty(x, y, "coverarea");

            om.increment(x, y);

            float theta = Random.Range(0, 175); 
            
            new_object.transform.position = spawnPosition;
            new_object.transform.eulerAngles = new Vector3(0, 0, theta);

            int points = PlayerPrefs.GetInt("points");
            points = (int)(points + 50 - penalty);

            PlayerPrefs.SetInt("points", points);
            PlayerPrefs.SetFloat("penalty", penalty + PlayerPrefs.GetFloat("penalty"));
        }
    }

    public void Scissor(){

        int scissors = PlayerPrefs.GetInt("scissors");

        if(scissors > 0){
            GameObject selectionManager = GameObject.Find("SelectionManager");
            selectionManager.GetComponent<selectionManager>().enabled = false;

            GameObject Scissors = GameObject.Find("Scissors");
            Scissors.GetComponent<Scissors>().enabled = true;
        }

    }
}
