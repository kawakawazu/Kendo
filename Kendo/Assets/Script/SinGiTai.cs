using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinGiTai : MonoBehaviour
{
    [SerializeField] int Point = 0;
    public SinGiTai singitai;

    void Start(){
        Point = 0;
        Debug.Log("Battle");
    }

    public void Maai(float X1,float X2){
        float Maai = Mathf.Abs(X1-X2);
        int n=4;
        int m=10;

        if(n <= Maai && Maai <= m){
            Point=Point+1;
            Debug.Log("良");
        }else{
            Debug.Log("悪");
        }

        singitai.Sisei(Point);
    }

    void Sisei(int Point){
        Debug.Log("sisei");
        int Click=4;

        //3秒間{
        if (Input.GetKey(KeyCode.W))
        {
            Click++;
            Debug.Log(Click);
        }
        //0.2秒に一回Click--;}

        if(8<=Click){
            Point=Point+2;
            Debug.Log("良");
        }else if(4<=Click){
            Point=Point+1;
            Debug.Log("普");
        }else{
            Debug.Log("悪");
        }
    }
    
}
