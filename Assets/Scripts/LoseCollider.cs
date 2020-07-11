using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class LoseCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
            SceneManager.LoadScene("Game Over");
        }
    }
}
