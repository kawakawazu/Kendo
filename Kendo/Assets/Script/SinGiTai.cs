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
    public GameObject Attack;

    public GameObject IPPON;
    public GameObject MUKOU;
    public GameObject MISS;

    public GameObject SiseiMeter;
    public GameObject KiseiMeter;
    public GameObject Microphone;

    //public LevelMeter LM;
    public MicAudioSource micAS;
    public Player1Move P1;

    void Start(){
        Point = 0;//初期化（いるのか？）
        Debug.Log("Battle");
    }

    //間合いの判定
    public void Maai(float X1,float X2){
        Point = 0;
        float Maai = Mathf.Abs(X1-X2);
        int n=4;
        int m=20;

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
        float dB_Min= -80.0f;
        float dB_Max = -0.0f;
        float dB_valueMax=dB_Min;

        Debug.Log("気勢");
        //Debug.Log(dB_valueMax);
        KiseiMeter.gameObject.SetActive (true);
        Microphone.gameObject.SetActive (true);

        //float timer = 3f; // カウントする時間（秒）
        for (float timer=3f;timer > 0f;timer -= Time.deltaTime)
        {
            /*
            Debug.Log(micAS.now_dB+"転送後");
            if(dB_valueMax < micAS.now_dB){
                Debug.Log(dB_valueMax+"いま");
                dB_valueMax = micAS.now_dB;
            }
            */
            dB_valueMax = micAS.now_dB;
            
            //Debug.Log("時間"+timer);
            //Debug.Log("dB"+dB_valueMax);
            timer -= Time.deltaTime; // 時間を減らす
            yield return null; // 次のフレームまで待機
        }
        KiseiMeter.gameObject.SetActive (false);
        Microphone.gameObject.SetActive (false);
        Debug.Log("dB"+dB_valueMax);


        if(-20 <= dB_valueMax && dB_valueMax <= dB_Max){
                Point=Point+2;
                Debug.Log("良");
                StartCoroutine(Kutin(Best));
            }else if(-40 <= dB_valueMax && dB_valueMax < -20){
                Point=Point+1;
                Debug.Log("普");
                StartCoroutine(Kutin(Good));
            }else if(dB_valueMax < -40){
                Debug.Log("悪");
                StartCoroutine(Kutin(Bad));
            }

            StartCoroutine(Result(Point));
    }

    IEnumerator Result(int Point) 
{
    StartCoroutine(Kutin(Attack));

    yield return new WaitForSeconds(2);

    if(4<=Point){
                Debug.Log("一本");
                StartCoroutine(Kutin(IPPON));
                P1.Judge(1);
            }else if(2 <= Point&&Point < 4){
                Debug.Log("無効");
                StartCoroutine(Kutin(MUKOU));
                P1.Judge(0);
            }else{
                Debug.Log("失敗");
                StartCoroutine(Kutin(MISS));
                P1.Judge(0);
            }
    yield break;
} 



//判定の画像表示コルーチン
    public IEnumerator Kutin(GameObject HanteiBatch) 
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
