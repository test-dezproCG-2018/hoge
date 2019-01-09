using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMove2 : MonoBehaviour
{

    MainMove.Direction direction = MainMove.Direction.South;

    int moveFlagUp = 0; //北方向への移動
    int moveFlagDown = 0; //南方向への移動
    int moveFlagRight = 0; //東方向への移動
    int moveFlagLeft = 0; //西方向への移動

    int moveUp = 0;
    int moveDown = 0;
    int moveRight = 0;
    int moveLeft = 0;

    float nextXpos = 14; // 次の座標
    float nextZpos = 14;

    [SerializeField] private Gun GunScript;

    int life = 3; //ライフ
    int[] key = new int[] { 0, 0, 0 };
    int isGoal = 0;

    int delay = 3; //遅延


    // Use this for initialization
    void Start()
    {
        GameObject anotherObject = GameObject.Find("Gun");
        GunScript = anotherObject.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        float xpos = transform.position.x;
        float ypos = transform.position.y;
        float zpos = transform.position.z;

        if ((MazeGenerator.a[15 - (int)zpos, (int)xpos - 1] == 2) && (key[0] == 1) && (key[1] == 1) && (key[2] == 1)) //Goal
        {
            isGoal = 1;
        }


        if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 1] == 4) //keyA
        {
            key[0] = 1;
        }
        else if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 1] == 5) //keyB
        {
            key[1] = 1;
        }
        else if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 1] == 6) //keyC
        {
            key[2] = 1;
        }


        if (direction == MainMove.Direction.North) // 北向きの時
        {
            if (moveFlagUp == 1)
            {
                if (moveUp < 50)
                {
                    moveUp += 1;
                    Vector3 mv = new Vector3(0f, 0f, 0.02f);
                    transform.Translate(mv);
                }
                else if (moveUp == 50)
                {
                    moveUp = 0;
                    moveFlagUp = 0;
                    Vector3 pos = new Vector3(xpos, ypos, nextZpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.North;
                    }
                }
            }

            else if (moveFlagDown == 1)
            {
                if (moveDown < 50)
                {
                    moveDown += 1;
                    Vector3 mv = new Vector3(0f, 0f, -0.02f);
                    transform.Translate(mv);
                }
                else if (moveDown == 50)
                {
                    moveDown = 0;
                    moveFlagDown = 0;
                    Vector3 pos = new Vector3(xpos, ypos, nextZpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.South;
                    }
                }
            }

            else if (moveFlagRight == 1)
            {
                if (moveRight < 50)
                {
                    moveRight += 1;
                    Vector3 mv = new Vector3(0.02f, 0f, 0f);
                    transform.Translate(mv);
                }
                else if (moveRight == 50)
                {
                    moveRight = 0;
                    moveFlagRight = 0;
                    Vector3 pos = new Vector3(nextXpos, ypos, zpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.East;
                    }
                }
            }

            else if (moveFlagLeft == 1)
            {
                if (moveLeft < 50)
                {
                    moveLeft += 1;
                    Vector3 mv = new Vector3(-0.02f, 0f, 0f);
                    transform.Translate(mv);
                }
                else if (moveLeft == 50)
                {
                    moveLeft = 0;
                    moveFlagLeft = 0;
                    Vector3 pos = new Vector3(nextXpos, ypos, zpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.West;
                    }
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) - 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos + 1;
                        moveFlagUp = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) + 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos - 1;
                        moveFlagDown = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos] != 1)
                    {
                        nextXpos = nextXpos + 1;
                        moveFlagRight = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.A))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 2] != 1)
                    {
                        nextXpos = nextXpos - 1;
                        moveFlagLeft = 1;
                    }
                }
            }
        }

        else if (direction == MainMove.Direction.South) // 南向きの時
        {
            if (moveFlagUp == 1)
            {
                if (moveUp < 50)
                {
                    moveUp += 1;
                    Vector3 mv = new Vector3(0f, 0f, 0.02f);
                    transform.Translate(mv);
                }
                else if (moveUp == 50)
                {
                    moveUp = 0;
                    moveFlagUp = 0;
                    Vector3 pos = new Vector3(xpos, ypos, nextZpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.North;
                    }
                }
            }

            else if (moveFlagDown == 1)
            {
                if (moveDown < 50)
                {
                    moveDown += 1;
                    Vector3 mv = new Vector3(0f, 0f, -0.02f);
                    transform.Translate(mv);
                }
                else if (moveDown == 50)
                {
                    moveDown = 0;
                    moveFlagDown = 0;
                    Vector3 pos = new Vector3(xpos, ypos, nextZpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.South;
                    }
                }
            }

            else if (moveFlagRight == 1)
            {
                if (moveRight < 50)
                {
                    moveRight += 1;
                    Vector3 mv = new Vector3(0.02f, 0f, 0f);
                    transform.Translate(mv);
                }
                else if (moveRight == 50)
                {
                    moveRight = 0;
                    moveFlagRight = 0;
                    Vector3 pos = new Vector3(nextXpos, ypos, zpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.East;
                    }
                }
            }

            else if (moveFlagLeft == 1)
            {
                if (moveLeft < 50)
                {
                    moveLeft += 1;
                    Vector3 mv = new Vector3(-0.02f, 0f, 0f);
                    transform.Translate(mv);
                }
                else if (moveLeft == 50)
                {
                    moveLeft = 0;
                    moveFlagLeft = 0;
                    Vector3 pos = new Vector3(nextXpos, ypos, zpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.West;
                    }
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) + 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos - 1;
                        moveFlagDown = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) - 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos + 1;
                        moveFlagUp = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 2] != 1)
                    {
                        nextXpos = nextXpos - 1;
                        moveFlagLeft = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.A))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos] != 1)
                    {
                        nextXpos = nextXpos + 1;
                        moveFlagRight = 1;
                    }
                }
            }
        }

        else if (direction == MainMove.Direction.East) // 東向きの時
        {
            if (moveFlagUp == 1)
            {
                if (moveUp < 50)
                {
                    moveUp += 1;
                    Vector3 mv = new Vector3(0f, 0f, 0.02f);
                    transform.Translate(mv);
                }
                else if (moveUp == 50)
                {
                    moveUp = 0;
                    moveFlagUp = 0;
                    Vector3 pos = new Vector3(xpos, ypos, nextZpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.North;
                    }
                }
            }

            else if (moveFlagDown == 1)
            {
                if (moveDown < 50)
                {
                    moveDown += 1;
                    Vector3 mv = new Vector3(0f, 0f, -0.02f);
                    transform.Translate(mv);
                }
                else if (moveDown == 50)
                {
                    moveDown = 0;
                    moveFlagDown = 0;
                    Vector3 pos = new Vector3(xpos, ypos, nextZpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.South;
                    }
                }
            }

            else if (moveFlagRight == 1)
            {
                if (moveRight < 50)
                {
                    moveRight += 1;
                    Vector3 mv = new Vector3(0.02f, 0f, 0f);
                    transform.Translate(mv);
                }
                else if (moveRight == 50)
                {
                    moveRight = 0;
                    moveFlagRight = 0;
                    Vector3 pos = new Vector3(nextXpos, ypos, zpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.East;
                    }
                }
            }

            else if (moveFlagLeft == 1)
            {
                if (moveLeft < 50)
                {
                    moveLeft += 1;
                    Vector3 mv = new Vector3(-0.02f, 0f, 0f);
                    transform.Translate(mv);
                }
                else if (moveLeft == 50)
                {
                    moveLeft = 0;
                    moveFlagLeft = 0;
                    Vector3 pos = new Vector3(nextXpos, ypos, zpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.West;
                    }
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos] != 1)
                    {
                        nextXpos = nextXpos + 1;
                        moveFlagRight = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 2] != 1)
                    {
                        nextXpos = nextXpos - 1;
                        moveFlagLeft = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) + 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos - 1;
                        moveFlagDown = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.A))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) - 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos + 1;
                        moveFlagUp = 1;
                    }
                }
            }
        }

        else if (direction == MainMove.Direction.West) // 西向きの時
        {
            if (moveFlagUp == 1)
            {
                if (moveUp < 50)
                {
                    moveUp += 1;
                    Vector3 mv = new Vector3(0f, 0f, 0.02f);
                    transform.Translate(mv);
                }
                else if (moveUp == 50)
                {
                    moveUp = 0;
                    moveFlagUp = 0;
                    Vector3 pos = new Vector3(xpos, ypos, nextZpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.North;
                    }
                }
            }

            else if (moveFlagDown == 1)
            {
                if (moveDown < 50)
                {
                    moveDown += 1;
                    Vector3 mv = new Vector3(0f, 0f, -0.02f);
                    transform.Translate(mv);
                }
                else if (moveDown == 50)
                {
                    moveDown = 0;
                    moveFlagDown = 0;
                    Vector3 pos = new Vector3(xpos, ypos, nextZpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.South;
                    }
                }
            }

            else if (moveFlagRight == 1)
            {
                if (moveRight < 50)
                {
                    moveRight += 1;
                    Vector3 mv = new Vector3(0.02f, 0f, 0f);
                    transform.Translate(mv);
                }
                else if (moveRight == 50)
                {
                    moveRight = 0;
                    moveFlagRight = 0;
                    Vector3 pos = new Vector3(nextXpos, ypos, zpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.East;
                    }
                }
            }

            else if (moveFlagLeft == 1)
            {
                if (moveLeft < 50)
                {
                    moveLeft += 1;
                    Vector3 mv = new Vector3(-0.02f, 0f, 0f);
                    transform.Translate(mv);
                }
                else if (moveLeft == 50)
                {
                    moveLeft = 0;
                    moveFlagLeft = 0;
                    Vector3 pos = new Vector3(nextXpos, ypos, zpos);
                    transform.position = pos;

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        direction = MainMove.Direction.West;
                    }
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 2] != 1)
                    {
                        nextXpos = nextXpos - 1;
                        moveFlagLeft = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos] != 1)
                    {
                        nextXpos = nextXpos + 1;
                        moveFlagRight = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) - 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos + 1;
                        moveFlagUp = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.A))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) + 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos - 1;
                        moveFlagDown = 1;
                    }
                }
            }
        }

        // 被弾判定
        if (GunScript.IsFire())
        {
            if ((((int)GunScript.GetGunXpos() == nextXpos) && ((int)GunScript.GetGunZpos() == nextZpos + 1)) ||
                (((int)GunScript.GetGunXpos() == nextXpos) && ((int)GunScript.GetGunZpos() == nextZpos - 1)) ||
                (((int)GunScript.GetGunXpos() == nextXpos + 1) && ((int)GunScript.GetGunZpos() == nextZpos)) ||
                (((int)GunScript.GetGunXpos() == nextXpos - 1) && ((int)GunScript.GetGunZpos() == nextZpos)))
            {
                if (delay > 0)
                {
                    delay -= 1;
                }
                else
                {
                    if (life != 1)
                    {
                        life = life - 1;
                    }
                    else
                    {
                        life = 3;
                        Vector3 pos = new Vector3(14f, ypos, 14f);
                        transform.position = pos;
                        nextXpos = 14;
                        nextZpos = 14;

                    }
                    delay = 3;
                }
            }
        }

    }

    public MainMove.Direction GetDirection2()
    {
        return direction;
    }

    public float Getxpos2()
    {
        return nextXpos;
    }

    public float Getzpos2()
    {
        return nextZpos;
    }

    public int GetLife2()
    {
        return life;
    }

    public string IsGoal2()
    {
        if (isGoal == 0)
        {
            return "";
        }
        else
        {
            return "Goal!!!!!!";
        }
    }

    public int[] GetKey2()
    {
        return key;
    }
}