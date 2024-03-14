using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    [SerializeField] GameObject timerContainer;
    [SerializeField] Text textTimer;
    [SerializeField] TextManager textManager;
    [SerializeField] TestRoundSystem TestRoundSystem;
    [SerializeField] Animator timerAnim;
    [SerializeField] Image imgFiller;
    [SerializeField] int fillMax;
    [SerializeField] protected internal float timer, currentFill;
    void Start()
    {
        fillMax = 10;
        timer = 10f;
        currentFill = 10f;
    }
    void Awake()
    {
        TestRoundSystem = FindObjectOfType<TestRoundSystem>();
        textManager = FindObjectOfType<TextManager>();
    }
    void Update()
    {
        StartTimerMethod();
        imgFiller.fillAmount = currentFill / fillMax;
    }
    void StartTimerMethod()
    {
        StartCoroutine(TimerMethod());
    }
    IEnumerator TimerMethod()
    {
        yield return new WaitForSeconds(2f);
        if (timer > 0)
        {
            timerContainer.SetActive(true);
            timer -= Time.deltaTime;
            currentFill -= Time.deltaTime;
            float timerRound = Mathf.Round(timer);
            textTimer.text = timerRound.ToString();
        }
        if (timer < 6)
        {
            timerAnim.SetBool("timerLoadChange", true);
        }
        else
        {
            timerAnim.SetBool("timerLoadChange", false);
        }
    }
}