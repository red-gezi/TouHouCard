using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private float time;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 3)
        {
            time = 0;
            GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 1000, ForceMode.Force);
        }
    }
}
