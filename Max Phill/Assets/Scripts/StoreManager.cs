using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject CoinText;
    public GameObject ScissorsText;
    public GameObject CoversText;

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

    void Start()
    {
        Debug.Log("Start Coins");
        Debug.Log(PlayerPrefs.GetInt("coins"));
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
}
