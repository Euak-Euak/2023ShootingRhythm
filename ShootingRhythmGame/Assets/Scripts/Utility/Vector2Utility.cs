using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomNamespace
{
    public static class Vector2Utility
    {
        public static Vector2 GetBezierPosition(this Vector2 pos0, Vector2 pos1, Vector2 pos2, Vector2 pos3, float t)
        {
            Vector2 q0 = Vector2.Lerp(pos0, pos1, t);
            Vector2 q1 = Vector2.Lerp(pos1, pos2, t);
            Vector2 q2 = Vector2.Lerp(pos2, pos3, t);

            Vector2 r0 = Vector2.Lerp(q0, q1, t);
            Vector2 r1 = Vector2.Lerp(q1, q2, t);

            return Vector2.Lerp(r0, r1, t);
        }
    }
}
