[System.Serializable]
public class SingletonData
{
    public bool wasFirtsTime, wasEndQuest;
    public SingletonData(GeneralSingleton generalSingleton)
    {
        wasFirtsTime = generalSingleton.wasFirtsTime;
        wasEndQuest = generalSingleton.wasEndQuest;
    }
}