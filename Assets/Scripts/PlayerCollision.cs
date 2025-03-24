using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public UnityEvent score = new UnityEvent();

    public UnityEvent lose = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstical")
        {
            lose.Invoke();
        } 
            else if (other.gameObject.tag == "Scoring")
        {
            score.Invoke();
        }
    }
}
