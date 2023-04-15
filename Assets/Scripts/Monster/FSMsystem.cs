using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态处理类（添加，删除，切换，更新等管理所有状态）
/// </summary>
public class FSMsystem
{

    private Dictionary<StateID, FSMstate> StateDic = new Dictionary<StateID, FSMstate>();//保存状态ID以及ID对应的状态
    private StateID _CurrentStateID;//当前处于的状态ID
    private FSMstate _CurrentState;//当前处于的状态

    /// <summary>
    /// 添加状态
    /// </summary>
    /// <param name="state">需管理的状态</param>
    public void AddState(FSMstate state)
    {
        if (state == null)
        {
            Debug.Log("添加的状态" + state + "不能为null");
            return;
        }
        if (_CurrentState == null)
        {
            _CurrentState = state;
            _CurrentStateID = state.ID;
        }
        if (StateDic.ContainsKey(state.ID))
        {
            Debug.Log("状态机 " + state.ID + "已经存在，无法添加");
            return;
        }
        StateDic.Add(state.ID, state);
    }
    /// <summary>
    /// 删除状态
    /// </summary>
    /// <param name="stateID">删除要管理状态的ID</param>
    public void DeleteState(StateID stateID)
    {
        if (stateID == StateID.NoneStateID)
        {
            Debug.Log("无法删除Null的状态");
            return;
        }
        if (!StateDic.ContainsKey(stateID))
        {
            Debug.Log("无法删除不存在的状态：" + stateID);
            return;
        }
        StateDic.Remove(stateID);
    }
    /// <summary>
    /// 状态转换（状态的切换是根据转换条件的变化）
    /// </summary>
    /// <param name="trans">转换条件</param>
    public void PerformTranstion(Transition trans)
    {
        if (trans == Transition.NoneTransition)
        {
            Debug.Log("无法执行NULL的转换条件");
            return;
        }
        StateID stateId = _CurrentState.GetStateID(trans);
        if (stateId == StateID.NoneStateID)
        {
            Debug.Log("要转换的状态ID为null");
            return;
        }
        if (!StateDic.ContainsKey(stateId))
        {
            Debug.Log("状态机中没找到状态ID  " + stateId + "  无法转换状态");
            return;
        }
        FSMstate state = StateDic[stateId];//根据状态ID获取要转换的状态
        _CurrentState.DoAfterLevAction();//执行离开上一状态逻辑
        _CurrentState = state;//更新当前状态
        _CurrentStateID = stateId;//更新当前状态ID
        _CurrentState.DoBeforeEnterAcion();//执行进入当前状态前要执行的逻辑
    }

    /// <summary>
    /// 更新当前状态行为
    /// </summary>
    /// <param name="TargetObj"></param>
    public void UpdateState(GameObject TargetObj)
    {
        _CurrentState.CurrStateAction(TargetObj);
        _CurrentState.NextStateAction(TargetObj);
    }

}