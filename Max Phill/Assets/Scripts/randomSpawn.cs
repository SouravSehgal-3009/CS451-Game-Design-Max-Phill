using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public OverlapManager om;
    public GameOver gameOver;
    public GameObject parent;
    public GameEnd gameend;

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
                parent.SetActive(false);
                int current=PlayerPrefs.GetInt("currlevel");
                Debug.Log("Current"+current);
                if (current==6)
                {
                    gameend.Setup(PlayerPrefs.GetInt("points"));
                }
                else
                {
                    gameOver.Setup(PlayerPrefs.GetInt("points"));
                }
            }
        }
        else if(Input.GetAxis("Horizontal") == 0) hold = false;
    }

    void spawn(){
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        int x = (int)((mousePos.x + om.sw/2)*om.N/om.sw);
        int y = (int)((mousePos.y + om.sh/2)*om.N/om.sh);

        if(y > 13){
            return;
        }

        randomInt = Random.Range(0, prefabs.Length);

        GameObject new_init = Instantiate(prefabs[randomInt], mousePos, Quaternion.identity);
        new_init.transform.SetParent(parent.GetComponent<Transform>());

        // new_init.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        int points = PlayerPrefs.GetInt("points");
        points = points + PlayerPrefs.GetInt(prefabs[randomInt].name);
        
        Debug.Log(mousePos.x + ", " + mousePos.y);
        
        

        int overlaps = om.getValue(x, y);
        float penalty = om.getPenalty(x, y, prefabs[randomInt].name);

        points = (int)(points - penalty);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetFloat("penalty", penalty + PlayerPrefs.GetFloat("penalty"));

        om.increment(x, y);

        Debug.Log(x + ", " + y);

        left = left - 1; 
        PlayerPrefs.SetInt("left", left);
    }
}
