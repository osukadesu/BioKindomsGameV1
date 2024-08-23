using System.IO;
using UnityEngine;
public class EstanteColChecked : MonoBehaviour
{
    [SerializeField] Animator[] CheckEstante;
    [SerializeField] InventoryItemDataV2[] inventoryItemDataV2;
    [SerializeField] GameObject[] itemKindom;
    void Update()
    {
        string datapath = Application.persistentDataPath + "/player.data";
        if (File.Exists(datapath))
        {
            EstanteBool("estanteTrue");
        }
    }
    public void EstantesInitial()
    {
        for (int i = 0; i < itemKindom.Length; i++)
        {
            itemKindom[i].SetActive(false);
        }
    }
    public void EstanteBool(string _name)
    {
        for (int i = 0; i < inventoryItemDataV2.Length; i++)
        {
            bool isChecked = inventoryItemDataV2[i].itemIsCheck;
            CheckEstante[i].SetBool(_name, isChecked);
            itemKindom[i].SetActive(isChecked);
        }
    }
}