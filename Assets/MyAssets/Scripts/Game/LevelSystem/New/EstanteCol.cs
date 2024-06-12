using UnityEngine;
using UnityEngine.SceneManagement;
public class EstanteCol : EstanteColTemplate
{
    bool isF, isG;
    private void Awake()
    {
        if (isF)
        {
            levelSystemV2.ChangeLevel();
        }
        if (isG)
        {
            SceneManager.LoadScene(5);
        }
    }
    void Update()
    {
        if (canpressF)
        {
            if (Input.GetKey(KeyCode.F))
            {
                isF = true;
            }
            isF = false;
        }
        if (canpressG)
        {
            if (Input.GetKey(KeyCode.G))
            {
                isG = true;
            }
            isG = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        WhenEnter(other);
    }
    protected internal override void WhenEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (referenceItem.itemIsCheck)
            {
                SetInfo(1); canpressG = true;
            }
            else
            {
                SetInfo(2); canpressF = true;
            }
            Debug.Log(canpressF);
        }
    }
}