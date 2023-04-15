using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //地面层
    LayerMask groundMask;

 // GameObjectComponents
    protected Rigidbody2D rig;
    protected Collider2D coll;
    protected Animator anima;
    protected PlayerInfo playerInfo;

    // 玩家状态
    protected float inputValueH;
    protected bool isJump;
    protected bool isAttack;

    [SerializeField]
    // 是否触碰地面
    protected bool isTouchGround;   

    void Start()
    {
        playerInfo = GetComponent<PlayerInfo>();
        rig = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        // 获取Ground层的位掩码
        groundMask = 1 << LayerMask.NameToLayer("Ground");
    }

    void Update()
    {
        StateUpdate();
        AnimaParameterUpdate();
        FilpDirction();
    }

    // 更新人物状态
    void StateUpdate()
    {
        inputValueH = Input.GetAxis("Horizontal");
        isJump = Input.GetButton("Jump");
        // 通过coll对象的isTouchingLayers()方法判断是否触碰地面
        isTouchGround = coll.IsTouchingLayers(groundMask);
    }

    // 根据人物水平速度方向翻转人物方向
    void FilpDirction()
    {
        if (inputValueH > 0)
            transform.localScale = new Vector2(1, 1);
        else if (inputValueH < 0)
            transform.localScale = new Vector2(-1, 1);
    }

    //根据人物状态变量的值更新动画参数（Animator Parameters）
    void AnimaParameterUpdate()
    {
        anima.SetBool("isTouchGround", isTouchGround);
        anima.SetFloat("inputValueH", Mathf.Abs(inputValueH));
    }

    void Death()
    {
        GameProcessController.GameOver();
    }
}
