using System;
using UnityEngine;

namespace Assets.Scripts.Logic.VFX
{
    public class SpeedFX : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private void Update() => 
            Move();

        private void Move() => 
            transform.Translate(_moveSpeed * Time.deltaTime * transform.forward);
    }
}
