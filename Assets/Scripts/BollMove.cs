using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class BollMove : MonoBehaviour
{
    public GetPower gp;
    Rigidbody rb;
    Vector3 target = new Vector3(-0.615f, 2.705f, 29.275f);
    public GameObject selectButtons;

    public GameObject targetPlace;
    Vector3 tarPos;
    float tX = 0f, ty = 0f, tz = 0f;
    float tan;

    public PracticeMode pm;
    public bool succeed = false;
    Vector3 newPos;
    //public Rigidbody ballRB;
    Vector3 velocity = new Vector3(0f, 0f, 0f);

    int cnt = 0;
    float friction = 0.7f;

    public GameObject stick;
    Vector3 stickRot;
    Vector3 gravity = new Vector3(0, 9.8f, 0);
    // Start is called before the first frame update
    void Start()
    { 
        rb = transform.gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pm.state == Progress.StateLevel.Start && selectButtons.activeSelf)
        {
            tarPos = targetPlace.transform.position;
            //Debug.Log(tarPos + "              WOOWWWWWWWWWWWWWWWWWWW");
            tan =(tarPos.y - transform.position.y) / (tarPos.z - transform.position.z);
            //stickRot = Quaternion.Euler(stick.transform.rotation.x,stick.transform.rotation.y,stick.transform.rotation.z);
            stickRot = stick.transform.rotation.eulerAngles;
        }
        if (pm.state == Progress.StateLevel.Roll)
        {
            if (Mathf.Abs(tarPos.x - transform.position.x) < 1.3f && Mathf.Abs(tarPos.z - transform.position.z) < 1.3f)
            {
                succeed = true;
                Debug.Log("succceees");
                gp.power = 0;
                gp.getInput = 3; //들어갔다
                return;
            }

            if (gp.power <= 1)
            {
                gp.getInput = 3; // 끝났다
                //if (Mathf.Abs(target.x - transform.position.x) < 1.5f && Mathf.Abs(target.z - transform.position.z) < 1.5f)
                //{
                //    succeed = true;
                //    Debug.Log("succceees");
                //}
                return;
            }
            cnt++;
            velocity = new Vector3(velocity.x, velocity.y, gp.power);
            Vector3 gravityA = new Vector3(gravity.x * stickRot.x, gravity.y*(stickRot.y-1),gravity.z*stickRot.z);
            velocity += new Vector3(gravityA.x*Time.deltaTime, gravityA.y*Time.deltaTime, gravityA.z*Time.deltaTime);
            gp.power = velocity.z;

            float deltaDis = Time.deltaTime * gp.power;
            Vector3  gravityDis = new Vector3(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, velocity.z * Time.deltaTime);
            transform.position += new Vector3(0, tan*deltaDis, deltaDis) ; // 골프채에 맞아서 앞으로 나아감
            transform.position += gravityDis; // 중력 가속도

            gp.power = gp.power - Time.deltaTime * friction * gp.power;
            transform.Rotate(Vector3.right * gp.power);
            
        }
    }
}
