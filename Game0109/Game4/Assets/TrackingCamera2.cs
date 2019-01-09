﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera2 : MonoBehaviour
{

    public GameObject player;       //プレイヤーゲームオブジェクトへの参照を格納する Public 変数
    private Vector3 offset;         //プレイヤーとカメラ間のオフセット距離を格納する Public 変数


    // Use this for initialization
    void Start()
    {
        //プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        transform.position = player.transform.position + offset;
    }
}