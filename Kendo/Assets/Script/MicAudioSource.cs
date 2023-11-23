//MicAudioSource.cs
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
 
[SerializeField] public class MicAudioSource : MonoBehaviour
{
    //サンプリング周波数
    static readonly int SAMPLE_RATE = 48000;
 
    //この秒数の幅で振幅の平均値を取ったものでdB値を更新
    static readonly float MOVING_AVE_TIME = 0.05f;
 
    //MOVING_AVE_TIMEに相当するサンプル数
    static readonly int MOVING_AVE_SAMPLE = (int)(SAMPLE_RATE * MOVING_AVE_TIME);
 
    //マイクのClipをセットする為のAudioSource
    AudioSource micAS = null;
 
    //現在のdB値
    private float _now_dB;
    public float now_dB { get { return _now_dB; } }

    //public SinGiTai SGT;

    /*

    [SerializeField] float m_gain = 1000; // 音量に掛ける倍率
    float m_volumeRate; // 音量
    */
 
    private void Awake()
    {
        //AudioSourceコンポーネント取得
        micAS = GetComponent<AudioSource>();
    }
 
    void Start()
    {
        //フレーム更新開始直後にマイクデバイスをスタートする
        this.MicStart();
    }
 
    public void MicStart()
    {
        //AudioSourceのClipにマイクデバイスをセット
        micAS.clip = Microphone.Start(null, true, 1, SAMPLE_RATE);
 
        //マイクデバイスの準備ができるまで待つ
        while (!(Microphone.GetPosition("") > 0)) { }
 
        //AudioSouceからの出力を開始
        micAS.Play();
    }
 
    void Update()
    {
        if (micAS.isPlaying)
        {
            //GetOutputData用のバッファを準備
            float[] data = new float[MOVING_AVE_SAMPLE];
 
            //AudioSourceから出力されているサンプルを取得
            micAS.GetOutputData(data, 0);
 
            //バッファ内の平均振幅を取得（絶対値を平均する）
            float aveAmp = data.Average(s => Mathf.Abs(s));
             
            //振幅をdB（デシベル）に変換
            float dB = 20.0f * Mathf.Log10(aveAmp);
 
            //現在値（now_dB）を更新
            _now_dB = dB;

            //Debug.Log(dB);
 
        }

        
    }
/*
    //音量のうけわたし
    private void OnAudioFilterRead(float[] data, int channels)
    {
        float sum = 0f;
        for (int i = 0; i < data.Length; ++i)
        {
            sum += Mathf.Abs(data[i]); // データ（波形）の絶対値を足す
        }
        // データ数で割ったものに倍率をかけて音量とする
        m_volumeRate = Mathf.Clamp(sum * 10000 / (float)data.Length,0,80);
        Debug.Log(sum+"sum"+m_gain+"gain"+data.Length+"le");
    }
*/

    public float GetNow_dB(float dBValue){
        return dBValue;
    }
    
}