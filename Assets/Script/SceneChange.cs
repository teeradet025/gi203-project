using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
   

    public void changeScene()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void SceneCredit()
    {
        SceneManager.LoadScene("Scenes/Credit");
    }
    public void SceneMainManu()
    {
        SceneManager.LoadScene("Scenes/MainManuScene");
    }
}
