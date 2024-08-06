using UnityEngine;
public class EstanteColChecked : MonoBehaviour
{
    [SerializeField] Animator[] CheckEstante;
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

        if (loadLevelSystem.iIDV[0].itemIsCheck)
        {
            CheckEstante[5].SetBool("estanteTrue", true);
            itemKindom[5].SetActive(true);
        }
        else
        {
            CheckEstante[5].SetBool("estanteTrue", false);
            itemKindom[5].SetActive(false);
        }
        if (loadLevelSystem.iIDV[1].itemIsCheck)
        {
            CheckEstante[6].SetBool("estanteTrue", true);
            itemKindom[6].SetActive(true);
        }
        else
        {
            CheckEstante[6].SetBool("estanteTrue", false);
            itemKindom[6].SetActive(false);
        }
        if (loadLevelSystem.iIDV[2].itemIsCheck)
        {
            CheckEstante[7].SetBool("estanteTrue", true);
            itemKindom[7].SetActive(true);
        }
        else
        {
            CheckEstante[7].SetBool("estanteTrue", false);
            itemKindom[7].SetActive(false);
        }
        if (loadLevelSystem.iIDV[3].itemIsCheck)
        {
            CheckEstante[8].SetBool("estanteTrue", true);
            itemKindom[8].SetActive(true);
        }
        else
        {
            CheckEstante[8].SetBool("estanteTrue", false);
            itemKindom[8].SetActive(false);
        }
        if (loadLevelSystem.iIDV[4].itemIsCheck)
        {
            CheckEstante[9].SetBool("estanteTrue", true);
            itemKindom[9].SetActive(true);
        }
        else
        {
            CheckEstante[9].SetBool("estanteTrue", false);
            itemKindom[9].SetActive(false);
        }
    }
}
