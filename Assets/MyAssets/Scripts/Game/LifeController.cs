using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class LifeController : MonoBehaviour
{
    [SerializeField] int maxLife = 100;
    [SerializeField] protected internal float currentLife;
    [SerializeField] protected internal Image imgLife, imgLifeHide;
    [SerializeField] bool hit;
    void Start()
    {
        currentLife = maxLife;
        imgLifeHide.gameObject.SetActive(false);
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