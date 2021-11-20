using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class OverlapManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int N = 20;
    public int[,] count = new int[20, 20];

    public float sh;
    public float sw;

    void Awake(){
        sh = 2*Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        sw = 2*Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
    }
    void Start()
    {
        for(int i = 0; i < N; i++){
            for(int j = 0; j < N; j++){
                count[i, j] = 0;
            }
        }
    }

    public void increment(int x, int y){
        for(int i = -2; i <= 2; i++){
            if(x + i >= 0 && x + i < N){
                count[x+i, y] = count[x+i, y] + 1;
            }
        }
        for(int i = -2; i <= 2; i++){
            if(y + i >= 0 && y + i < N){
                count[x, y+i] = count[x, y+i] + 1;
            }
        }
    }

    public void decrement(int x, int y){
        for(int i = -2; i <= 2; i++){
            if(x + i >= 0 && x + i < N){
                count[x+i, y] = count[x+i, y] - 1;
            }
        }
        for(int i = -2; i <= 2; i++){
            if(y + i >= 0 && y + i < N){
                count[x, y+i] = count[x, y+i] - 1;
            }
        }
    }

    public int getValue(int x, int y){
        int overlaps = 0;
        for(int i = -2; i <= 2; i++){
            if(x + i >= 0 && x + i < N){
                overlaps = overlaps + count[x+i, y];
            }
        }
        for(int i = -2; i <= 2; i++){
            if(y + i >= 0 && y + i < N){
                overlaps = overlaps + count[x, y+i];
            }
        }

        return overlaps;
    }

    public float getPenalty(int x, int y, string name){
        int overlaps = getValue(x, y);
        float penalty = Mathf.Min(overlaps * PlayerPrefs.GetInt(name)/8 + PlayerPrefs.GetFloat("penalty"),
                                 PlayerPrefs.GetInt(name) + 10);

        return penalty;
    }

    public void display(){
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < N; i++){
            for(int j = 0; j < N; j++){
                sb.Append(count[i, j]);
                sb.Append(' ');				   
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }
}
