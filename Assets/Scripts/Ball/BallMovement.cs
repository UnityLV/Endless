using UnityEngine;

public sealed class BallMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _ballRigitBody;

    private HoldableButton _moveUpButton;
    private float _verticalMoveSpeed;
    private float _defaultMoveSpeed = 5f;

    public float VerticalMoveSpeed => _verticalMoveSpeed;

    private void OnEnable() => _verticalMoveSpeed = _defaultMoveSpeed;

    private void FixedUpdate() => Move();

    public void Init(HoldableButton moveUpButton) => _moveUpButton = moveUpButton;

    public void SetVercticalSpeed(float speed) => _verticalMoveSpeed = speed;

    private void Move()
    {
        if (_moveUpButton.IsHold)
            MoveUp();
        else
            MoveDown();
    }

    private void MoveUp() => SetVerticalVelosity(_verticalMoveSpeed);

    private void MoveDown() => SetVerticalVelosity(-_verticalMoveSpeed);

    private void SetVerticalVelosity(float velosity)
    {
        Vector2 withVerticalVelosity = new Vector2(_ballRigitBody.velocity.x, velosity);
        _ballRigitBody.velocity = withVerticalVelosity;
    }
}
