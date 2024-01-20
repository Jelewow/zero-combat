using System;
using UnityEngine;

namespace ZeroCombat.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private int _distance;
        [SerializeField] private float _offsetY;

        private void LateUpdate()
        {
            if (_target == null)
            {
                return;
            }

            var rotation = Quaternion.Euler(_rotationAngleX, 0f, 0f);
            var position = rotation * new Vector3(0f, 0f, -_distance) + GetFollowingPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(Transform target)
        {
            _target = target;
        }
        
        private Vector3 GetFollowingPosition()
        {
            var followingPosition = _target.position;
            followingPosition.y += _offsetY;
            return followingPosition;
        }
    }
}