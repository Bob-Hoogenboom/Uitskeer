using UnityEngine;
using UnityEngine.Events;


// logic for the timer
public class Timer : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text displayText;
    [SerializeField] float startSec;

    public UnityEvent onTimerEnd;

    private float currentTime;
    private bool paused = false;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startSec;
        SetTimer();
    }

    // display time to timer function
    private void SetTimer()
    {
        int min = Mathf.FloorToInt(currentTime / 60);
        int sec = Mathf.FloorToInt(currentTime % 60);

        displayText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    // pause and unpause fuction
    public void Pause()
    {
        paused = true;
    }
    public void UnPause()
    {
        paused = false;
    }

    // add seconds and get seconds fuctions
    public void addSeconds(float plusSec)
    {
        currentTime += plusSec;
    }
    public float getSeconds()
    {
        return currentTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0 && !paused)
        {
            currentTime -= Time.deltaTime;
            SetTimer();
        }
        else if (currentTime > 0 && paused)
        {
            return;
        }
        else
        {
            currentTime = 0;
            SetTimer();

            TimerOverEffect();
        }
    }

    public void TimePenalty(float penalty)
    {
        currentTime -= penalty;
    }


    //TODO add effects of timer running out
    public void TimerOverEffect()
    {
        onTimerEnd.Invoke();
        paused = true;
    }
}
