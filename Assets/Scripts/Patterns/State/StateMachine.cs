using UnityEngine;
//<summary>
// This class is a state machine.
// Control the state of the character.
//</summary>
public abstract class StateMachine : MonoBehaviour
{
    protected State State;

    //<summary>
    // This method is used to set the state of the character movement.
    //</summary>
    public void SetState(State state)
    {
        State = state;

        StartCoroutine(State.Start());
    }
}