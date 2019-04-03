using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class AnimaARShutdown : MonoBehaviour
    {

        public enum CCompareType { Greater, Equal, Less }
        public enum CParameterType { Int, Float, Bool, Trigger }

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
        }

        public CAnimationState3D AnimationState3D;

        void Shutdown(bool aValue)
        {
            if (AnimationState3D.ParameterType == CParameterType.Float)
            {
                float dummyvalue = float.Parse(AnimationState3D.PositiveValue);
                TargetAnimator.SetFloat(AnimationState3D.ParameterName, dummyvalue);
            }
            if (AnimationState3D.ParameterType == CParameterType.Int)
            {
                int dummyvalue = int.Parse(AnimationState3D.PositiveValue);
                TargetAnimator.SetInteger(AnimationState3D.ParameterName, dummyvalue);
            }
            if (AnimationState3D.ParameterType == CParameterType.Bool)
            {
                bool dummyvalue = bool.Parse(AnimationState3D.PositiveValue);
                TargetAnimator.SetBool(AnimationState3D.ParameterName, dummyvalue);
            }
            if (AnimationState3D.ParameterType == CParameterType.Trigger)
            {
                TargetAnimator.SetTrigger(AnimationState3D.ParameterName);
            }
            
        }
    }

}