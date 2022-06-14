using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletCounter : MonoBehaviour
{

    public TextMeshProUGUI currBullets;
    public TextMeshProUGUI maxBullets;

    public void SetMaxBullet(int bullet)
    {
        maxBullets.text = bullet.ToString();
        currBullets.text = bullet.ToString();
    }

    public void SetBullet(int bullet)
    {
        currBullets.text = bullet.ToString();
    }
}
