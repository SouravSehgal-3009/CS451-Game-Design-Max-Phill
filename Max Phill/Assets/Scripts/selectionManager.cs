using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectionManager : MonoBehaviour
{

    private bool selected;
    private Transform selection;
    private Vector2 position;
    private string name;
    private string tag = "Shape";
    private Vector3 rotation = new Vector3(0, 0, 1);

    private float speed = 0.5f;

    public OverlapManager om;
    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        selection = null;
    }

    // Update is called once per frame

    void FixedUpdate(){
        if(selected){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selection.position = Vector2.Lerp(selection.position, mousePos, speed);
        }
        if(selected && Input.GetAxis("Vertical") > 0){
            selection.eulerAngles = selection.eulerAngles + rotation*Input.GetAxis("Vertical");
        }
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0 && selection == null){

            Debug.Log("Clicked!!");
            RaycastHit2D hitinfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hitinfo.collider != null){
                Debug.Log("Hit");
                if(hitinfo.transform.CompareTag(tag)){
                    selected = true;
                    selection = hitinfo.transform;
                    position = hitinfo.transform.position;
                    name = hitinfo.collider.name.Replace("(Clone)", "");

                    Debug.Log("Name of the Selected Object");
                    Debug.Log(hitinfo.collider.name);
                }
            }
        }

        if(Input.GetMouseButtonDown(0) && selected != false){
            selected = false;

            int x = (int)((position.x + om.sw/2)*om.N/om.sw);
            int y = (int)((position.y + om.sh/2)*om.N/om.sh);
            om.decrement(x, y);  

            float penalty = om.getPenalty(x, y, name); 

            x = (int)((selection.position.x + om.sw/2)*om.N/om.sw);
            y = (int)((selection.position.y + om.sh/2)*om.N/om.sh);
        
            float penalty_new = om.getPenalty(x, y, name);

            PlayerPrefs.SetFloat("penalty", PlayerPrefs.GetFloat("penalty") + penalty_new - penalty);
            PlayerPrefs.SetInt("points", (int)(PlayerPrefs.GetInt("points") + penalty - penalty_new));

            om.increment(x, y);

            selection = null;
        }

        if(Input.GetMouseButtonDown(1)){
            Debug.Log("Changing!!");
            SceneManager.LoadScene("LevelExplorer");
        }
    }
}
