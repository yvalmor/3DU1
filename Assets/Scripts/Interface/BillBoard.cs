using System;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    public Transform cam;
    public GameObject healthBar;

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").transform;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, cam.position) > 50)
        {
            if (healthBar.activeSelf)
                healthBar.SetActive(false);
        }
        else if (!healthBar.activeSelf)
            healthBar.SetActive(true);
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
