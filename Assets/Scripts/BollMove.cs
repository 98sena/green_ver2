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

    int cnt = 0;
    float friction = 0.7f;
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
            float deltaDis = Time.deltaTime * gp.power;
            transform.position += new Vector3(0, tan*deltaDis, deltaDis);

            gp.power = gp.power - Time.deltaTime * friction * gp.power;
            transform.Rotate(Vector3.right * gp.power);
            
        }
    }
}
