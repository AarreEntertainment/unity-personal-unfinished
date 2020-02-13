using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellcasting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public ParticleSystem spellEffect;
    public void firespell()
    {
        spellEffect.Play();
        Collider[] colliders = Physics.OverlapSphere(GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).transform.position, 140);
        foreach (Collider col in colliders)
        {
            Debug.Log(col.name);
            if (col.GetComponent<enemy>() != null)
            {
                col.GetComponent<enemy>().ragdoll();
                col.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).GetComponent<Rigidbody>().AddForce(
                    (col.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).position- GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).transform.position).normalized *1000+
                    Vector3.up * 1000, ForceMode.Impulse);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetTrigger("bomb");
        }
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("bomb"))
        {
            GetComponent<Invector.CharacterController.vThirdPersonController>().lockMovement = true;
            GetComponent<Invector.CharacterController.vThirdPersonController>().input.x = 0;
            GetComponent<Invector.CharacterController.vThirdPersonController>().input.y = 0;

        }
        else
            GetComponent<Invector.CharacterController.vThirdPersonController>().lockMovement = false;
    }
}
