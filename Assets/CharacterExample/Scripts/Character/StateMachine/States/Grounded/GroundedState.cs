using UnityEngine.InputSystem;

public abstract class GroundedState : MovementState
{
    private readonly GroundChecker _groundChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartGrounded();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches == false)
            StateSwitcher.SwitchState<FallingState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Jump.started += OnJumpKeyPressed;
        Input.Movement.Sprint.started += OnSprintKeyPressed;
        Input.Movement.Walk.started += OnWalkKeyPressed;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        Input.Movement.Jump.started -= OnJumpKeyPressed;
        Input.Movement.Sprint.started -= OnSprintKeyPressed;
        Input.Movement.Walk.started -= OnWalkKeyPressed;
    }

    private void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpingState>();
    private void OnSprintKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<SprintState>();
    //private void OnSprintKeyUnpressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<SprintState>();
    private void OnWalkKeyPressed(InputAction.CallbackContext obj) => StateSwitcher?.SwitchState<WalkingState>();
    //private void OnWalkKeyUnPressed(InputAction.CallbackContext obj) => StateSwitcher?.SwitchState<WalkingState>();
}
