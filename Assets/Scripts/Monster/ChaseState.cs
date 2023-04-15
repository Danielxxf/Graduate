using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 追逐状态类
/// </summary>
public class ChaseState : FSMstate
{
    private Transform PlayerTransForm;//玩家位置信息
    private Rigidbody2D monsterRig;
    private float distance;
    private float speed = 150f;

    public ChaseState(FSMsystem fsm) : base(fsm)
    {
        stateID = StateID.Chase;
        PlayerTransForm = GameObject.Find("Player").transform;
    }
    /// <summary>
    /// 追逐状态下执行的逻辑
    /// </summary>
    /// <param name="targrtObj"></param>
    public override void CurrStateAction(GameObject targrtObj)
    {
        if (monsterRig == null) monsterRig = targrtObj.GetComponent<Rigidbody2D>();
        distance = PlayerTransForm.position.x - targrtObj.transform.position.x;
        monsterRig.velocity = new Vector2((distance/Mathf.Abs(distance))*speed*Time.fixedDeltaTime, monsterRig.velocity.y);
    }
    /// <summary>
    /// 切换到下一状态（巡逻）前要执行的逻辑
    /// </summary>
    /// <param name="targrtObj"></param>
    public override void NextStateAction(GameObject targrtObj)
    {
        if (Vector2.Distance(PlayerTransForm.position, targrtObj.transform.position) > 10)
        {
            fsmSystem.PerformTranstion(Transition.LosePlayer);
        }
    }
}