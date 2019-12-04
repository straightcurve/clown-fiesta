namespace C_Character
{

    public class Status : IStatus
    {
        public bool CanCast { get; set; }
        public bool CanMove { get; set; }

        public StateType Type { get; set; }

        public void Enter(IState state) {
            state.Enter(this);
        }
    }
}