using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmIK : MonoBehaviour
{
    Animator animator;
    bool ikActive;
    public Transform leftHandObj;
    public Transform rightHandObj;
    Vector3 rHandEnd;
    Vector3 lHandEnd;
    // Start is called before the first frame update
    bool init;
    void Start()
    {
        rHandEnd = rightHandObj.localPosition;
        lHandEnd = leftHandObj.localPosition;
        animator = GetComponent<Animator>();
        ikActive = true;
        init = true;
    }
    void OnAnimatorIK()
    {
        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {

                // Set the look __target position__, if one has been assigned
               /* if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }*/

                // Set the right hand target position and rotation, if one has been assigned
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }

            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
    public Transform rightArmRotator;
    public Transform leftArmRotator;
    public float rotationmax;
    public Vector2 left = Vector2.zero;
    public Vector2 right = Vector2.zero;
    public float lTrigger;
    public float rTrigger;
    // Update is called once per frame
    void Update()
    {
        if (!init)
            return;
        lTrigger = Input.GetAxis("lTrigger");
        rTrigger = Input.GetAxis("rTrigger");


        left = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        right = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        if (lTrigger > 0.8f)
        {
            animator.SetTrigger("PrimaryAttack");
        }
        /*leftHandObj.localPosition = lHandEnd * lTrigger;
        rightHandObj.localPosition = rHandEnd * rTrigger;
        leftArmRotator.forward = transform.forward + transform.up * left.y + transform.right * left.x;
        rightArmRotator.forward = transform.forward + transform.up * right.y + transform.right*right.x;*/
    }
}
