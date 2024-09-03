using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ca : MonoBehaviour
{
   
    // Update is called once per frame
    public float moveSpeed = 10f;            // 初始移动速度
    public float sprintMultiplier = 2f;      // 加速移动的倍数
    public float acceleration = 10f;          // 加速度
    public float maxSpeed = 50f;             // 最大速度

    private float currentSpeed;              // 当前移动速度

    void Start()
    {
        currentSpeed = moveSpeed;            // 初始化当前速度为初始移动速度
    }

    void Update()
    {
        // 获取按键输入
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 如果有输入方向键，则增加当前速度
        if (moveX != 0 || moveZ != 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, moveSpeed, maxSpeed); // 限制最大速度
        }
        else
        {
            // 如果没有输入，重置当前速度为初始速度
            currentSpeed = moveSpeed;
        }

        // 检测 Shift 键是否按下，用于加速移动
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        // 计算移动向量
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        move.Normalize(); // 归一化向量，保持移动方向不受速度影响

        // 应用移动
        transform.position += move * currentSpeed * Time.deltaTime;

        // 使用Q和E控制摄像机的上升和下降
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
