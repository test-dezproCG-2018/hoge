using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField] private MainMove MainMoveScript;
    public GameObject Bullet; // prefub
    public GameObject createdBullet; // 生成された弾丸

    float createdBulletXpos = 2;
    float createdBulletZpos = 2;

    int bulletCreate = 0;

    // Use this for initialization
    void Start () {
        GameObject anotherObject = GameObject.Find("MoveSphere");
        MainMoveScript = anotherObject.GetComponent<MainMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMoveScript.GetDirection1() == MainMove.Direction.North) // 北向きの時
        {
            if (bulletCreate == 0)
            {
                if (Input.GetKey(KeyCode.L))
                {
                    bulletCreate = 1;
                    Vector3 pos = new Vector3(MainMoveScript.Getxpos(), 0.25f, MainMoveScript.Getzpos());
                    createdBullet = Instantiate(Bullet, pos, Quaternion.identity);
                    createdBulletXpos = createdBullet.transform.position.x;
                    createdBulletZpos = createdBullet.transform.position.z;
                }
            }

            else if (bulletCreate == 1)
            {
                createdBulletXpos = createdBullet.transform.position.x;
                createdBulletZpos = createdBullet.transform.position.z;

                if (MazeGenerator.a[(15 - (int)createdBulletZpos) - 1, (int)createdBulletXpos - 1] != 1)
                {
                    Vector3 mv = new Vector3(0f, 0f, +0.25f);
                    createdBullet.transform.Translate(mv);
                }

                else
                {
                    Destroy(createdBullet);
                    bulletCreate = 0;
                }

            }
        }

        else if (MainMoveScript.GetDirection1() == MainMove.Direction.South) // 南向きの時
        {
            if (bulletCreate == 0)
            {
                if (Input.GetKey(KeyCode.L))
                {
                    bulletCreate = 1;
                    Vector3 pos = new Vector3(MainMoveScript.Getxpos(), 0.25f, MainMoveScript.Getzpos());
                    createdBullet = Instantiate(Bullet, pos, Quaternion.identity);
                    createdBulletXpos = createdBullet.transform.position.x;
                    createdBulletZpos = createdBullet.transform.position.z;
                }
            }

            else if (bulletCreate == 1)
            {
                createdBulletXpos = createdBullet.transform.position.x;
                createdBulletZpos = createdBullet.transform.position.z;

                if (MazeGenerator.a[(15 - (int)createdBulletZpos) + 1, (int)createdBulletXpos - 1] != 1)
                {
                    Vector3 mv = new Vector3(0f, 0f, -0.25f);
                    createdBullet.transform.Translate(mv);
                }

                else
                {
                    Destroy(createdBullet);
                    bulletCreate = 0;
                }

            }
        }

        if (MainMoveScript.GetDirection1() == MainMove.Direction.East) // 東向きの時
        {
            if (bulletCreate == 0)
            {
                if (Input.GetKey(KeyCode.L))
                {
                    bulletCreate = 1;
                    Vector3 pos = new Vector3(MainMoveScript.Getxpos(), 0.25f, MainMoveScript.Getzpos());
                    createdBullet = Instantiate(Bullet, pos, Quaternion.identity);
                    createdBulletXpos = createdBullet.transform.position.x;
                    createdBulletZpos = createdBullet.transform.position.z;
                }
            }

            else if (bulletCreate == 1)
            {
                createdBulletXpos = createdBullet.transform.position.x;
                createdBulletZpos = createdBullet.transform.position.z;

                if (MazeGenerator.a[(15 - (int)createdBulletZpos), (int)createdBulletXpos] != 1)
                {
                    Vector3 mv = new Vector3(0.25f, 0f, 0f);
                    createdBullet.transform.Translate(mv);
                }

                else
                {
                    Destroy(createdBullet);
                    bulletCreate = 0;
                }

            }
        }

        if (MainMoveScript.GetDirection1() == MainMove.Direction.West) // 西向きの時
        {
            if (bulletCreate == 0)
            {
                if (Input.GetKey(KeyCode.L))
                {
                    bulletCreate = 1;
                    Vector3 pos = new Vector3(MainMoveScript.Getxpos(), 0.25f, MainMoveScript.Getzpos());
                    createdBullet = Instantiate(Bullet, pos, Quaternion.identity);
                    createdBulletXpos = createdBullet.transform.position.x;
                    createdBulletZpos = createdBullet.transform.position.z;
                }
            }

            else if (bulletCreate == 1)
            {
                createdBulletXpos = createdBullet.transform.position.x;
                createdBulletZpos = createdBullet.transform.position.z;

                if (MazeGenerator.a[(15 - (int)createdBulletZpos), (int)createdBulletXpos - 2] != 1)
                {
                    Vector3 mv = new Vector3(-0.25f, 0f, 0f);
                    createdBullet.transform.Translate(mv);
                }

                else
                {
                    Destroy(createdBullet);
                    bulletCreate = 0;
                }

            }
        }
    }

    public bool IsFire()
    {
        if(bulletCreate == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float GetGunXpos()
    {
        return createdBulletXpos;
    }

    public float GetGunZpos()
    {
        return createdBulletZpos;
    }
}
