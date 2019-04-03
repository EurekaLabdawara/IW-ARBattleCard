using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

namespace IMedia9
{

    public class AnimaARVirtualButton : MonoBehaviour, IVirtualButtonEventHandler
    {

        public enum CCompareType { Greater, Equal, Less }
        public enum CParameterType { Int, Float, Bool, Trigger }

        public bool isEnabled;
        public Animator TargetAnimator;

        [System.Serializable]
        public class CAnimationState3D
        {
            public string StateNow;
            public string StateNext;
            public CParameterType ParameterType;
            public string ParameterName;
            public string PositiveValue;
            public string NegativeValue;
            public VirtualButtonBehaviour TriggerVirtualButton;
            [HideInInspector]
            public bool isButtonPressed;
        }

        bool isCooldown = false;

        public CAnimationState3D[] AnimationState3D;

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < AnimationState3D.Length; i++)
            {
                AnimationState3D[i].TriggerVirtualButton.RegisterEventHandler(this);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                for (int i = 0; i < AnimationState3D.Length; i++)
                {
                    if (AnimationState3D[i].isButtonPressed && !isCooldown)
                    {
                        isCooldown = true;
                        Invoke("Cooldown", 1);

                        if (AnimationState3D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState3D[i].PositiveValue);
                            TargetAnimator.SetFloat(AnimationState3D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Trigger)
                        {
                            TargetAnimator.SetTrigger(AnimationState3D[i].ParameterName);
                        }
                    }
                }
            }
        }

        void LateUpdate()
        {
            if (isEnabled)
            {
                for (int i = 0; i < AnimationState3D.Length; i++)
                {
                    if (!AnimationState3D[i].isButtonPressed)
                    {
                        if (AnimationState3D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState3D[i].NegativeValue);
                            TargetAnimator.SetFloat(AnimationState3D[i].ParameterName, dummyvalue);
                        }
                    }
                }
            }
        }

        void Shutdown(bool aValue)
        {
            isEnabled = false;
        }

        public void OnButtonPressed(VirtualButtonBehaviour vb)
        {
            for (int i = 0; i < AnimationState3D.Length; i++)
            {
                if (vb.name == AnimationState3D[i].TriggerVirtualButton.name)
                {
                    AnimationState3D[i].isButtonPressed = true;
                    Debug.Log(vb.name + ": Pressed");
                }
            }
        }

        public void OnButtonReleased(VirtualButtonBehaviour vb)
        {
            for (int i = 0; i < AnimationState3D.Length; i++)
            {
                if (vb.name == AnimationState3D[i].TriggerVirtualButton.name)
                {
                    AnimationState3D[i].isButtonPressed = false;
                    Debug.Log(vb.name + ": Released");
                }
            }
        }

        void Cooldown()
        {
            isCooldown = false;
        }

    }

}