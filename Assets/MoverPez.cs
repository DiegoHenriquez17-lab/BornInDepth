using UnityEngine;

public class MoverPez : MonoBehaviour
{
    public float velocidad = 4f;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0f).normalized;
        transform.position += dir * velocidad * Time.deltaTime;
    }
}

