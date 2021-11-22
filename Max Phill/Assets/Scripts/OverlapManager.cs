using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class OverlapManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int N;

    public int[,] count;

    public float sh;
    public float sw;

    void Awake(){
        sh = 2*Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        sw = 2*Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
    }
    void Start()
    {
        count = new int[N, N];
        sh = 2*Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        sw = 2*Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        for(int i = 0; i < N; i++){
            for(int j = 0; j < N; j++){
                count[i, j] = 0;
            }
        }

        Debug.Log(sw + ", " + sh);
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

    public float getPenalty(int x, int y, string Name){
        
        int i = 1;
        if(Name.EndsWith("H1") || Name.EndsWith("H2")){
            i = 2;
        }

        Name = Name.Replace("H1", "");
        Name = Name.Replace("H2", "");

        int overlaps = getValue(x, y);
        float penalty = Mathf.Min(overlaps * PlayerPrefs.GetInt(Name)/8,
                                 PlayerPrefs.GetInt(Name)/i + 10/i);

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
