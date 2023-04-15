using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update

    private FSMsystem fsmsystem; //在Enemy类中，实例化FSMSystem对象，添加巡逻和追逐状态，还有之间的转换条件
    private Collider2D monColl;
    private Animator anima;
    private Rigidbody2D monRig;

    protected virtual void Start()
    {
        InitFsm();//创建状态机
        monColl = GetComponent<Collider2D>();
        monRig = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimaUpdate();
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        fsmsystem.UpdateState(this.gameObject);//检查更新状态
        FilpDirction();
    }

    void AnimaUpdate()
    {
        anima.SetFloat("velocityX", Mathf.Abs(monRig.velocity.x));
    }

    /// 创建状态机
    /// 怪物有两种状态分别是巡逻和追逐玩家
    /// 如果怪物初始状态（设置为Parol状态）一旦SeePlayer 切换状态被激活后，就切换到Chase状态
    /// 如果他在Chase状态一旦LosePlayer状态被激活了，它就转变到Parol状态
    void InitFsm()
    {
        fsmsystem = new FSMsystem();
        FSMstate PatrolState = new PatrolState(fsmsystem);
        PatrolState.AddTransition(Transition.SeePlayer, StateID.Chase);
        FSMstate ChaseState = new ChaseState(fsmsystem);
        ChaseState.AddTransition(Transition.LosePlayer, StateID.Parol);
        fsmsystem.AddState(PatrolState);//初始状态
        fsmsystem.AddState(ChaseState);
    }

    void FilpDirction()
    {
        if (monRig.velocity.x < 0)
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y));
        else if (monRig.velocity.x > 0)
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y));
    }

}