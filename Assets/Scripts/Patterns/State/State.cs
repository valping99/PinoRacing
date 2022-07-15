using System.Collections;
// <summary>
// This class is a abstract class to create a state machine.
// </summary>
public abstract class State
{

    protected CharacterController CharacterController;

    public State(CharacterController characterController)
    {
        CharacterController = characterController;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator StopMoving()
    {
        yield break;
    }

    public virtual IEnumerator FallenStuns()
    {
        yield break;
    }

    public virtual IEnumerator AccelerationUp()
    {
        yield break;
    }

    public virtual IEnumerator ReturnRotation()
    {
        yield break;
    }

    public virtual IEnumerator CheckRemainBoost()
    {
        yield break;
    }

    public virtual IEnumerator ReturnNormal()
    {
        yield break;
    }
}