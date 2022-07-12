using System.Collections.Generic;
using System.Collections;
using UnityEngine;

//<summary>
// This class is a state machine.
// Control the state of the character.
//</summary>
public class PlayerBehavior : State
{
    //<summary>
    // This class is a abstract class to create a state machine.
    //</summary>
    public PlayerBehavior(CharacterController characterController) : base(characterController)
    {
    }
    public override IEnumerator Start()
    {
        yield break;
    }

    // <summary>
    // This method is used to stop the character.
    // When the character is falling (hit the ice), the character will stop moving.
    // </summary>
    public override IEnumerator FallenStuns()
    {
        yield return new WaitForSeconds(4f);

        CharacterController.m_Character.m_Stuns = false;
        CharacterController.m_Stuns = false;
        CharacterController.m_Character.animStuns.applyRootMotion = true;
        CharacterController.m_Character.animShadow.applyRootMotion = true;

        CharacterController.m_Character.m_CurrentSpeed = CharacterController.m_Character.m_InitialSpeed;
        CharacterController.m_Character.rootObject.transform.localRotation = Quaternion.identity;

        CharacterController.m_Character.animStuns.SetBool("isCrash", CharacterController.m_Stuns);
        CharacterController.m_Character.animShadow.SetBool("isCrash", CharacterController.m_Stuns);
    }

    // <summary>
    // This method is used to increasing the speed
    // </summary> 
    public override IEnumerator AccelerationUp()
    {
        yield return new WaitForSeconds(1f);

        CharacterController.m_VelocityUp = true;
        CharacterController.m_UpSpeed = false;
    }

    // <summary>
    // This method is used to return the rotation of the character.
    // </summary>
    public override IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(CharacterController.m_SecondChangeLine);

        CharacterController.m_CharacterPosition = 0;

        CharacterController.m_IsChangeLine = true;
        CharacterController.m_IsChangePosition = false;
    }

    // <summary>
    // This method is used to rotation the front wheel of the character.
    // After the character is changing line, the character will rotate the front wheel.
    // </summary> 
    public override IEnumerator ReturnRotation()
    {
        yield return new WaitForSeconds(CharacterController.m_SecondChangeLine);

        CharacterController.m_Character.rootObject.transform.localRotation = Quaternion.identity;

        CharacterController.m_Character.wheelCream[0].transform.localRotation = Quaternion.identity;
        CharacterController.m_Character.wheelCream[1].transform.localRotation = Quaternion.identity;
    }

    // <summary>
    // This method is used to check the remaining speed.
    // </summary>
    public override IEnumerator CheckRemainBoost()
    {
        yield return new WaitForSeconds(2f);

        CharacterController.ChangeSpeed();
    }

}