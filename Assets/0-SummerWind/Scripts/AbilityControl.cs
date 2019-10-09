using System;
using UnityEngine;
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities;

public class AbilityControl : MonoBehaviour
{
    public string AbilityName;
    private UltimateCharacterLocomotion characterLocomotion;

    public bool stopAbility = false;
    private void Start()
    {
        characterLocomotion = GetComponent<UltimateCharacterLocomotion>();
        var ability = characterLocomotion.GetAbility<SitDown>();
     
    }
    // Tries to start the jump ability. There are many cases where the ability may not start, 
    // such as if it doesn't have a high enough priority or if CanStartAbility returns false.
    private void Update()
    {
        if (stopAbility)
        {
            StopAbility();
            stopAbility = false;
        }
    }


    public void StartAbility()
    {
        characterLocomotion.TryStartAbility(characterLocomotion.GetAbility<SitDown>());

    }
    
    // Stop the jump ability if it is active.
    public void StopAbility( )
    {
        var ability = characterLocomotion.GetAbility<SitDown>();
        
        if (ability.IsActive) {
            characterLocomotion.TryStopAbility(ability); 
        }
        
    }
}