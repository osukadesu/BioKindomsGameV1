[System.Serializable]
public class FirtsTimeData
{
    public bool _wasFirtsTime;
    public FirtsTimeData(GeneralSingleton generalSingleton)
    {
        _wasFirtsTime = generalSingleton.wasFirtsTime;
    }
}