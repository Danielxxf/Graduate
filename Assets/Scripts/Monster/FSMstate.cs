using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态ID
/// </summary>
public enum StateID
{
    NoneStateID,
    Parol,//巡逻状态
    Chase,//追逐状态
    Attack,
}
/// <summary>
/// 状态切换条件
/// </summary>
public enum Transition
{
    NoneTransition,
    SeePlayer,//看到玩家
    LosePlayer,//看不到玩家
}

/// <summary>
/// FSM中状态基类（实现状态的基本方法）
/// </summary>
public abstract class FSMstate
{

    protected StateID stateID;//状态对应的ID
    public StateID ID { get { return stateID; } }
    protected Dictionary<Transition, StateID> Transition_StateIDDic = new Dictionary<Transition, StateID>();//存储转换条件和状态的ID
    protected FSMsystem fsmSystem;//管理状态对象（因为要状态更新需要通过FSMsystem去管理实现的，所以需要一个管理对象）

    public FSMstate(FSMsystem fsm)
    {
        this.fsmSystem = fsm;
    }
    /// <summary>
    ///增加转条件
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="id"></param>
    public void AddTransition(Transition trans, StateID id)
    {
        if (trans == Transition.NoneTransition)
        {
            Debug.Log("添加的转换条件不能为null");
            return;
        }
        if (id == StateID.NoneStateID)
        {
            Debug.Log("添加的状态ID不能为null");
            return;
        }
        if (Transition_StateIDDic.ContainsKey(trans))
        {
            Debug.Log("添加转换条件的时候，" + trans + "已经存在于Transition_StateIDDic中");
            return;
        }
        Transition_StateIDDic.Add(trans, id);
    }
    /// <summary>
    /// 删除转换条件
    /// </summary>
    /// <param name="trans"></param>
    public void DeleteTransition(Transition trans)
    {
        if (trans == Transition.NoneTransition)
        {
            Debug.Log("删除的转换条件不能为null");
            return;
        }
        if (!Transition_StateIDDic.ContainsKey(trans))
        {
            Debug.Log("删除转换条件的时候，" + trans + "不存在于Transition_StateIDDic中");
            return;
        }
        Transition_StateIDDic.Remove(trans);
    }
    /// <summary>
    /// 根据转换条件获得状态ID
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public StateID GetStateID(Transition trans)
    {
        if (Transition_StateIDDic.ContainsKey(trans))
        {
            return Transition_StateIDDic[trans];
        }
        return StateID.NoneStateID;
    }

    /// <summary>
    ///转换到此状态前要执行的逻辑
    /// </summary>
    public virtual void DoBeforeEnterAcion() { }
    /// <summary>
    /// 离开此状态前要执行的逻辑
    /// </summary>
    public virtual void DoAfterLevAction() { }
    /// <summary>
    /// 处在本状态时要执行的逻辑
    /// </summary>
    /// <param name="TargetObj"></param>
    public abstract void CurrStateAction(GameObject TargetObj);
    /// <summary>
    /// 切换到下一状态需要执行的逻辑
    /// </summary>
    /// <param name="TargetObj"></param>
    public abstract void NextStateAction(GameObject TargetObj);


}