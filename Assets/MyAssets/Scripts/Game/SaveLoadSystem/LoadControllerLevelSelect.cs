public class LoadControllerLevelSelect : LoadControllerTemplate
{
    protected internal override void LoadControllerMethod()
    {
        if (menuController.IsNewGame)
        {
            levelLoad = false;
        }
        if (menuController.IsLoadGame)
        {
            levelLoad = true;
        }
    }
}