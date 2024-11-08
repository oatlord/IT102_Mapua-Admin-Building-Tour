using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private Scene scene;
    private int currentBuildIndex;
    private string objectTag;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        objectTag = gameObject.tag;
    }
    public void clickPlayButton()
    {
        SceneManager.LoadScene("intro-cutscene");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentBuildIndex = scene.buildIndex;
        if (objectTag == "Stairs Up")
        {
            if (currentBuildIndex != 4)
            {
                SceneManager.LoadScene(currentBuildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene("Feedback Screen");
            }
        }
        else if (objectTag == "Stairs Down")
        {
            if (currentBuildIndex != 1)
            {
                SceneManager.LoadScene(currentBuildIndex - 1);
            }
        }
    }
}
