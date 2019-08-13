using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Mathf.Sin(Time.time) * 10;
    }
}
