using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinGiTai : MonoBehaviour
{
    [SerializeField] int Point = 0;

    void Start(){
        Point = 0;
        Debug.Log("Battle");
    }

    public void Maai(int X1,int X2){
        int Maai = Mathf.Abs(X1-X2);
        int n=3;
        int m=5;

        if(n <= Maai && Maai <= m){
            Point=Point+1;
            Debug.Log(Point);
        }else{
            Debug.Log(Point);
        }
        
    }
    
}
