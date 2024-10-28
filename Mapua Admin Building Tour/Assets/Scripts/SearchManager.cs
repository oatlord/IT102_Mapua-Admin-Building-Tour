using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SearchManager : MonoBehaviour
{
    public GameObject searchBar;
    public GameObject player;
    private Rigidbody2D body;
    private Scene scene;
    private int sceneIndex;
    Vector2 target;
    float step;
    bool found;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
        step = 2f * Time.deltaTime;
        body = player.GetComponent<Rigidbody2D>();
        target = new Vector2(0f, 0f);
    }

    public bool Search()
    {
        string searchTxt = searchBar.GetComponent<TMP_InputField>().text.ToLower();
        found = false;
        if (sceneIndex == 1)
        {
            switch (searchTxt)
            {
                case "canteen":
                    setTarget(-2.996069f,-4.115806f);
                    break;
                case "book store":
                    setTarget(3.543062f,-3.7354f);
                    break;
                case "admin":
                    setTarget(3.364418f,0.3528565f);
                    break;
                default:
                    break;
            }
        }
        return found;
    }

    void setTarget(float x,float y) {
        target = new Vector2(x,y);
        found = true;
    }

    void FixedUpdate()
    {
        if (Search() == true)
        {
            body.transform.position = Vector2.MoveTowards(body.transform.position, target, step);
        }
    }
}
