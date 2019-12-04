namespace C_Character
{
    public class SilencedState : IState {
        
        public void Enter(IStatus status)
        {
            status.CanCast = false;
            status.Type = StateType.Silenced;
        }
    }
}