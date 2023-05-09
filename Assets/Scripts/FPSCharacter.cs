using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacter : MonoBehaviour
{
    public float speed = 10;
    void Move()
    {
        float x = Input.GetAxis("Horizontal"); // 输入左右
        float z = Input.GetAxis("Vertical"); // 输入前后
        // 方向永远平行地面，角色不能走到天上去
        // 获得角色前方向量，将y轴分量设为0
        Vector3 fwd = transform.forward;
        Vector3 f = new Vector3(fwd.x, 0, fwd.z).normalized;
        // 角色的右方向量与右方向的移动直接对应，与抬头无关，可以直接用
        Vector3 r = transform.right;
        // 用f和r作向量的基，组合成移动向量
        Vector3 move = f * z + r * x;
        // 直接改变玩家位置
        transform.position += move * speed * Time.deltaTime;
    }
    void MouseLook()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = -Input.GetAxis("Mouse Y");
        Quaternion qx = Quaternion.Euler(0, mx, 0);
        Quaternion qy = Quaternion.Euler(my, 0, 0);
        transform.rotation = qx * transform.rotation;
        transform.rotation = transform.rotation * qy;
        // angle 是俯仰角度
        float angle = transform.eulerAngles.x;
        // 使用欧拉角时，经常出现-1和359混乱等情况，下面对这些情况加以处理
        if (angle > 180) { angle -= 360; }
        if (angle < -180) { angle += 360; }
        // 限制抬头、低头角度
        if(angle>80)
        {
            Debug.Log("A" + transform.eulerAngles.x);
            transform.eulerAngles=new Vector3(80,transform.eulerAngles.y,0);
        }
        if(angle<-80)
        {
            Debug.Log("B" + transform.eulerAngles.x);
            transform.eulerAngles = new Vector3(-80, transform.eulerAngles.y, 0);
        }
    }
    // Start is called before the first frame update
    void Start() 
    {
        // 隐藏鼠标指针
        Cursor.visible = false;
        // 锁定鼠标指针到屏幕中央
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MouseLook();
    }
}
