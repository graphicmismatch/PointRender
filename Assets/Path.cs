using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Path 
{
    public float[] points;

    public Vector3[] coalesce()
    {
        int l = points.Length / 3;
        Vector3[] pts = new Vector3[l];
        for (int i = 0; i < (l * 3) - 3; i += 3)
        {
            pts[i / 3] = new Vector3(points[i], points[i + 1], points[i + 2]);
        }
        return pts;
    }
}
