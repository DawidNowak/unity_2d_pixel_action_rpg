using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class Enums
    {
        public enum Facing
        {
            Left,
            Top,
            Right,
            Down
        }

        public enum WalkingState
        {
            Standing,
            Walking
        }

        public enum Stance
        {
            Aggressive,
            Defensive,
            Coward
        }
    }
}
