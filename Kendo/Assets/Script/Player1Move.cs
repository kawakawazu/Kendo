using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player1Move : MonoBehaviour
{
    public SinGiTai singitai;
    public Player2Move P2M;

    public GameObject guide01;
    public GameObject STOP;
    public GameObject WIN;

    int YUKOUDA=0;

    //bool CanMove=true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Kutin(guide01));
        //Moving();
    }

    // x軸方向の移動範囲の最小値
    [SerializeField] private float _minX;

    // x軸方向の移動範囲の最大値
    [SerializeField] private float _maxX;

    // Update is called once per frame
    void Update()
    {
        Moving();
        /*
        if (Input.GetKeyDown(KeyCode.Space))
            {
                CanMove=false;
            }
            */
    }

    public void Moving(){

        // Aが押されたときに左に移動
        
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-0.5f, 0, 0);
            }

            // Dが押されたときに右に移動
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(0.5f, 0, 0);
            }

            var pos = transform.position;

            // x軸方向の移動範囲制限
            pos.x = Mathf.Clamp(pos.x, _minX, _maxX);

            transform.position = pos;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                singitai.Maai(pos.x,P2M.Player2pos.x);  
            }
    }

    public IEnumerator Judge(int IPPON){
        YUKOUDA=YUKOUDA+IPPON;
        if(YUKOUDA==3){

            StartCoroutine(Kutin(STOP));
            yield return new WaitForSeconds(2);
 
            WIN.gameObject.SetActive (true);
            Debug.Log("勝利");
        }else{
            Moving();
        }
    }


    IEnumerator Kutin(GameObject HanteiBatch) 
{
    HanteiBatch.gameObject.SetActive (true);
 
    //2秒待つ
    yield return new WaitForSeconds(2);
 
    HanteiBatch.gameObject.SetActive (false);

    yield break;
}

}
