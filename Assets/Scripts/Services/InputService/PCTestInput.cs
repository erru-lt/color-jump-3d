using UnityEngine;

namespace Assets.Scripts.Services.InputService
{
    public class PCTestInput : IInputService
    {
        public bool IsColorChangeButtonDown() => 
            Input.GetKeyDown(KeyCode.D);

        public bool IsJumpButtonDown() => 
            Input.GetKeyDown(KeyCode.S);

        public bool IsJumpButtonUp() =>
            Input.GetKeyUp(KeyCode.A);
    }
}
