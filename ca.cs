using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ca : MonoBehaviour
{
   
    // Update is called once per frame
    public float moveSpeed = 10f;            // ��ʼ�ƶ��ٶ�
    public float sprintMultiplier = 2f;      // �����ƶ��ı���
    public float acceleration = 10f;          // ���ٶ�
    public float maxSpeed = 50f;             // ����ٶ�

    private float currentSpeed;              // ��ǰ�ƶ��ٶ�

    void Start()
    {
        currentSpeed = moveSpeed;            // ��ʼ����ǰ�ٶ�Ϊ��ʼ�ƶ��ٶ�
    }

    void Update()
    {
        // ��ȡ��������
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // ��������뷽����������ӵ�ǰ�ٶ�
        if (moveX != 0 || moveZ != 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, moveSpeed, maxSpeed); // ��������ٶ�
        }
        else
        {
            // ���û�����룬���õ�ǰ�ٶ�Ϊ��ʼ�ٶ�
            currentSpeed = moveSpeed;
        }

        // ��� Shift ���Ƿ��£����ڼ����ƶ�
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        // �����ƶ�����
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        move.Normalize(); // ��һ�������������ƶ��������ٶ�Ӱ��

        // Ӧ���ƶ�
        transform.position += move * currentSpeed * Time.deltaTime;

        // ʹ��Q��E������������������½�
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.down * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.up * currentSpeed * Time.deltaTime;
        }
    }
}
