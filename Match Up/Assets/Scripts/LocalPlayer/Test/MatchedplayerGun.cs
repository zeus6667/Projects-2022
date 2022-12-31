using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchedplayerGun : MonoBehaviour
{
    public PlayerBullet Bullet;
   
    public void shoot()
    {
        GameObject go = Instantiate(Bullet.gameObject, transform.position, Quaternion.identity);
    }
}
