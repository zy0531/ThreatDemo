using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsClass
{
    public static Vector3 GetVectorFromAngle(float angle)
    {
        //float angleRad = angle * (Mathf.PI / 180f);
        //return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));

        float angleRad = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (n < 0) n += 360;
        return n;
    }
}
