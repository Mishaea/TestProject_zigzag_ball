using UnityEngine;

public class DefaultFrameRateInitializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnRuntimeMethodLoad()
    {
        Application.targetFrameRate = 30;
    }
}