using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float stepLength = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AfterCompletedStep()
    {
        Debug.Log("After Completed Step");
        transform.position += stepLength * Vector3.right;
    }
}