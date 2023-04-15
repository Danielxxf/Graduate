using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 玩家信息数据结构
public class PlayerInfo : MonoBehaviour
{
    private Animator anima;

    // 固定数值
    // 将最大等级和最大血量定义为常量并初始化
    private const int maxLevel = 5;
    private const int maxHP = 12;
    // 每级需要的经验值
    private int[] levelUpExp = new int[maxLevel + 1] { 0, 0, 2, 5, 10, 20 };

    // 分别为玩家血量，玩家等级
    private int healthPoint = 12;
    private int level = 1;
    private int exp = 0;

    // UI组件
    public Text hpText;
    public Text levelText;
    public Slider hpGraphy;
    public Slider ExpGraphy;

    private void Start()
    {
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        HPLimit();
        PlayerLevelUp();
        UpdateUI();
    }

    //血量限制
    void HPLimit()
    {
        if (healthPoint > maxHP) healthPoint = maxHP;
        else if (healthPoint < 0) {
            healthPoint = 0;
        }
    }

    //玩家升级
    void PlayerLevelUp()
    {
        //如果玩家等级小于最大等级并且经验值大于或等于下一级所需要的经验值，等级+1
        if (level < maxLevel)
        {
            if (exp >= levelUpExp[level + 1])
            {
                ++level;
            }
        }
    }

    //4个公有函数接口，分别为GetHP()获取血量、GetExp()获取经验值、IncOrDecHP(int hpVar)恢复血量或者减少血量、IncExp(int increment)增加经验值
    public int GetHP()
    {
        return healthPoint;
    }

    public int GetExp()
    {
        return exp;
    }

    public int GetLevel()
    {
        return level;
    }

    public void IncOrDecHP(int hpVar)
    {
        healthPoint += hpVar;
    }

    public void IncExp(int increment)
    {
        exp += increment;
    }

    void UpdateUI()
    {
        // 血量数字更新为实时血量
        hpText.text = healthPoint.ToString();
        hpGraphy.value = healthPoint;
        levelText.text = "lv."+level.ToString();
        if (level < maxLevel)
        {
            ExpGraphy.maxValue = levelUpExp[level + 1]-levelUpExp[level];
            ExpGraphy.value = exp - levelUpExp[level];
        }
        if(healthPoint == 0)
        {
            anima.Play("Death");
        }
    }
}
