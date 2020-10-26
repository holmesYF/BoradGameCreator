using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float angle_speed;
    private float speed;
    private float mouse;
    Vector3 pos;
    Vector3 ang;
    bool angle_flag;
    private void Awake()
    {
        angle_speed = 1.2f;
        speed = 0.1f;
        ang = transform.eulerAngles;
        angle_flag = false;
        Cursor.visible = true;
    }
    private void Update()
    {
        pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(pos.x - speed, pos.y, pos.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(pos.x + speed, pos.y, pos.z);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(pos.x, pos.y, pos.z - speed);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(pos.x, pos.y, pos.z + speed);
        }
        if (Input.GetMouseButtonDown(2))
        {
            if (angle_flag)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            Cursor.visible = !Cursor.visible;
            angle_flag = !angle_flag;
        }
        if (angle_flag)
        {
            ang = transform.eulerAngles;
            mouse = Input.GetAxis("Mouse X");
           // transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * angle_speed,0.0f));
            transform.Rotate(new Vector3(0.0f,mouse * angle_speed * Mathf.Cos(ang.x / 90 * Mathf.PI/2),0.0f));
            transform.Rotate(new Vector3(0.0f,0.0f, -mouse * angle_speed * Mathf.Sin(ang.x / 90 * Mathf.PI / 2)));
        }
    }
}
