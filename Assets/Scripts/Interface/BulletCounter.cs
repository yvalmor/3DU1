using TMPro;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI currBulletText;
    public TextMeshProUGUI maxBulletText;

    public void SetMaxBullet(int bullet)
    {
        maxBulletText.text = bullet.ToString();
        currBulletText.text = bullet.ToString();
    }

    public void SetBullet(int bullet)
    {
        currBulletText.text = bullet.ToString();
    }
}
