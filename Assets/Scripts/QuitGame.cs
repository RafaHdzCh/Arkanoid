using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitArkanoid()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
