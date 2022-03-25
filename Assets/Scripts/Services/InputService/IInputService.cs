namespace Assets.Scripts.Services.InputService
{
    public interface IInputService
    {
        bool IsJumpButtonDown();
        bool IsColorChangeButtonDown();
        bool IsJumpButtonUp();
    }
}