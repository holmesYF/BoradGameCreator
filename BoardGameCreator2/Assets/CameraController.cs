using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float angle_speed_x;
    private float angle_speed_y;
    private float speed;
    private float mouse;
    public GameObject center_dot;
    Vector3 pos;
    Vector3 ang;
    bool angle_flag;
    private void Awake()
    {
        angle_speed_x = 1.2f;
        angle_speed_y = 1.2f;
        speed = 0.1f;
        ang = transform.eulerAngles;
        center_dot = GameObject.Find("Canvas").transform.Find("Aim").gameObject;
        angle_flag = false;
        Cursor.visible = true;
    }

    private void Start()
    {
        center_dot.SetActive(false);
    }
    private void Update()
    {

        pos = transform.position;
        ang = transform.eulerAngles;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(pos.x - (speed * Mathf.Sin((ang.y + 90) / 180 * Mathf.PI)), pos.y, pos.z - (speed * Mathf.Cos((ang.y + 90) / 180 * Mathf.PI)));
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(pos.x + (speed * Mathf.Sin((ang.y + 90) / 180 * Mathf.PI)), pos.y, pos.z + (speed * Mathf.Cos((ang.y + 90) / 180 * Mathf.PI)));
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(pos.x - (speed * Mathf.Sin(ang.y / 180 * Mathf.PI)), pos.y, pos.z - (speed * Mathf.Cos(ang.y / 180 * Mathf.PI)));
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(pos.x + (speed * Mathf.Sin(ang.y / 180 * Mathf.PI)), pos.y, pos.z + (speed * Mathf.Cos(ang.y / 180 * Mathf.PI)));
        }
        if (Input.GetMouseButtonDown(2))
        {
            if (angle_flag)
            {
                Cursor.lockState = CursorLockMode.None;
                center_dot.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                center_dot.SetActive(true);
            }
            Cursor.visible = !Cursor.visible;
            angle_flag = !angle_flag;
        }
        if (angle_flag)
        {
            ang = transform.eulerAngles;
            //カメラ左右
            transform.Rotate(new Vector3(0.0f, Input.GetAxis("Mouse X") * angle_speed_x, 0.0f));

            //カメラ上下
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * angle_speed_y,0.0f));
            ang = transform.eulerAngles;
            transform.eulerAngles = new Vector3(ang.x,ang.y,0.0f);
            float mouse = Input.GetAxis("Mouse ScrollWheel");
            if (mouse < 0)
            {
                pos = transform.position;
                transform.position = new Vector3(pos.x,pos.y - 1,pos.z);
            }
            else if(mouse > 0)
            {
                pos = transform.position;
                transform.position = new Vector3(pos.x, pos.y + 1, pos.z);
            }
        }

    }
}
