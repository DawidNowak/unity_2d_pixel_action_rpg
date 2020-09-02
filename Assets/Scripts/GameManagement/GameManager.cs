using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelSystem levelSystem;

    void Awake()
    {
        levelSystem = new LevelSystem();
    }

    public LevelSystem GetLevelSystem()
    {
        return levelSystem;
    }
}
