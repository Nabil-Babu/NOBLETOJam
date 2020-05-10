using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerControls : MonoBehaviour
{
    public LayerMask m_LayerMask;
    public bool enableGizmo = false; 

    public void KillTarget()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity, m_LayerMask);
        if(hitColliders.Length > 0)
        {
            foreach (var collider in hitColliders)
            {
                collider.GetComponentInParent<BanditControlls>().PlayDeathAnim();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(enableGizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
    }
}
