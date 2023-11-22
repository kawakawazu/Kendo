using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SinGiTai : MonoBehaviour
{
    [SerializeField] int Point = 0;
    public SinGiTai singitai;

    public GameObject Best;
    public GameObject Good;
    public GameObject Bad;

    public GameObject SiseiMeter;
    public GameObject KiseiMeter;
    public GameObject Microphone;

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
        //singitai.Sisei(Point);
        StartCoroutine(Sisei(Point));
    }

    //姿勢の判定
    IEnumerator Sisei(int Point){
        Debug.Log("sisei");
        float Click=0;
        //float Time = 3f;

        SiseiMeter.gameObject.SetActive (true);

        //StartCoroutine(CountButtonClicks(Click,Time));
        yield return CountButtonClicks(x => Click = x);

            //Debug.Log("3秒間のクリック回数: " + Click); // 結果を表示
        
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
        
        SiseiMeter.gameObject.SetActive (false);
        //singitai.Kisei(Point);
        StartCoroutine(Kisei(Point));
            
    }

    IEnumerator Kisei(int Point){
        float MaxdB=0;

        Debug.Log("気勢");
        KiseiMeter.gameObject.SetActive (true);
        Microphone.gameObject.SetActive (true);

        //float timer = 3f; // カウントする時間（秒）
        for (float timer=3f;timer > 0f;timer -= Time.deltaTime)
        {
            /*
            if(micValueS.modified_dB > MaxdB){
                MaxdB = micValueS.modified_dB;
            }
            */
            Debug.Log(timer);
            //timer -= Time.deltaTime; // 時間を減らす
            yield return null; // 次のフレームまで待機
        }

        Debug.Log(MaxdB);

        if(60<=MaxdB&&MaxdB<75){
                Point=Point+2;
                Debug.Log("良");
                StartCoroutine(Kutin(Best));
            }else if(50<=MaxdB&&MaxdB<60){
                Point=Point+1;
                Debug.Log("普");
                StartCoroutine(Kutin(Good));
            }else if(75<=MaxdB||MaxdB<50){
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

private System.Collections.IEnumerator CountButtonClicks(Action<float> callback)
    {
        float timer = 3f; // カウントする時間（秒）
        float Click=4f;

        while (timer > 0f)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Click++; // スペースキーが押されたらカウントを増やす
            }else{
                Click = Click-0.03f;
            }

            timer -= Time.deltaTime; // 時間を減らす
            yield return null; // 次のフレームまで待機
        }

        Debug.Log("3秒間のクリック回数: " + Click); // 結果を表示
        callback.Invoke(Click);
        /*
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
            */
    }
    
    
}
