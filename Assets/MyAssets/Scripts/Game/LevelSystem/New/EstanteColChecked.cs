using UnityEngine;
public class EstanteColChecked : MonoBehaviour
{
    [SerializeField] Animator[] CheckEstante;
    [SerializeField] PlayerEstanteCol playerEstanteCol;
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] GameObject[] itemKindom;
    void Start()
    {
        for (int i = 0; i < itemKindom.Length; i++)
        {
            itemKindom[i].SetActive(false);
        }
    }
    void Update()
    {
        if (loadLevelSystem.inventoryItemDataV2[0].itemIsCheck)
        {
            CheckEstante[0].SetBool("estanteTrue", true);
            itemKindom[0].SetActive(true);
        }
        else
        {
            CheckEstante[0].SetBool("estanteTrue", false);
            itemKindom[0].SetActive(false);
        }
        if (loadLevelSystem.inventoryItemDataV2[1].itemIsCheck)
        {
            CheckEstante[1].SetBool("estanteTrue", true);
            itemKindom[1].SetActive(true);
        }
        else
        {
            CheckEstante[1].SetBool("estanteTrue", false);
            itemKindom[1].SetActive(false);
        }
        if (loadLevelSystem.inventoryItemDataV2[2].itemIsCheck)
        {
            CheckEstante[2].SetBool("estanteTrue", true);
            itemKindom[2].SetActive(true);
        }
        else
        {
            CheckEstante[2].SetBool("estanteTrue", false);
            itemKindom[2].SetActive(false);
        }
        if (loadLevelSystem.inventoryItemDataV2[3].itemIsCheck)
        {
            CheckEstante[3].SetBool("estanteTrue", true);
            itemKindom[3].SetActive(true);
        }
        else
        {
            CheckEstante[3].SetBool("estanteTrue", false);
            itemKindom[3].SetActive(false);
        }
        if (loadLevelSystem.inventoryItemDataV2[4].itemIsCheck)
        {
            CheckEstante[4].SetBool("estanteTrue", true);
            itemKindom[4].SetActive(true);
        }
        else
        {
            CheckEstante[4].SetBool("estanteTrue", false);
            itemKindom[4].SetActive(false);
        }
    }
}
