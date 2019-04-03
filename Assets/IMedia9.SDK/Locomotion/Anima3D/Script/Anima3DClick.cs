using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Anima3DClick : MonoBehaviour
    {

        public enum CCompareType { Greater, Equal, Less }
        public enum CParameterType { Int, Float, Bool, Trigger }

        public bool isEnabled;
        public Animator TargetAnimator;
        public Mechanim3DClick TargetMechanimClick;
        bool isMoving;

        [System.Serializable]
        public class CAnimationState3D
        {
            public string StateNow;
            public string StateNext;
            public CParameterType ParameterType;
            public string ParameterName;
            public string PositiveValue;
            public string NegativeValue;
            public KeyCode TriggerKey;
        }

        public CAnimationState3D[] AnimationState3D;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                isMoving = TargetMechanimClick.GetIsMoving();

                for (int i = 0; i < AnimationState3D.Length; i++)
                {
                    if (Input.GetKey(AnimationState3D[i].TriggerKey))
                    {
                        isMoving = TargetMechanimClick.GetIsMoving();
                    }

                    if (isMoving)
                    {
                        if (AnimationState3D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState3D[i].PositiveValue);
                            TargetAnimator.SetFloat(AnimationState3D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AnimationState3D[i].PositiveValue);
                            TargetAnimator.SetInteger(AnimationState3D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AnimationState3D[i].PositiveValue);
                            TargetAnimator.SetBool(AnimationState3D[i].ParameterName, dummyvalue);
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
                    if (!isMoving)
                    {
                        if (AnimationState3D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState3D[i].NegativeValue);
                            TargetAnimator.SetFloat(AnimationState3D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AnimationState3D[i].NegativeValue);
                            TargetAnimator.SetInteger(AnimationState3D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AnimationState3D[i].NegativeValue);
                            TargetAnimator.SetBool(AnimationState3D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Trigger)
                        {
                            TargetAnimator.SetTrigger(AnimationState3D[i].ParameterName);
                        }

                    }
                }
            }
        }

        public void ForceStopAnima()
        {
            isMoving = false;
            for (int i = 0; i < AnimationState3D.Length; i++)
            {
                    if (AnimationState3D[i].ParameterType == CParameterType.Float)
                    {
                        float dummyvalue = float.Parse(AnimationState3D[i].NegativeValue);
                        TargetAnimator.SetFloat(AnimationState3D[i].ParameterName, dummyvalue);
                    }
                    if (AnimationState3D[i].ParameterType == CParameterType.Int)
                    {
                        int dummyvalue = int.Parse(AnimationState3D[i].NegativeValue);
                        TargetAnimator.SetInteger(AnimationState3D[i].ParameterName, dummyvalue);
                    }
                    if (AnimationState3D[i].ParameterType == CParameterType.Bool)
                    {
                        bool dummyvalue = bool.Parse(AnimationState3D[i].NegativeValue);
                        TargetAnimator.SetBool(AnimationState3D[i].ParameterName, dummyvalue);
                    }
            }
        }

        void Shutdown(bool aValue)
        {
            isEnabled = false;
        }

    }

}