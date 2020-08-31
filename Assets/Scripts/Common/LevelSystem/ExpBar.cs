using System;

public class ExpBar : ProgressBar
{
    private LevelSystem levelSystem;

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        SetValue(levelSystem.GetCurrentExperience());
        SetMaxValue(levelSystem.GetxperienceToNextLevel(), false);

        this.levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        this.levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, EventArgs e)
    {
        SetMaxValue(levelSystem.GetxperienceToNextLevel(), false);
        SetValue(levelSystem.GetCurrentExperience());
    }

    private void LevelSystem_OnExperienceChanged(object sender, EventArgs e)
    {
        SetValue(levelSystem.GetCurrentExperience());
    }
}
