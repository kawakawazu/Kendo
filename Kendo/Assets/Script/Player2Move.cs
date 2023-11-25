using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    public Vector3 Player2pos;

    // x軸方向の移動範囲の最小値
    [SerializeField] private float _minX;

    // x軸方向の移動範囲の最大値
    [SerializeField] private float _maxX;

    public bool isStop;
    float V;

    // Start is called before the first frame update
    void Start()
    {
        //Player2pos = pos.x;
        //Moving();
        isStop = false;
        Moving(isStop);
    }

    //Update is called once per frame
    void Update()
    {
        Moving(isStop);

        if (Input.GetKeyDown(KeyCode.Space) && !isStop)
        {
            isStop = true;
        }
        
        else if (Input.GetKeyDown(KeyCode.Space) && isStop)
        {
            isStop = false;
        }
        
    }

    public void Moving(bool isStop){

        transform.position= new Vector3(Mathf.Sin(Time.time)*V+Player2pos.x,-1.6f,Player2pos.z);

        if (isStop)//falseの時
        {
            V = 0f;
        }
        else if (!isStop)//falseじゃないとき
        {
            V = 10.0f;
        }
    }
}
