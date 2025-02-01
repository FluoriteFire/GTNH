using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOperationCamera : MonoBehaviour
{
 
    public static MouseOperationCamera Instance = null;
    
    private Vector3 dirVector3;
    private Vector3 rotaVector3;
    private float paramater = 1f;
    private float slideSpeed = 20;
    void Awake ()
	{
	    Instance = this;
	}
 
    private void Start()
    {
        rotaVector3 = transform.localEulerAngles;
    }
 
    // Update is called once per frame
	void FixedUpdate ()
    {
        // 镜头缩放，靠视野缩放
         if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 10 * slideSpeed*Time.deltaTime;
            // if (Camera.main.orthographicSize <= 20)
            //     Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 10 * slideSpeed*Time.deltaTime;
            // if (Camera.main.orthographicSize >= 1)
            //     Camera.main.orthographicSize -= 0.5F;
        }
        
        //旋转
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -5, 0 * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 5, 0 * Time.deltaTime, Space.World);
        }
 
        //移动
        dirVector3 = Vector3.zero;
 
        if (Input.GetKey(KeyCode.W))
        {
            dirVector3.y = 1;dirVector3.z = 0.5f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dirVector3.y = -1;dirVector3.z = -0.5f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dirVector3.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dirVector3.x = 1;
        }
        transform.Translate(dirVector3 * paramater, Space.Self);
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0,1,0) * paramater, Space.World); 
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(0,-1,0) * paramater, Space.World); 
        }
		transform.position = transform.position;
    }
}