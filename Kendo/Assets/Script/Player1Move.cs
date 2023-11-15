using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    public SinGiTai singitai;
    public Player2Move P2M;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // x軸方向の移動範囲の最小値
    [SerializeField] private float _minX;

    // x軸方向の移動範囲の最大値
    [SerializeField] private float _maxX;

    // Update is called once per frame
    void Update()
    {
        // Aが押されたときに左に移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1, 0, 0);
        }

        // Dが押されたときに右に移動
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1, 0, 0);
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
}
