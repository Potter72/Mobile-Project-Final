using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    /// <summary>
    /// Class that contains events used by other scripts
    /// </summary>

    public static event UnityAction PlayerDied;
    public static void OnPlayerDied() => PlayerDied?.Invoke();
}
