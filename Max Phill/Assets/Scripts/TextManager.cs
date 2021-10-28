using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public GameObject CoinText;
    public GameObject ScissorsText;
    public GameObject CoversText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TextMeshProUGUI ct = CoinText.GetComponent<TextMeshProUGUI>();
        ct.text = "Coins: " + PlayerPrefs.GetInt("coins");

        TextMeshProUGUI covertext = CoversText.GetComponent<TextMeshProUGUI>();
        covertext.text = "Covers: " + PlayerPrefs.GetInt("cover");

        TextMeshProUGUI scitext = ScissorsText.GetComponent<TextMeshProUGUI>();
        scitext.text = "Scissors: " + PlayerPrefs.GetInt("scissors");
    }

    void Update(){
        if(Input.GetMouseButtonDown(1)){
            Debug.Log("Changing!!");
            SceneManager.LoadScene("LevelExplorer");
        }
    }

}
