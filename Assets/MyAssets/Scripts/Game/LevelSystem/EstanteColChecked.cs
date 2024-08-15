using UnityEngine;
public class EstanteColChecked : MonoBehaviour
{
    [SerializeField] Animator[] CheckEstante;
    [SerializeField] InventoryItemDataV2[] inventoryItemDataV2;
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
        for (int i = 0; i < inventoryItemDataV2.Length; i++)
        {
            bool isChecked = inventoryItemDataV2[i].itemIsCheck;
            CheckEstante[i].SetBool("estanteTrue", isChecked);
            itemKindom[i].SetActive(isChecked);
        }
    }
}