public class FallingState : AirborneState
{
    private readonly GroundChecker _groundChecker;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartFalling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopFalling();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
        {
            Data.YVelocity = 0;

            if (IsHorizontalInputZero())
            {
                StateSwitcher.SwitchState<IdlingState>();
            }
            else if (Input.Movement.Sprint.IsPressed())
            {
                StateSwitcher.SwitchState<SprintState>();
            }
            else if (Input.Movement.Walk.IsPressed())
            {
                StateSwitcher.SwitchState<WalkingState>();
            }
            else
            {
                StateSwitcher.SwitchState<RunningState>();
            }
        }
    }
}
