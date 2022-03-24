using System;

namespace Assets.Scripts.Input
{
    public class InputService : IInputService
    {
        private const string Jump = "Jump";
        private const string ChangeColor = "ChangeColor";

        public bool IsColorChangeButtonDown() =>
            SimpleInput.GetButtonDown(ChangeColor);

        public bool IsJumpButtonDown() =>
            SimpleInput.GetButton(Jump);

        public bool IsJumpButtonUp() =>
            SimpleInput.GetButtonUp(Jump);
    }
}
