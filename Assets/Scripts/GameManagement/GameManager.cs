using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelSystem levelSystem;

    public GameObject PauseScreen;
    public GameObject Menu;
    public GameObject Hud;

    void Awake()
    {
        levelSystem = new LevelSystem();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        var isPause = Time.timeScale == 0;
        Time.timeScale = isPause ? 1 : 0;
        PauseScreen.SetActive(!isPause);
        Menu.SetActive(!isPause);
        Hud.SetActive(isPause);
    }

    public LevelSystem GetLevelSystem()
    {
        return levelSystem;
    }
}
