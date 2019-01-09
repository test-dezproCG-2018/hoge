using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMove : MonoBehaviour
{

    public enum Direction { North, South, East, West };

    Dictionary<Direction, float> PlayerDirection = new Dictionary<Direction, float>()
    {
        {Direction.North, 0f},
        {Direction.South, 180f},
        {Direction.East, 90f},
        {Direction.West, -90f}
    };

    Direction direction = Direction.North;

    private Animator animator;
    int moveFlagUp = 0;
    int moveFlagDown = 0;
    int moveFlagRight = 0;
    int moveFlagLeft = 0;

    int moveUp = 0;
    int moveDown = 0;
    int moveRight = 0;
    int moveLeft = 0;

    float nextXpos = 2; // 次の座標
    float nextZpos = 2;

    int life = 3; //ライフ
    int[] key = new int[] { 0, 0, 0 }; //鍵

    int isGoal = 0;

    GameObject PlayerObject;
    [SerializeField] private Gun2 Gun2Script;

    int delay = 3; //遅延


    // Use this for initialization
    void Start()
    {
        PlayerObject = GameObject.Find("MobileMaleFree1");
        animator = PlayerObject.GetComponent<Animator>();
        GameObject anotherObject = GameObject.Find("Gun2");
        Gun2Script = anotherObject.GetComponent<Gun2>();
    }

    // Update is called once per frame
    void Update()
    {
        float xpos = transform.position.x;
        float ypos = transform.position.y;
        float zpos = transform.position.z;

        if ((MazeGenerator.a[15 - (int)zpos, (int)xpos - 1] == 3)&&(key[0] == 1) &&(key[1] == 1) && (key[2] == 1)) //Goal
        {
            isGoal = 1;
        }


        if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 1] == 4) //keyA
        {
            if(key[0] == 0)
            {
                key[0] = 1;
            }
        }
        else if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 1] == 5) //keyB
        {
            if (key[1] == 0)
            {
                key[1] = 1;
            }
        }
        else if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 1] == 6) //keyC
        {
            if (key[2] == 0)
            {
                key[2] = 1;
            }
        }
        else if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 1] == 7) //回復
        {
            life = 3;
        }

        if (direction == Direction.North) // 北向きの時
        {
            if (moveFlagUp == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.North], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.North;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagDown == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.South], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.South;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagRight == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.East], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.East;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagLeft == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.West], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.West;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) - 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos + 1;
                        moveFlagUp = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) + 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos - 1;
                        moveFlagDown = 1;
                    }

                }

                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos] != 1)
                    {
                        nextXpos = nextXpos + 1;
                        moveFlagRight = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 2] != 1)
                    {
                        nextXpos = nextXpos - 1;
                        moveFlagLeft = 1;
                    }
                }
            }
        }

        else if (direction == Direction.South) // 南向きの時
        {
            if (moveFlagUp == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.North], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.North;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagDown == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.South], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.South;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagRight == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.East], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.East;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagLeft == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.West], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.West;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) + 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos - 1;
                        moveFlagDown = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) - 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos + 1;
                        moveFlagUp = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 2] != 1)
                    {
                        nextXpos = nextXpos - 1;
                        moveFlagLeft = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos] != 1)
                    {
                        nextXpos = nextXpos + 1;
                        moveFlagRight = 1;
                    }
                }
            }
        }

        else if (direction == Direction.East) // 東向きの時
        {
            if (moveFlagUp == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.North], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.North;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagDown == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.South], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.South;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagRight == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.East], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.East;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagLeft == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.West], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.West;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos] != 1)
                    {
                        nextXpos = nextXpos + 1;
                        moveFlagRight = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 2] != 1)
                    {
                        nextXpos = nextXpos - 1;
                        moveFlagLeft = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) + 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos - 1;
                        moveFlagDown = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) - 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos + 1;
                        moveFlagUp = 1;
                    }
                }
            }
        }

        else if (direction == Direction.West) // 西向きの時
        {
            if (moveFlagUp == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.North], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.North;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagDown == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.South], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.South;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagRight == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.East], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.East;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else if (moveFlagLeft == 1)
            {
                animator.SetBool("is_running", true);
                PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[Direction.West], 0f);
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
                    animator.SetBool("is_running", false);

                    if (!Input.GetKey(KeyCode.RightShift))
                    {
                        direction = Direction.West;
                    }
                    PlayerObject.transform.rotation = Quaternion.Euler(0f, PlayerDirection[direction], 0f);
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos - 2] != 1)
                    {
                        nextXpos = nextXpos - 1;
                        moveFlagLeft = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (MazeGenerator.a[15 - (int)zpos, (int)xpos] != 1)
                    {
                        nextXpos = nextXpos + 1;
                        moveFlagRight = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (MazeGenerator.a[(15 - (int)zpos) - 1, (int)xpos - 1] != 1)
                    {
                        nextZpos = nextZpos + 1;
                        moveFlagUp = 1;
                    }
                }

                else if (Input.GetKey(KeyCode.LeftArrow))
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
        if (Gun2Script.IsFire2())
        {
            if((((int)Gun2Script.GetGun2Xpos() == nextXpos) && ((int)Gun2Script.GetGun2Zpos() == nextZpos + 1))||
               (((int)Gun2Script.GetGun2Xpos() == nextXpos) && ((int)Gun2Script.GetGun2Zpos() == nextZpos - 1))||
               (((int)Gun2Script.GetGun2Xpos() == nextXpos + 1) && ((int)Gun2Script.GetGun2Zpos() == nextZpos))||
               (((int)Gun2Script.GetGun2Xpos() == nextXpos - 1) && ((int)Gun2Script.GetGun2Zpos() == nextZpos)))
            {
                if(delay > 0)
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
                        Vector3 pos = new Vector3(2f, ypos, 2f);
                        transform.position = pos;
                        nextXpos = 2;
                        nextZpos = 2;

                    }
                    delay = 3;
                }
            }
        }
    }

    public Direction GetDirection1()
    {
        return direction;
    }

    public float Getxpos()
    {
        return nextXpos;
    }

    public float Getzpos()
    {
        return nextZpos;
    }

    public int GetLife1()
    {
        return life;
    }

    public string IsGoal1()
    {
        if(isGoal == 0)
        {
            return "";
        }
        else
        {
            return "Goal!!!!!!";
        }
    }

    public int[] GetKey1()
    {
        return key;
    }
}
