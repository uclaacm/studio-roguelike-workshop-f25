using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private int numScenes;
    private void Start()
    {
        numScenes = SceneManager.sceneCountInBuildSettings;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(Random.Range(0, numScenes));
        }
    }
}
