using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Control
{
    public class CameraControl : MonoBehaviour
    {
        public Vector3 DefaultView;
        float OffsetX = 0;
        float OffsetY = 0;

        //public float X_Scale;
        //public float Y_Scale;
        //public Vector3 OriginEura;
        //public Vector3 Offset;
        // Start is called before the first frame update
        void Start()
        {
            DefaultView = transform.eulerAngles;
            //OriginEura = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                //transform.position =
                OffsetX += Input.GetAxis("Mouse X");
                OffsetY -= Input.GetAxis("Mouse Y");
                Vector3 OffsetVector = new Vector3(OffsetY, OffsetX, 0);
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, DefaultView+ OffsetVector, Time.deltaTime*2);
            }
            else
            {
                OffsetX = 0;
                OffsetY = 0;
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, DefaultView, Time.deltaTime*2);

            }
            //transform.position = OriginEura + Offset;
            //X_Scale = Input.mousePosition.x / Screen.width;
            //Y_Scale = Input.mousePosition.y / Screen.height;
            ////if (X_Scale < 0.1)
            ////{
            ////    Offset = Vector3.Lerp(Offset, Vector3.right * 2, Time.deltaTime);
            ////}
            ////else 
            //if (X_Scale > 0.9 && Y_Scale > 0.2)
            //{
            //    Offset = Vector3.Lerp(Offset, Vector3.right * -2, Time.deltaTime);

            //}
            //else
            //{
            //    Offset = Vector3.Lerp(Offset, Vector3.zero, Time.deltaTime * 4);

            //}

        }
    }
}