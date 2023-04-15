using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //玩家对象
    GameObject player;
    //玩家位置
    Transform playerTran;
    //镜头与玩家的相对位置
    Vector2 CameraPlayerDistance = new Vector3(0, 6, -10);
  
    // Start is called before the first frame update
    void Start()
    {
        //获取Tag为“Player”的玩家对象
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerTran = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 更新镜头位置
        PositionUpdate();
    }

    // 让镜头位置与玩家位置保持同步
    void PositionUpdate()
    {
        Vector2 playerPosi = player.transform.position;
        transform.position = new Vector3(playerPosi.x + CameraPlayerDistance.x, playerPosi.y + CameraPlayerDistance.y, transform.position.z);
    }
}
