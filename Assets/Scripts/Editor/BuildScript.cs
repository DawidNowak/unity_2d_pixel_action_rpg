using UnityEditor;

public static class BuildSrcipt
{
    static string[] scenes = { "Assets/Scenes/SampleScene.unity" };
    static string name = "2D action rpg";

    [MenuItem("Build/Build WebGL")]
    public static void BuildWebGL()
    {
        BuildPipeline.BuildPlayer(scenes, @"C:\Unity\Windows agent\_work\1\s\_2D action rpg\output", BuildTarget.WebGL, BuildOptions.None);
    }

    [MenuItem("Build /Build Windows")]
    static void BuildWindows()
    {
        BuildPipeline.BuildPlayer(scenes, "./" + name + "_Windows/" + name, BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    [MenuItem("Build/Build Linux")]
    static void BuildLinux()
    {
        BuildPipeline.BuildPlayer(scenes, "./" + name + "_Linux/" + name, BuildTarget.StandaloneLinux64, BuildOptions.None);
    }

    [MenuItem("Build/Build All")]
    static void BuildAll()
    {
        BuildLinux();
        BuildWindows();
        BuildWebGL();
    }
}