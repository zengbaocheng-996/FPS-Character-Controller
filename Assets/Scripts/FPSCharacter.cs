using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacter : MonoBehaviour
{
    public float speed = 10;
    void Move()
    {
        float x = Input.GetAxis("Horizontal"); // ��������
        float z = Input.GetAxis("Vertical"); // ����ǰ��
        // ������Զƽ�е��棬��ɫ�����ߵ�����ȥ
        // ��ý�ɫǰ����������y�������Ϊ0
        Vector3 fwd = transform.forward;
        Vector3 f = new Vector3(fwd.x, 0, fwd.z).normalized;
        // ��ɫ���ҷ��������ҷ�����ƶ�ֱ�Ӷ�Ӧ����̧ͷ�޹أ�����ֱ����
        Vector3 r = transform.right;
        // ��f��r�������Ļ�����ϳ��ƶ�����
        Vector3 move = f * z + r * x;
        // ֱ�Ӹı����λ��
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
        // angle �Ǹ����Ƕ�
        float angle = transform.eulerAngles.x;
        // ʹ��ŷ����ʱ����������-1��359���ҵ�������������Щ������Դ���
        if (angle > 180) { angle -= 360; }
        if (angle < -180) { angle += 360; }
        // ����̧ͷ����ͷ�Ƕ�
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
        // �������ָ��
        Cursor.visible = false;
        // �������ָ�뵽��Ļ����
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MouseLook();
    }
}
