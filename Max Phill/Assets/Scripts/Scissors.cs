using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    // Start is called before the first frame update

    private string tag = "Shape";
    private bool selected = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0 && selected == false){

            Debug.Log("Clicked!!");
            RaycastHit2D hitinfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hitinfo.collider != null){
                Debug.Log("Hit");
                if(hitinfo.transform.CompareTag(tag) || hitinfo.transform.CompareTag("Cover")){

                    int scissor = PlayerPrefs.GetInt("scissors");
                    scissor = scissor - 1;
                    PlayerPrefs.SetInt("scissors", scissor);

                    selected = true;
                    Debug.Log("Name of the Selected Object");
                    Debug.Log(hitinfo.collider.name);
                    Debug.Log("Cutted");

                    Destroy(hitinfo.transform.gameObject);
                    change();
                }
            }
            else{
                change();
            }
        }
    }

    void OnEnable(){
        selected = false;
    }

    public void change(){

        GameObject selectionManager = GameObject.Find("SelectionManager");
        selectionManager.GetComponent<selectionManager>().enabled = true;

        GameObject Scissors = GameObject.Find("Scissors");
        Scissors.GetComponent<Scissors>().enabled = false;

    }
}
