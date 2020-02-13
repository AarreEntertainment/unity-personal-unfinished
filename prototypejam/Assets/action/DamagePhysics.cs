using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePhysics : MonoBehaviour
{
    public Transform centerOfMass;
    public float hardness;
    // Start is called before the first frame update
    void Start()
    {
        if(centerOfMass!=null)
            GetComponent<Rigidbody>().centerOfMass = centerOfMass.position;
    }
    public float damage;

    [ExecuteInEditMode]
    private void OnValidate()
    {
        var cols = GetComponentsInChildren<Collider>();
        foreach (Collider col in cols)
        {
            if (col.GetComponent<DamageReferrer>() == null)
            {
                DamageReferrer dref = col.gameObject.AddComponent<DamageReferrer>();
                dref.dp = this;
            }
            else if (col.GetComponent<DamageReferrer>().dp == null)
            {
                col.GetComponent<DamageReferrer>().dp = this;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        var rb = GetComponent<Rigidbody>();
        Rigidbody hitrb;
        if(centerOfMass!=null)
            hitrb = centerOfMass.GetComponent<Rigidbody>();
        else
            hitrb = GetComponent<Rigidbody>();
       // Debug.Log(hitrb.velocity.magnitude);
        damage = (hitrb.velocity.magnitude-transform.root.GetComponent<Rigidbody>().velocity.magnitude) * rb.mass *Mathf.Pow(hardness,2);

        var renderers = GetComponentsInChildren<Renderer>();
        foreach(Renderer rend in renderers)
        {
            Color col = new Color32((byte)(damage/10), (byte)0,(byte) 0, (byte) 255);
            Material[] mat = rend.materials;
            mat[0].color = col;
            rend.materials = mat;
        }
    }
}
