using UnityEngine;

public class Sky : MonoBehaviour
{
    private Transform _tr;

    [Range(0, 10)] public float rotationSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _tr = GetComponent<Transform>();
        if (_tr is null)
            Debug.LogError("Transform of sky is null");
    }

    // Update is called once per frame
    void Update()
    {
        _tr.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}