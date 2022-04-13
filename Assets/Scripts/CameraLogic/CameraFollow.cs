using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _rotationAngleX;
    [SerializeField] private float _rotationAngleY;

    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _zOffset;

    [SerializeField] private Transform _targetToFollow;

    private void LateUpdate()
    {
        if (_targetToFollow == null) return;

        FollowTarget();
    }

    public void Target(GameObject targetToFollow) => 
        _targetToFollow = targetToFollow.transform;

    private void FollowTarget()
    {
        Quaternion rotation = Quaternion.Euler(_rotationAngleX, _rotationAngleY, 0.0f);
        Vector3 position = rotation * new Vector3(0f, 0.0f, -_zOffset) + TargetPosition();

        transform.rotation = rotation;
        transform.position = position;
    }

    private Vector3 TargetPosition()
    {
        Vector3 targetPosition = _targetToFollow.position;

        targetPosition.x += _xOffset;
        targetPosition.y += _yOffset;
        targetPosition.z += _zOffset;

        return targetPosition;
    }
}
