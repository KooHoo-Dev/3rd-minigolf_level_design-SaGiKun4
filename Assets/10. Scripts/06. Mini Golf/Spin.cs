using UnityEngine;

namespace Study3D.MiniGolf
{
    public class Spin : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed = 90f;

        private void Update()
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        }
    }
}
