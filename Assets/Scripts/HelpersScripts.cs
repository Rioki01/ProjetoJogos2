using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelpersScripts
{
    private static Matrix4x4 Isomatrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));

    public static Vector3 ToIso(this Vector3 Input) => Isomatrix.MultiplyPoint3x4(Input);
}
