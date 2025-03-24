using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    private const float leftEdgeBuffer = 1.0f;

    void Update()
    {
        if (transform.position.x < ScreenBound.leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
