namespace C_Character
{
    public class StunnedState : IState {

        public void Enter(IStatus status)
        {
            status.CanCast = false;
            status.CanMove = false;
            status.Type = StateType.Stunned;
        }
    }
}