using System.Collections;
using System.Collections.Generic;
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Input;
using UnityEngine;

public class LockPlayerControls : MonoBehaviour
{
    private UltimateCharacterLocomotionHandler playerControl;

    private UnityInput MouseLook;

    public bool LockPlayerInput = false;

    public bool LockMouseLook = false;
    public bool LockAllControls = false;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<UltimateCharacterLocomotionHandler>();
        MouseLook = GetComponent<UnityInput>();
    }

    // Update is called once per frame
    void Update()
    {
        playerControl.enabled = !LockPlayerInput;
        MouseLook.enabled = !LockMouseLook;

        if (LockAllControls)
        {
            LockMouseLook = true;
            LockPlayerInput = true; 
        }
        else
        {
            LockMouseLook = false;
            LockPlayerInput = false; 
        }
       

    }

    public void LockAllPlayerInput()
    {
        LockAllControls = true;
    }
   
    public void UnlockAllPlayerInput()
    {
        LockAllControls = false;
    }
}
