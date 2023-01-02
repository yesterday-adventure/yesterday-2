using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleHand : ItemSkil
{
    PlayerData playerData;

    [SerializeField] private GameObject player = null;

    private Vector2 playerPos;

    public bool isSkil;

    private void Update() {
        if (isSkil) {
            player.transform.position = playerPos;
        }
    }

    public override void Skil()
    {
        playerPos = player.transform.position; //사용 시 플레이어 위치 받아오는,,
    }

    IEnumerator ddd() { //3초 동안 굴러가는,,
        isSkil = true;
        yield return new WaitForSeconds(3);
        isSkil=  false;
    }
}
