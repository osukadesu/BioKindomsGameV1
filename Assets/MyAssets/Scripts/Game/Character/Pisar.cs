using UnityEngine;
public class Pisar : MonoBehaviour
{
    [SerializeField] AudioSource audioSource1,audioSource2;
    [SerializeField] PlayerMove playerMove;
    void Run1()
    {
        if (playerMove.CanJump)
        {
            audioSource1.Play();
        }
        else audioSource1.Stop();
    }
    void Run2()
    {
        if (playerMove.CanJump)
        {
            audioSource2.Play();
        } 
        else audioSource2.Stop();
    }
}