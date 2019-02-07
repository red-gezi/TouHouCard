using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public SingleRowInfo a;
    public GameObject b;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(4))
        {
            GameObject c = Instantiate(b);
            a.ThisRowCard.Add(c.GetComponent<CardTest>());
        }
        if (Input.GetMouseButtonDown(3))
        {
            Card b = a.ThisRowCard[0];
            a.ThisRowCard.Remove(b);
            Destroy(b.gameObject);
        }
    }
}
