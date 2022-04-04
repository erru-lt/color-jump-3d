using UnityEngine;

namespace Assets.Scripts.Logic.Platforms
{
    public abstract class Platform : MonoBehaviour
    {
        protected abstract void OnTriggerEnter(Collider other);
    }
}
