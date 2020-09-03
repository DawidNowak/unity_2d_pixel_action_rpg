using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelSystem levelSystem;

    public GameObject pauseScreen;

    void Awake()
    {
        levelSystem = new LevelSystem();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        pauseScreen.SetActive(Time.timeScale == 0);
    }

    public LevelSystem GetLevelSystem()
    {
        return levelSystem;
    }
}
