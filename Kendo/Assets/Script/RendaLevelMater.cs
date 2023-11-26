//LevelMeter.cs
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
[SerializeField] public class RendaLevelMater : MonoBehaviour
{
    //更新する対象のlevelMeter(uGUI Image)
    Image RlevelmeterImage = null;
 
    //このWでlevelMeter表示の下限に到達する
    [SerializeField]
    private float W_Min= 2f;
 
    //このWでlevelMeter表示の上限に到達する
    [SerializeField]
    private float W_Max = 0f;
     
    //Wを取得する対象のmicAudioSource
    [SerializeField]
    private SinGiTai singitai = null;

    public float modified_W;
 
    void Awake()
    {
        //更新する対象のImageを取得
        RlevelmeterImage = GetComponent<Image>();
        Debug.Log("singitai.Click");
    }
 
    void Update()
    {
        
        //W値からRlevelmeterImage用のfillAountの値に変換
        float fillAmountValue = W_ToFillAmountValue(singitai.Click);
        
        //fillAmount値更新
        this.RlevelmeterImage.fillAmount = fillAmountValue;
    }
 
    /// <summary>
    /// W_MinとW_Maxに基づいてWをfillAmount値に変換
    /// </summary>
    /// <param name="W">W値</param>
    /// <returns>fillAmount値</returns>
   public float W_ToFillAmountValue(float W)
    {
        
        //入力されたWをW_MaxとWMin値で切り捨て
        modified_W = W;
        if (modified_W > W_Max) { modified_W = W_Max; }
        else if (modified_W < W_Min) { modified_W = W_Min; }

        
 
        //fillAmount値に変換(W_Min=0.0f, W_Max=1.0f)
        float fillAountValue = 1.0f + (modified_W / (W_Max - W_Min));
        return fillAountValue;
    }

}