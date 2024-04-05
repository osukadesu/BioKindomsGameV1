using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] GameObject timerContainer;
    [SerializeField] Text textTimer;
    [SerializeField] TextManager textManager;
    [SerializeField] TestRoundSystem testRoundSystem;
    [SerializeField] Image imgFiller;
    [SerializeField] int fillMax;
    [SerializeField] float timer, currentFill, timerForMethod;
    public float Timer { get => timer; set => timer = value; }
    public float _TimerForMethod { get => timerForMethod; set => timerForMethod = value; }
    void Awake()
    {
        animationsManager = FindObjectOfType<AnimationsManager>();
        testRoundSystem = FindObjectOfType<TestRoundSystem>();
        textManager = FindObjectOfType<TextManager>();
    }
    void Start()
    {
        fillMax = 5;
        timer = 5f;
        currentFill = 5f;
        timerForMethod = 3f;
    }
    void Update()
    {
        Debug.Log(timerForMethod);
        StartCoroutine(TimerMethod());
        TimerEnd();
        imgFiller.fillAmount = currentFill / fillMax;
    }
    IEnumerator TimerMethod()
    {
        yield return new WaitForSeconds(timerForMethod);
        if (timer > 0 && testRoundSystem.StartGame)
        {
            timerContainer.SetActive(true);
            timer -= Time.deltaTime;
            currentFill -= Time.deltaTime;
            float timerRound = Mathf.Round(timer);
            textTimer.text = timerRound.ToString();
            animationsManager.SetTimerAnimation(true);
        }
    }
    void TimerEnd()
    {
        if (timer < 0)
        {
            for (int i = 0; i < animationsManager.btnPressed.Length; i++)
            {
                if (!animationsManager.btnPressed[i] && testRoundSystem.IdBtnSelect == 3 && testRoundSystem.StartGame)
                {
                    textManager.ShowText("No seleccionaste!", "txtRoundShow");
                    switch (testRoundSystem._CurrentRound)
                    {
                        case 3:
                            StartCoroutine(IEResetValues(1));
                            break;
                        default:
                            StartCoroutine(IEResetValues(0));
                            break;
                    }
                }
            }
        }
    }
    public IEnumerator IEResetValues(int _type)
    {
        switch (_type)
        {
            case 0:
                yield return new WaitForSeconds(6f);
                break;
            case 1:
                yield return new WaitForSeconds(12f);
                break;
            case 2:
                yield return new WaitForSeconds(2f);
                break;
        }
        timer = 5f;
        currentFill = 5f;
        animationsManager.SetTimerAnimation(false);
    }
}