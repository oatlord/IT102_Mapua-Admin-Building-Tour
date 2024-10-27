using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private Scene scene;
    private int currentBuildIndex;

    void Start() {
        scene = SceneManager.GetActiveScene();
    }
    public void clickPlayButton() {
        SceneManager.LoadScene("Floor 1");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        currentBuildIndex = scene.buildIndex;
        if (currentBuildIndex == 4) {
            SceneManager.LoadScene(currentBuildIndex-1);
        } else {
            SceneManager.LoadScene(currentBuildIndex+1);
        }
    }
}
