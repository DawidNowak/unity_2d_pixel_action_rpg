using UnityEngine;
using static Assets.Scripts.Utils.Enums;

namespace Assets.Scripts.Utils
{
    public static class Extensions
    {
        public static Vector3 ConvertToVector3(this Facing facing)
        {
            switch (facing)
            {
                case Facing.Left:
                    return new Vector3(-1f, 0f, 0f);
                case Facing.Top:
                    return new Vector3(0f, 1f, 0f);
                case Facing.Right:
                    return new Vector3(1f, 0f, 0f);
                case Facing.Down:
                default:
                    return new Vector3(0f, -1f, 0f);
            }
        }
    }
}
