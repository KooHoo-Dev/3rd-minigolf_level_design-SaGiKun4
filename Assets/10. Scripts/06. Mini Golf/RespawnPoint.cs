using UnityEngine;

namespace Study3D.MiniGolf
{
    public class RespawnPoint : MonoBehaviour
    {
        [SerializeField] private Transform visual;
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float rotateSpeed = 180f;
        [SerializeField] private float disappearTime = 1f;

        private void OnTriggerEnter(Collider other)
        {
            GolfBall golfBall = other.GetComponent<GolfBall>();

            if (golfBall == null)
                return;

            golfBall.SetRespawnPoint(transform);

            StartCoroutine(DisappearEffect());
        }

        private System.Collections.IEnumerator DisappearEffect()
        {
            float timer = 0f;
            Vector3 startPosition = visual.position;

            while (timer < disappearTime)
            {
                timer += Time.deltaTime;

                visual.position = startPosition + Vector3.up * moveSpeed * timer;
                visual.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

                yield return null;
            }

            visual.gameObject.SetActive(false);
        }
    }
}