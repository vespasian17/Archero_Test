using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool timeResume = true;
    public void StopTime()
    {
        timeResume = false;
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        timeResume = true;
        Time.timeScale = 1;
    }
}