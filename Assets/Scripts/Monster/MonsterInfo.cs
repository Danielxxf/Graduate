using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    public int maxHP;
    public int exp;
    public GameObject award;
    public Slider HPbar;
    public bool isPassKey;

    private void Update()
    {
        HPlimit();
        HP_UI_Update();
    }

    void HPlimit()
    {
        if (HP > maxHP) HP = maxHP;
        else if (HP < 0) HP = 0;
    }

    void HP_UI_Update()
    {
        HPbar.value = HP;
    }

    public void Hurt(int damage)
    {
        HP -= damage;
        if(HP < 0)
        {
            Death();
        }
    }

    private void Death()
    {
        GameObject.Find("Player").GetComponent<PlayerInfo>().IncExp(exp);
        Instantiate(award,transform.position,transform.rotation);
        if (isPassKey) GameProcessController.GamePass();
        Destroy(gameObject);
    }
}
