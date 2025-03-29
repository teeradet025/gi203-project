using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public BGmusic BGmusic;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
         PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    
    public void stopM()
    {
        BGmusic.instance.GetComponent<AudioSource>().Pause();
    }

    public void startM()
    {
        BGmusic.instance.GetComponent<AudioSource>().Play();
    }
}
