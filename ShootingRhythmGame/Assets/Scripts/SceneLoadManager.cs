using UnityEngine.SceneManagement;

public enum SceneType
{
    Title,
    Main,
    Game,
    Shop
}

public static class SceneLoadManager
{
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void LoadScene(SceneType scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}
