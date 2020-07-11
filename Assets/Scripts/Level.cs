using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class Level : MonoBehaviour
    {
        [SerializeField] int breakableBlocks = 0;

        private void Update()
        {
            if (breakableBlocks == 0)
            {
                var currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.buildIndex + 1);
            }
        }

        public void AddBlock()
        {
            breakableBlocks++;
        }

        public void RemoveBlock()
        {
            breakableBlocks--;
        }
    }
}
