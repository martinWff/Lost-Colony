using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IInteractable, ITipHandler
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Interact(GameObject instigator)
    {
        animator.SetTrigger("Interact");
    }

    public string GetTip(GameObject instigator)
    {
        return "Press E to Open or Close the Door";
    }

}
