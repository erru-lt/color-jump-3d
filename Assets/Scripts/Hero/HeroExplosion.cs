using System;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroExplosion : MonoBehaviour
    {
        [SerializeField] private float _explosionForce;
        [SerializeField] private float _explosionRadius;
        private readonly int _cubesPerAxis = 8;

        [SerializeField] private MeshRenderer _meshRenderer;

        public void CreateCubes()
        {
            for (int x = 0; x < _cubesPerAxis; x++)
            {
                for (int y = 0; y < _cubesPerAxis; y++)
                {
                    for (int z = 0; z < _cubesPerAxis; z++)
                    {
                        InstantiateCube(new Vector3(x, y, z));
                    }
                }
            }
        }

        private void InstantiateCube(Vector3 position)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Renderer cubeRenderer = cube.GetComponent<Renderer>();

            cubeRenderer.material = _meshRenderer.material;
            
            cube.transform.localScale = transform.localScale / _cubesPerAxis;

            Vector3 firstCubePosition = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
            cube.transform.position = firstCubePosition + Vector3.Scale(position, cube.transform.localScale);

            Rigidbody cubeRigidbody = cube.AddComponent<Rigidbody>(); 
            
            Explode(cubeRigidbody);
        }

        private void Explode(Rigidbody rigidbody) => 
            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

    }
}
