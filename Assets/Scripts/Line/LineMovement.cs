using UnityEngine;

public sealed class LineMovement : MonoBehaviour 
{
    private float _speed;

    private void Update() => Move();

    public void Init(float speed)
    {
        _speed = speed;
    }

    private void Move() => transform.Translate(-transform.right * _speed * Time.deltaTime);
}
