using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageControl : MonoBehaviour
{
    public GetPower gp;
    public GameObject gage;
    RectTransform rectTran;
    public PracticeMode pm;

    // Start is called before the first frame update
    void Start()
    {
        rectTran = gage.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
        Debug.Log("SET");
    }

    // Update is called once per frame
    void Update()
    {
        if (gp.power < 50)
        {
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (float)gp.power*5f);
        }
        if (pm.state == Progress.StateLevel.Ready)
        {
                Debug.Log("gp power " + gp.power);
        }
        
    }
}
