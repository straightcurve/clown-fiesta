namespace C_Character
{
    public class NormalState : IState
    {
        public void Enter(IStatus status)
        {
            status.CanCast = true;
            status.CanMove = true;
            status.Type = StateType.Normal;
        }
    }
}