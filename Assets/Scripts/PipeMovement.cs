using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2.0f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
