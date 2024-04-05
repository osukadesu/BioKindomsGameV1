using UnityEngine;
public class LevelController : MonoBehaviour
{
    [SerializeField] LevelSelect levelSelect;
    void Awake()
    {
        levelSelect.Configure(this);
    }
    public void ButtonGoGameOrQuest(int _value)
    {
        switch (_value)
        {
            case 0:
                levelSelect.GoGame();
                break;
            case 1:
                levelSelect.GoQuest();
                break;
        }
    }
}