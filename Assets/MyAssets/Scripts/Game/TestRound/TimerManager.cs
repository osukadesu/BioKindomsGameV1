using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] CompareSystem compareSystem;
    [SerializeField] GameObject timerContainer;
    [SerializeField] Text textTimer;
    [SerializeField] TextManager textManager;
    [SerializeField] Image imgFiller;
    [SerializeField] int fillMax;
    [SerializeField] float timer, currentFill, timerForMethod;
    public float Timer { get => timer; set => timer = value; }
    public float _TimerForMethod { get => timerForMethod; set => timerForMethod = value; }
    void Awake()
    {
        animationsManager = FindObjectOfType<AnimationsManager>();
        compareSystem = FindObjectOfType<CompareSystem>();
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
        StartCoroutine(TimerMethod());
        TimerEnd();
        imgFiller.fillAmount = currentFill / fillMax;
    }
    IEnumerator TimerMethod()
    {
        yield return new WaitForSeconds(timerForMethod);
        if (timer > 0 && compareSystem._startGame)
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
                if (!animationsManager.btnPressed[i] && compareSystem._idBtnSelect == 3 && !compareSystem._startGame)
                {
                    textManager.ShowText(1, "No seleccionaste!", "txtShow");
                    compareSystem.cardContent.SetActive(false);
                    StartCoroutine(IEResetValues(5f));
                    StartCoroutine(compareSystem.ResetGameForNotSelect(false, null, null, 9.5f, 5f));
                }
            }
        }
    }
    public IEnumerator IEResetValues(float _timerIERV)
    {
        yield return new WaitForSeconds(_timerIERV);
        timer = 5f;
        currentFill = 5f;
        animationsManager.SetTimerAnimation(false);
    }
}