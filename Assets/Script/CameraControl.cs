using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Control
{
    public class CameraControl : MonoBehaviour
    {
        public float X_Scale;
        public float Y_Scale;
        public Vector3 OriginEura;
        public Vector3 Offset;
        // Start is called before the first frame update
        void Start()
        {
            OriginEura = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = OriginEura + Offset;
            X_Scale = Input.mousePosition.x / Screen.width;
            Y_Scale = Input.mousePosition.y / Screen.height;
            //if (X_Scale < 0.1)
            //{
            //    Offset = Vector3.Lerp(Offset, Vector3.right * 2, Time.deltaTime);
            //}
            //else 
            if (X_Scale > 0.9 && Y_Scale > 0.2)
            {
                Offset = Vector3.Lerp(Offset, Vector3.right * -2, Time.deltaTime);

            }
            else
            {
                Offset = Vector3.Lerp(Offset, Vector3.zero, Time.deltaTime * 4);

            }

        }
    }
}