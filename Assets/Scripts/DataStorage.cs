using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    public InputManager im;
    public float ballDistace;
    public float LR;
    public float BF;

    public PracticeMode pm;
    public int hitCount;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        ballDistace = 1f;
        LR = 0.5f;
        BF = 0.5f;
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ballDistace = im.curDistance;
        LR = im.LR;
        BF = im.BF;
        hitCount = pm.hitCount;
    }
}
