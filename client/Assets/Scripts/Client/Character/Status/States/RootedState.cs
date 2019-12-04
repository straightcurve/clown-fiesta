namespace C_Character
{
    public class RootedState : IState
    {
        public void Enter(IStatus status)
        {
            status.CanMove = false;
            status.Type = StateType.Rooted;
        }
    }
}