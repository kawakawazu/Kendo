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
    // Start is called before the first frame update
    void Start()
    {
        //Player2pos = pos.x;
    }

    //Update is called once per frame
    void Update()
    {
        //transform.position= new Vector3(Mathf.Sin(Time.time)*10.0f+Player2pos.x,Player2pos.y,Player2pos.z);
        Moving();
    }

    void Moving(){
        transform.position= new Vector3(Mathf.Sin(Time.time)*10.0f+Player2pos.x,Player2pos.y,Player2pos.z);
    }
}
