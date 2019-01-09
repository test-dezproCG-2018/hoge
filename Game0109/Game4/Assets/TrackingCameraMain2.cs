using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCameraMain2 : MonoBehaviour
{

    public GameObject player;       //プレイヤーゲームオブジェクトへの参照を格納する Public 変数

    private Vector3 offsetNorth = new Vector3(0f, 0.25f, -1.5f);    //プレイヤーとカメラ間のオフセット距離を格納する Public 変数
    private Vector3 offsetSouth = new Vector3(0f, 0.25f, 1.5f);
    private Vector3 offsetEast = new Vector3(-1.5f, 0.25f, 0f);
    private Vector3 offsetWest = new Vector3(1.5f, 0.25f, 0f);


    [SerializeField] private MainMove2 MainMove2Script;


    // Use this for initialization
    void Start()
    {
        MainMove2Script = player.GetComponent<MainMove2>();
    }

    // Update is called once per frame
    void Update()
    {

        if (MainMove2Script.GetDirection2() == MainMove.Direction.North)
        {
            transform.position = player.transform.position + offsetNorth;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        else if (MainMove2Script.GetDirection2() == MainMove.Direction.South)
        {
            transform.position = player.transform.position + offsetSouth;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (MainMove2Script.GetDirection2() == MainMove.Direction.East)
        {
            transform.position = player.transform.position + offsetEast;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        if (MainMove2Script.GetDirection2() == MainMove.Direction.West)
        {
            transform.position = player.transform.position + offsetWest;
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
    }
}