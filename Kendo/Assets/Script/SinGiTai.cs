using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinGiTai : MonoBehaviour
{
    [SerializeField] int Point = 0;
    public SinGiTai singitai;

    public GameObject Best;
    public GameObject Good;
    public GameObject Bad;


    void Start(){
        Point = 0;//初期化（いるのか？）
        Debug.Log("Battle");
    }

    //間合いの判定
    public void Maai(float X1,float X2){
        float Maai = Mathf.Abs(X1-X2);
        int n=4;
        int m=10;

        if(n <= Maai && Maai <= m){
            Point=Point+1;
            Debug.Log(Point);
            StartCoroutine(Kutin(Best));
            Debug.Log("Best");
        }else{
            StartCoroutine(Kutin(Bad));
        }
        singitai.Sisei(Point);
    }

    //姿勢の判定
    void Sisei(int Point){
        Debug.Log("sisei");
        int Click=4;
        //bool Mode=true;

        //3秒間
        //whileが無限ループになってるからフリーズする
        //Debug.Log(Mode);
        //StartCoroutine(TimeCount(3.0f,Click));
        //Debug.Log(Mode);
       
        /*
           while(Mode==true){
                
                if (Input.GetKey(KeyCode.W)){
                    Click++;
                    Debug.Log(Click);
                }

                StartCoroutine(TimeCount(0.2f));
                Click--;
            }
           */ 
           for (int i = 1 ; i < 4 ; i++ )
        {
            if (Input.GetKey(KeyCode.W)){
                    Click++;
                    Debug.Log(Click);
                }else{
                    Click--;
                }

            StartCoroutine(TimeCount(2.0f));
        }
            
            //Debug.Log(Mode);

        if(8<=Click){
            Point=Point+2;
            Debug.Log("良");
            StartCoroutine(Kutin(Best));
        }else if(4<=Click){
            Point=Point+1;
            Debug.Log("普");
            StartCoroutine(Kutin(Good));
        }else{
            Debug.Log("悪");
            StartCoroutine(Kutin(Bad));
        }
    }


//判定の画像表示コルーチン
    IEnumerator Kutin(GameObject HanteiBatch) 
{
    HanteiBatch.gameObject.SetActive (true);
 
    //2秒待つ
    yield return new WaitForSeconds(2);
 
    HanteiBatch.gameObject.SetActive (false);

    yield break;
} 

//時間数える
    IEnumerator TimeCount(float time) 
    {
        for (int i = 1 ; i < time+1 ; i++ )
        {
            /*
            if (Input.GetKey(KeyCode.W)){
                    Click++;
                    Debug.Log(Click);
                }else{
                    Click--;
                }
                */

            Debug.Log("今" + i + "秒です");
            yield return new WaitForSeconds(1.0f);
            if (i == time)
            {
                Debug.Log("コルーチンを終了しました");
                //yield return Click;
                yield break;
             }
         }
    }
    
    
}
