using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public static int[,] a = new int[,] { {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                                          {1,0,0,0,0,0,1,0,0,0,0,0,0,3,1},
                                          {1,0,1,1,1,0,0,0,0,0,0,0,0,0,1},
                                          {1,0,1,0,1,1,1,1,1,1,1,0,6,0,1},
                                          {1,0,1,0,1,0,1,0,0,0,1,0,0,0,1},
                                          {1,0,1,0,1,0,1,0,7,0,1,0,0,0,1},
                                          {1,0,1,0,0,0,0,0,0,0,1,0,0,0,1},
                                          {1,0,1,1,1,1,1,1,0,0,1,0,0,0,1},
                                          {1,0,0,0,0,0,5,0,0,0,1,0,0,0,1},
                                          {1,0,0,0,0,0,0,0,0,0,0,7,0,0,1},
                                          {1,0,1,1,1,1,1,1,1,0,0,0,0,0,1},
                                          {1,0,1,4,0,0,0,0,1,1,1,1,0,0,1},
                                          {1,0,1,0,0,0,0,0,1,1,1,1,0,0,1},
                                          {1,2,0,0,0,7,0,0,0,0,0,0,0,0,1},
                                          {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1} };

    public GameObject Cube;
    public GameObject Key;
    public GameObject Heart;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < a.GetLength(0); ++i)
        {
            for (int j = 0; j < a.GetLength(1); ++j)
            {
                if(a[i,j] == 1) //壁
                {
                    Vector3 pos = new Vector3(j + 1, 0, 16 - (i + 1));
                    Instantiate(Cube, pos, Quaternion.identity);
                }

                else if (a[i, j] == 4) //鍵A
                {
                    Vector3 pos = new Vector3(j + 1, 0, 16 - (i + 1));
                    Instantiate(Key, pos, Quaternion.identity);
                }

                else if (a[i, j] == 5) //鍵B
                {
                    Vector3 pos = new Vector3(j + 1, 0, 16 - (i + 1));
                    Instantiate(Key, pos, Quaternion.identity);
                }

                else if (a[i, j] == 6) //鍵C
                {
                    Vector3 pos = new Vector3(j + 1, 0, 16 - (i + 1));
                    Instantiate(Key, pos, Quaternion.identity);
                }

                else if (a[i, j] == 7) //回復
                {
                    Vector3 pos = new Vector3(j + 1, 0.3f, 16 - (i + 1));
                    Instantiate(Heart, pos, Quaternion.identity);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
