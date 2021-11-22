using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cropping : MonoBehaviour
{
    public OverlapManager om;
    public GameObject parent;
    private string tag = "Shape";
    private bool selected = false;

    public GameObject[] Halves;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0 && selected == false){

            RaycastHit2D hitinfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hitinfo.collider != null){
                if(hitinfo.transform.CompareTag(tag)){
                    
                    selected = true;

                    int crop = PlayerPrefs.GetInt("crop");
                    crop = crop - 1;
                    PlayerPrefs.SetInt("crop", crop);

                    string Name = hitinfo.collider.name.Replace("(Clone)", "");

                    if(Name.EndsWith("H1") || Name.EndsWith("H2")){
                        selected = false;
                        change();
                    }

                    else{
                        int points = PlayerPrefs.GetInt("points");
                        points = points - PlayerPrefs.GetInt(Name);
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
                        
                        init(Name, pos);

                        Destroy(hitinfo.transform.gameObject);

                        change();
                    }
                }
            }
            else{
                change();
            }
        }
    }

    private void init(string Name, Vector2 pos){
        foreach(GameObject obj in Halves){
            string objName = obj.name;
            Debug.Log(objName + "\n");
            objName = objName.Replace("H1", "");
            objName = objName.Replace("H2", "");
            if(objName == Name){
                spawn(obj, objName, pos);
            }
        }
    }

    private void spawn(GameObject obj, string Name, Vector2 pos){

        GameObject new_init = Instantiate(obj, pos, Quaternion.identity);
        new_init.transform.SetParent(parent.GetComponent<Transform>());

        // new_init.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        int points = PlayerPrefs.GetInt("points");
        points = points + (int)PlayerPrefs.GetInt(Name)/2 - 5;
        
        int x = (int)((pos.x + om.sw/2)*om.N/om.sw);
        int y = (int)((pos.y + om.sh/2)*om.N/om.sh);

        int overlaps = om.getValue(x, y);
        float penalty = om.getPenalty(x, y, Name);

        points = (int)(points - penalty);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetFloat("penalty", penalty + PlayerPrefs.GetFloat("penalty"));

        om.increment(x, y);

        Debug.Log("Spawed!!");
    }

    void OnEnable(){
        selected = false;
    }

    public void change(){

        GameObject selectionManager = GameObject.Find("SelectionManager");
        selectionManager.GetComponent<selectionManager>().enabled = true;

        GameObject CropObj = GameObject.Find("CropManager");
        CropObj.GetComponent<Cropping>().enabled = false;

    }
}
