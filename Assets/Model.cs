using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Model 
{
    public int[] settings;
    public float[][] paths;

    public Vector3[] coalesce(int pno)
    {
        int l = this.paths[pno].Length / 3;
        float[] points = this.paths[pno];
        Vector3[] pts = new Vector3[l];
        for (int i = 0; i < (l * 3) - 3; i += 3)
        {
            pts[i / 3] = new Vector3(points[i], points[i + 1], points[i + 2]);
        }
        return pts;
    }
}
