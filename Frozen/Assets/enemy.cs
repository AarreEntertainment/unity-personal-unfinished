using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BzKovSoft.RagdollTemplate.Scripts.Charachter;
public class enemy : MonoBehaviour, IBzRagdollCharacter
{
    #region IBzRagdollCharacter
    public Vector3 CharacterVelocity
    {
        get
        {
            // when the character becomes a ragdoll,
            // initial rigidbodys’ velocity will be taken out of there
            return GetComponent<Rigidbody>().velocity;
        }
    }

    public void CharacterEnable(bool enable)
    {
        // you need to disable character collider and rigidbody (CharacterController)
        GetComponent<CapsuleCollider>().enabled = enable;
        var rigidbody = GetComponentInChildren<Rigidbody>();
        rigidbody.isKinematic = !enable;
    }
    #endregion

    public float speed;
    bool followPlayer = false;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        scream = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).GetComponent<AudioSource>();
    }
    AudioSource scream;
    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if(Vector3.Distance(transform.position, player.transform.position) < 20)
        {
            followPlayer = true;
        }

        if (followPlayer)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
            transform.LookAt(player.transform);
            GetComponent<Animator>().SetFloat("speed", 1);
        }
        else
            GetComponent<Animator>().SetFloat("speed", 0);
    }
public void ragdoll()
    {
        IBzRagdoll ragdoll = GetComponent<IBzRagdoll>();
        ragdoll.IsRagdolled = !ragdoll.IsRagdolled;
        scream.Play();
    }
}
