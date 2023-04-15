using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : PlayerState
{
    // PlayerMovement固定数值
    const float moveSpeed = 400f;
    const float jumpForce = 400f;

    // 二维向量，玩家x和y方向上的速度
    Vector2 velocity;

    //涉及物理物理运动更新，放入FixedUpdate()中执行
    private void FixedUpdate()
    {
        Movement();
    }

    // 实现人物水平移动和跳跃
    void Movement()
    {
        // 水平方向移动速度和垂直方向跳跃速度
        velocity.x = inputValueH * moveSpeed * Time.fixedDeltaTime;
        velocity.y = jumpForce * Time.fixedDeltaTime;

        // 赋予刚体水平方向速度;
        rig.velocity = new Vector2(velocity.x, rig.velocity.y);

        // 如果同时满足触碰地面和按下跳跃键的条件,水平方向速度不变，赋予人物一个垂直向上的速度
        if (isTouchGround && Input.GetButton("Jump"))
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce * Time.fixedDeltaTime);
        }
    }
}
