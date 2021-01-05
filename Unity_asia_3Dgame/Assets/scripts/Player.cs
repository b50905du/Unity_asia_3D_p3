using UnityEngine;
using Invector.vCharacterController;

public class Player : MonoBehaviour
{
    private float hp = 100;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    public void hurt() 
    {
        hp -= 35;
        ani.SetTrigger("hit");

        if (hp <= 0) dead();
    }
    private void dead() 
    {
        ani.SetTrigger("die");
        vThirdPersonController vt = GetComponent<vThirdPersonController>();
        vt.lockMovement = true;
        vt.lockRotation = true;
    }

}
