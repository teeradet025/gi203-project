using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    public string sceneName;
    
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
