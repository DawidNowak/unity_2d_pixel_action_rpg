using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelSystem levelSystem;

    void Start()
    {
        levelSystem = new LevelSystem();
    }

    public LevelSystem GetLevelSystem()
    {
        return levelSystem;
    }
}
