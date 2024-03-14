public class LoadControllerLevelSelect : LoadControllerTemplate
{
    protected internal override void LoadControllerMethod()
    {
        if (menuController.IsNewGame)
        {
            levelLoad = false;
            //loadLevelSelect.GoNew();
        }
        if (menuController.IsLoadGame)
        {
            levelLoad = true;
            //loadLevelSelect.GoLoad();
        }
    }
}