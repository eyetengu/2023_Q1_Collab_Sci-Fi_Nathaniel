using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EYE_Assets
{
    public class Foosball_Team_Animation_Control : MonoBehaviour
    {
        [SerializeField] private Transform[] _teamMembers_Rotator_01;
        [SerializeField] private Transform[] _teamMembers_Rotator_02;
        [SerializeField] private Transform[] _teamMembers_Rotator_03;


    //CORE FUNCTIONS
        public void SetAnimators(int value, bool animated)
        {
            if (value == 1)
            {
                foreach (var anim in _teamMembers_Rotator_01)
                {
                    var animController = anim.GetComponent<Animator>();
                    animController.SetBool("IsRunning", animated);
                }

                foreach (var anim in _teamMembers_Rotator_02)
                {
                    var animController = anim.GetComponent<Animator>();

                    animController.SetBool("IsRunning", !animated);
                }
                foreach (var anim in _teamMembers_Rotator_03)
                {
                    var animController = anim.GetComponent<Animator>();

                    animController.SetBool("IsRunning", !animated);
                }

            }
            else if (value == 2)
            {
                foreach (var anim in _teamMembers_Rotator_01)
                {
                    var animController = anim.GetComponent<Animator>();

                    animController.SetBool("IsRunning", !animated);
                }
                foreach (var anim in _teamMembers_Rotator_02)
                {
                    var animController = anim.GetComponent<Animator>();

                    animController.SetBool("IsRunning", animated);
                }
                foreach (var anim in _teamMembers_Rotator_03)
                {
                    var animController = anim.GetComponent<Animator>();

                    animController.SetBool("IsRunning", !animated);
                }
            }
            else if (value == 2)
            {
                foreach (var anim in _teamMembers_Rotator_01)
                {
                    var animController = anim.GetComponent<Animator>();

                    animController.SetBool("IsRunning", !animated);
                }
                foreach (var anim in _teamMembers_Rotator_02)
                {
                    var animController = anim.GetComponent<Animator>();

                    animController.SetBool("IsRunning", !animated);
                }
                foreach (var anim in _teamMembers_Rotator_03)
                {
                    var animController = anim.GetComponent<Animator>();

                    animController.SetBool("IsRunning", animated);
                }
            }         
        }
    }
}