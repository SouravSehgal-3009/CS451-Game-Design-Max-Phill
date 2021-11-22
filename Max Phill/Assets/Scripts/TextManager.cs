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
    public GameObject PointsText;
    public GameObject LeftsText;
    public GameObject PenaltyText;
    public GameObject CropText;

    public GameObject pausePanel;
    public GameObject gameScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TextMeshProUGUI ct = CoinText.GetComponent<TextMeshProUGUI>();
        ct.text = "" + PlayerPrefs.GetInt("coins");

        TextMeshProUGUI covertext = CoversText.GetComponent<TextMeshProUGUI>();
        covertext.text = "" + PlayerPrefs.GetInt("cover");

        TextMeshProUGUI scitext = ScissorsText.GetComponent<TextMeshProUGUI>();
        scitext.text = "" + PlayerPrefs.GetInt("scissors");

        TextMeshProUGUI pointstext = PointsText.GetComponent<TextMeshProUGUI>();
        pointstext.text = "Points: " + PlayerPrefs.GetInt("points");

        TextMeshProUGUI leftstext = LeftsText.GetComponent<TextMeshProUGUI>();
        leftstext.text = "Left: " + PlayerPrefs.GetInt("left");

        TextMeshProUGUI penaltytext = PenaltyText.GetComponent<TextMeshProUGUI>();
        penaltytext.text = "Penalty: " + PlayerPrefs.GetFloat("penalty");

        TextMeshProUGUI croptext = CropText.GetComponent<TextMeshProUGUI>();
        croptext.text = "" + PlayerPrefs.GetInt("crop");
    }

    void Update(){
        if(Input.GetMouseButtonDown(1)){
            pausePanel.SetActive(true);
            gameScreen.SetActive(false);
        }
    }

}
