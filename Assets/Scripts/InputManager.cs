using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManager : MonoBehaviour
{
    public GameObject golfBall;
    public GameObject camera;
    public GameObject green;
    public GameObject targetPlace;

    public Slider LRSlope;
    public Slider BFSlope;

    public GameObject ballPlace;
    public GameObject camPlace;




    float staticDistance = (-29.49f) + (80.0f);
    public float curDistance = 0f;
    public float LR;
    public float BF;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(ballPlace.transform.position);
    }
    public void scrolling(Slider slider)
    {
        if (slider.name == "WideLength")
        {
            Debug.Log(slider.value + "랄라");
            golfBall.transform.position = new Vector3(golfBall.transform.position.x, golfBall.transform.position.y, (-80.0f)+slider.value * staticDistance);
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, (-90.0f) + slider.value * staticDistance);
            curDistance =1-slider.value;
        }

        if(slider.name == "LRSlope")
        {
            Debug.Log("LRSlope" + slider.value);
            //camera.transform.position = new Vector3(camera.transform.position.x, (9.5f) + (slider.value - 0.5f) * 0.1f, camera.transform.position.z);
            camera.transform.position = camPlace.transform.position;

            //golfBall.transform.position = new Vector3(golfBall.transform.position.x, 6.25f - (slider.value - 0.5f)*0.1f, golfBall.transform.position.z);
            golfBall.transform.position = ballPlace.transform.position;

            green.transform.rotation = Quaternion.Euler(new Vector3((BFSlope.value - 0.5f) * 5f, 0f, (slider.value-0.5f)*10f) );

            LR = slider.value;
        }

        if (slider.name == "BFSlope")
        {
            Debug.Log("BFSlope" + slider.value);
            //camera.transform.position = new Vector3(camera.transform.position.x, (9.5f) + (slider.value - 0.5f) * 7f, camera.transform.position.z);
            camera.transform.position = camPlace.transform.position;
            camera.transform.rotation = camPlace.transform.rotation;

            //golfBall.transform.position = new Vector3(golfBall.transform.position.x, 6.25f + (slider.value - 0.5f)*7f, golfBall.transform.position.z);
            golfBall.transform.position = ballPlace.transform.position;

            green.transform.rotation = Quaternion.Euler(new Vector3((slider.value - 0.5f) * 5f, 0f, (LRSlope.value - 0.5f) * 10f));

            BF = slider.value;
        }

        //Debug.Log(slider.name)

    }

    
}
