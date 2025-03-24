using UnityEngine;

public class ScreenBound : MonoBehaviour
{
    private const float leftEdgeBuffer = 1.0f;

    public static float leftEdge = -2;

    private void Start()
    {
        CalculatLeftEdge();
    }
    private static void CalculatLeftEdge()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - leftEdgeBuffer;
    }
}
