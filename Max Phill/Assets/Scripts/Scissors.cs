using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    // Start is called before the first frame update

    public OverlapManager om;
    private string tag = "Shape";
    private bool selected = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0 && selected == false){

            // Debug.Log("Clicked!!");
            RaycastHit2D hitinfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hitinfo.collider != null){
                // Debug.Log("Hit");
                if(hitinfo.transform.CompareTag(tag) || hitinfo.transform.CompareTag("Cover")){

                    int scissor = PlayerPrefs.GetInt("scissors");
                    scissor = scissor - 1;
                    PlayerPrefs.SetInt("scissors", scissor);

                    selected = true;
                    // Debug.Log("Name of the Selected Object");
                    // Debug.Log(hitinfo.collider.name);
                    // Debug.Log("Cutted");
                    
                    int i = 1;
                    string Name = hitinfo.collider.name.Replace("(Clone)", "");
                    if(Name.EndsWith("H1") || Name.EndsWith("H2")){
                        i = 2;
                    }
                    Name = Name.Replace("H1", "");
                    Name = Name.Replace("H2", "");

                    int points = PlayerPrefs.GetInt("points");
                    points = points - (int)PlayerPrefs.GetInt(Name)/i;
                    PlayerPrefs.SetInt("points", points);
                    
                    Vector2 pos = hitinfo.transform.position;
                
                    int x = (int)((pos.x + om.sw/2)*om.N/om.sw);
                    int y = (int)((pos.y + om.sh/2)*om.N/om.sh);

                    om.decrement(x, y);

                    float penalty = om.getPenalty(x, y, Name);
                    if(penalty > PlayerPrefs.GetFloat("penalty")){
                        penalty = PlayerPrefs.GetFloat("penalty");
                    }
                    PlayerPrefs.SetFloat("penalty", PlayerPrefs.GetFloat("penalty") - penalty);

                    PlayerPrefs.SetInt("points", (int)(PlayerPrefs.GetInt("points") + penalty));

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
