using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeMngment : MonoBehaviour {

    GameObject uitext1;
    GameObject uitext2;

    [SerializeField] private MainMove MainMoveScript;
    [SerializeField] private MainMove2 MainMove2Script;

    // Use this for initialization
    void Start(){
        this.uitext1 = GameObject.Find("Text");
        this.uitext2 = GameObject.Find("Text2");

        GameObject MoveSphere = GameObject.Find("MoveSphere");
        MainMoveScript = MoveSphere.GetComponent<MainMove>();

        GameObject MoveSphere2 = GameObject.Find("MoveSphere2");
        MainMove2Script = MoveSphere2.GetComponent<MainMove2>();

    }
	// Update is called once per frame
	void Update () {
        this.uitext1.GetComponent<Text>().text = "Life " + MainMoveScript.GetLife1() + " / 3  " +
                                                 MainMoveScript.GetDirection1() + "\r\n" +
                                                 "Key" + " A " + MainMoveScript.GetKey1()[0] +
                                                 " B " + MainMoveScript.GetKey1()[1] +
                                                 " C " + MainMoveScript.GetKey1()[2] + 
                                                 " " + MainMoveScript.IsGoal1();

        this.uitext2.GetComponent<Text>().text = "Life " + MainMove2Script.GetLife2() + " / 3 " +
                                                 MainMove2Script.GetDirection2() + "\r\n" +
                                                 "Key" + " A " + MainMove2Script.GetKey2()[0] +
                                                 " B " + MainMove2Script.GetKey2()[1] +
                                                 " C " + MainMove2Script.GetKey2()[2] +
                                                 " " + MainMove2Script.IsGoal2();


    }
}
