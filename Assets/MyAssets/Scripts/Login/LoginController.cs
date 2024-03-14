using UnityEngine;
public class LoginController : MonoBehaviour
{
    [SerializeField] Animator animpanellogs, animpanelsquare, animbtnloggroups;
    void Start()
    {
        animpanellogs.SetBool("panellogsinitial", true);
        animpanellogs.SetBool("panellogsgologup", false);
        animpanellogs.SetBool("panellogsgologin", false);
        animpanelsquare.SetBool("panelsquareinitial", true);
        animpanelsquare.SetBool("panelsquaregologup", false);
        animpanelsquare.SetBool("panelsquaregologin", false);
        animbtnloggroups.SetBool("btngologgroupsinitial", true);
        animbtnloggroups.SetBool("btngologgroups2", false);
        animbtnloggroups.SetBool("btngologgroups3", false);
    }
    public void Gologup()
    {
        animpanellogs.SetBool("panellogsinitial", false);
        animpanellogs.SetBool("panellogsgologup", true);
        animpanellogs.SetBool("panellogsgologin", false);
        animpanelsquare.SetBool("panelsquareinitial", false);
        animpanelsquare.SetBool("panelsquaregologup", true);
        animpanelsquare.SetBool("panelsquaregologin", false);
        animbtnloggroups.SetBool("btngologgroupsinitial", false);
        animbtnloggroups.SetBool("btngologgroups2", true);
        animbtnloggroups.SetBool("btngologgroups3", false);
    }
    public void Gologin()
    {
        animpanellogs.SetBool("panellogsinitial", false);
        animpanellogs.SetBool("panellogsgologup", false);
        animpanellogs.SetBool("panellogsgologin", true);
        animpanelsquare.SetBool("panelsquareinitial", false);
        animpanelsquare.SetBool("panelsquaregologup", false);
        animpanelsquare.SetBool("panelsquaregologin", true);
        animbtnloggroups.SetBool("btngologgroupsinitial", false);
        animbtnloggroups.SetBool("btngologgroups2", false);
        animbtnloggroups.SetBool("btngologgroups3", true);
    }
}