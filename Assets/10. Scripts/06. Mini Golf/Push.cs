using UnityEngine;

namespace Study3D.MiniGolf
{
    public class Push : MonoBehaviour
    {
        [SerializeField] private float force = 40f;
    
        private void OnCollisionEnter(Collision collision)
        {
            Vector3 hitPoint = collision.GetContact(0).point;
    
            Rigidbody ball = collision.rigidbody;
    
            if (ball == null)
                return;
    
            ball.AddForceAtPosition(transform.forward * force, hitPoint, ForceMode.Impulse);
        }
    }
}