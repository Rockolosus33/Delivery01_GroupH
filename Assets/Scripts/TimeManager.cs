using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timer;

    public static TimeManager instance;

    private void Awake()
    {
        if (TimeManager.instance == null)
        {
            TimeManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        if (timer < 60f)
        {
            timer += Time.deltaTime;
        }
    }

    public float GetTime()
    {
        return timer;
    }
}