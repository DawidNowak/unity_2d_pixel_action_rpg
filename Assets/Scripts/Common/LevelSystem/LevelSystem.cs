using System;

public class LevelSystem
{
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    public LevelSystem()
    {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }

    public int GetCurrentLevel()
    {
        return level;
    }

    public int GetCurrentExperience()
    {
        return experience;
    }

    public int GetxperienceToNextLevel()
    {
        return experienceToNextLevel;
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        while (experience >= experienceToNextLevel)
        {
            level++;
            experience -= experienceToNextLevel;
            OnLevelChanged?.Invoke(this, EventArgs.Empty);
        }

        OnExperienceChanged?.Invoke(this, EventArgs.Empty);
    }
}
