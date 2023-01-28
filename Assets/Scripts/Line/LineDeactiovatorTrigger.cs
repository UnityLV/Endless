using UnityEngine;

public sealed class LineDeactiovatorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out LineDeactivator deactivator))
        {
            deactivator.Deactivate();
        }
    }
}
