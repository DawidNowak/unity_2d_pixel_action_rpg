using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelSystem levelSystem;
    private StatisticsSystem statisticsSystem;

    public GameObject PauseScreen;
    public GameObject Menu;
    public GameObject CharStats;
    public GameObject Hud;

    void Awake()
    {
        levelSystem = new LevelSystem();
        statisticsSystem = new StatisticsSystem(10, 10, 10);
        levelSystem.OnLevelChanged += statisticsSystem.LevelSystem_OnLevelChanged;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleCharStats();
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

    private void ToggleCharStats()
    {
        var isPause = Time.timeScale == 0;
        Time.timeScale = isPause ? 1 : 0;
        PauseScreen.SetActive(!isPause);
        Hud.SetActive(isPause);
        CharStats.SetActive(!isPause);
    }

    public LevelSystem GetLevelSystem()
    {
        return levelSystem;
    }

    internal StatisticsSystem GetStatisticsSystem()
    {
        return statisticsSystem;
    }
}
