using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, 60);
    }
}
