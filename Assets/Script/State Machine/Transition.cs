
public struct Transition
{

    public delegate bool TransitionCondition();

    public State nextState;
    public TransitionCondition shouldNext;
}