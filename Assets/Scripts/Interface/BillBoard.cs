using UnityEngine;

public class BillBoard : MonoBehaviour
{

    public Transform cam;

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
