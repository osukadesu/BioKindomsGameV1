using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LifeController : MonoBehaviour
{
    [SerializeField] int maxLife = 100;
    [SerializeField] protected internal float currentLife;
    [SerializeField] Image imgLife;
    [SerializeField] bool hit;
    public float _CurrentLife { get => currentLife; set => currentLife = value; }
    void Start()
    {
        currentLife = maxLife;
    }
    void Update()
    {
        imgLife.fillAmount = currentLife / maxLife;
    }
    protected internal void RestarVida(int cantidad)
    {
        if (!hit && currentLife > 0)
        {
            currentLife -= cantidad;
            StartCoroutine(WaitHit());
        }
    }
    IEnumerator WaitHit()
    {
        hit = true;
        yield return new WaitForSeconds(.5f);
        hit = false;
    }
}