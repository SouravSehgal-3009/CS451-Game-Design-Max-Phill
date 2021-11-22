using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject CoinText;
    public GameObject ScissorsText;
    public GameObject CoversText;
    public GameObject CropText;

    public void BuyScissors(){

        int coins = PlayerPrefs.GetInt("coins");
        if(coins >= 100){
            coins = coins - 100;
            int scissors = PlayerPrefs.GetInt("scissors");
            PlayerPrefs.SetInt("scissors", scissors + 1);
        }
        PlayerPrefs.SetInt("coins", coins);
    }

    public void BuyCover(){

        int coins = PlayerPrefs.GetInt("coins");
        if(coins >= 250){
            coins = coins - 250;
            int cover = PlayerPrefs.GetInt("cover");
            PlayerPrefs.SetInt("cover", cover + 1);
        }
        PlayerPrefs.SetInt("coins", coins);
    }

    public void BuyCrop(){

        int coins = PlayerPrefs.GetInt("coins");
        if(coins >= 300){
            coins = coins - 300;
            int crop = PlayerPrefs.GetInt("crop");
            PlayerPrefs.SetInt("crop", crop + 1);
        }
        PlayerPrefs.SetInt("coins", coins);
    }

    public void goBack(){
        SceneManager.LoadScene("LevelExplorer");
    }

    void Start()
    {
        Debug.Log("Start Coins");
        Debug.Log(PlayerPrefs.GetInt("coins"));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Text ct = CoinText.GetComponent<Text>();
        ct.text = "Coins: " + PlayerPrefs.GetInt("coins");

        Text covertext = CoversText.GetComponent<Text>();
        covertext.text = "Covers: " + PlayerPrefs.GetInt("cover");

        Text scitext = ScissorsText.GetComponent<Text>();
        scitext.text = "Scissors: " + PlayerPrefs.GetInt("scissors");

        Text croptext = CropText.GetComponent<Text>();
        croptext.text = "Crops: " + PlayerPrefs.GetInt("Crops");
    }

}
