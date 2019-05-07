using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floow : MonoBehaviour
{
    public GameObject Ball_model;
    public GameObject Tex_model;
    public List<MyClass> myClasses = new List<MyClass>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject NewBall = Instantiate(Ball_model);
            GameObject NewTex = Instantiate(Tex_model);
            NewTex.transform.parent = Tex_model.transform.parent;
            myClasses.Add(new MyClass(NewBall, NewTex));
        }
    }
    public class MyClass
    {
        GameObject ball;
        GameObject Tex;

        public MyClass(GameObject ball, GameObject tex)
        {
            this.ball = ball;
            Tex = tex;
        }
        public void Follow()
        {
            Tex.transform.position = Camera.main.WorldToScreenPoint(ball.transform.position);
            Tex.transform.localPosition = Tex.transform.localPosition.normalized* Mathf.Min(300, Tex.transform.localPosition.magnitude-50);
            Tex.transform.right = -Tex.transform.localPosition.normalized;
        }
    }
    // Update is called once per frame
    void Update()
    {
        myClasses.ForEach(x=>x.Follow());
    }
}
