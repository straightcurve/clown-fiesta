namespace C_Character
{
    public interface IStatus
    {
        bool CanCast { get; set; }
        bool CanMove { get; set; }
        StateType Type { get; set; }

        void Enter(IState state);
    }
}