public class LoadControllerGame : LoadControllerTemplate
{
    protected internal override void LoadControllerMethod()
    {
        if (menuController.IsNewGame)
        {
            levelLoad = false;
            //loadGame.GoNew();
        }
        if (menuController.IsLoadGame)
        {
            levelLoad = true;
            //loadGame.GoLoad();
        }
    }
}