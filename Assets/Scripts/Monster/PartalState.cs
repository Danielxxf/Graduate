using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物巡逻状态类
/// </summary>
public class PatrolState : FSMstate
{
    private Transform playerTrasform;
    private Rigidbody2D monsterRig;
    private float partalDis = 10f;
    private Vector2 beginPosi;
    private float speed = 75f;
    /// <summary>
    /// 初始化巡逻状态数据
    /// </summary>
    /// <param name="fsm"></param>
    public PatrolState(FSMsystem fsm) : base(fsm)
    {
        stateID = StateID.Parol;
        playerTrasform = GameObject.Find("Player").transform;
    }

    /// <summary>
    /// 当前状态（巡逻状态）执行的逻辑
    /// </summary>
    /// <param name="targetObj"></param>
    public override void CurrStateAction(GameObject targetObj)
    {
        if (monsterRig == null) monsterRig = targetObj.GetComponent<Rigidbody2D>();
        if (beginPosi.x == 0) beginPosi = targetObj.transform.position;
        if (monsterRig.velocity.x==0)monsterRig.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
        if (targetObj.transform.position.x > beginPosi.x + partalDis) 
            monsterRig.velocity = new Vector2(-speed * Time.fixedDeltaTime, monsterRig.velocity.y);
        if (targetObj.transform.position.x < beginPosi.x - partalDis) 
            monsterRig.velocity = new Vector2(speed * Time.fixedDeltaTime, monsterRig.velocity.y);
    }

    /// <summary>
    /// 切换到追逐状态（下一状态）执行的的逻辑
    /// </summary>
    /// <param name="targrtObj"></param>
    public override void NextStateAction(GameObject targrtObj)
    {
        if (Vector2.Distance(playerTrasform.position, targrtObj.transform.position) <= 6)
        {
            fsmSystem.PerformTranstion(Transition.SeePlayer);
        }
    }
}