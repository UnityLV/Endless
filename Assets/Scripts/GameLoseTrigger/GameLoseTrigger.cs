using UnityEngine;

public sealed class GameLoseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GameLoseDetector detector))
        {
            detector.Detect();
        }
    }
}
