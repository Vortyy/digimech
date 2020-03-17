using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(new Vector3(0,0,0), transform.rotation, new Vector3 (1,1,1));
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
