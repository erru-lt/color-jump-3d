using System;

namespace Assets.Scripts.Services.InputService
{
    public class InputService : IInputService
    {
        private const string Jump = "Jump";
        private const string ChangeColor = "ChangeColor";

        public bool IsColorChangeButtonDown() =>
            SimpleInput.GetButtonDown(ChangeColor);

        public bool IsJumpButtonDown() =>
            SimpleInput.GetButtonDown(Jump);

        public bool IsJumpButtonUp() =>
            SimpleInput.GetButtonUp(Jump);
    }
}
