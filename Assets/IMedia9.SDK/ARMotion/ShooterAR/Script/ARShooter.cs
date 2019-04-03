using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

namespace IMedia9
{

    public class ARShooter : MonoBehaviour, IVirtualButtonEventHandler
    {

        [System.Serializable]
        public class CTriggerVirtualButton
        {
            public string Name;
            public VirtualButtonBehaviour VirtualBtn;
            [HideInInspector]
            public bool isButtonPressed;
        }

        public bool isEnabled;
        public GameObject Bullet3D;
        public GameObject BulletPosition3D;
        public GameObject ImageTargetParent;
        public int DestroyDelay = 5;
        public CTriggerVirtualButton[] TriggerVirtualButton;

        bool isCooldown = false;

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < TriggerVirtualButton.Length; i++)
            {
                TriggerVirtualButton[i].VirtualBtn.RegisterEventHandler(this);
            }
        }

        void Update()
        {
        }

        public void OnButtonPressed(VirtualButtonBehaviour vb)
        {
            if (isEnabled)
            {
                for (int i = 0; i < TriggerVirtualButton.Length; i++)
                {
                    if (vb.name == TriggerVirtualButton[i].VirtualBtn.name && !isCooldown)
                    {
                        TriggerVirtualButton[i].isButtonPressed = true;
                        isCooldown = true;
                        Invoke("Cooldown", 1);
    
                        GameObject temp = GameObject.Instantiate(Bullet3D, BulletPosition3D.transform.position, BulletPosition3D.transform.rotation, ImageTargetParent.transform);
                        Destroy(temp.gameObject, DestroyDelay);
    
                        Debug.Log(vb.name + ": Pressed");
                    }
                }
            }
        }

        public void OnButtonReleased(VirtualButtonBehaviour vb)
        {
            for (int i = 0; i < TriggerVirtualButton.Length; i++)
            {
                if (vb.name == TriggerVirtualButton[i].VirtualBtn.name)
                {
                    TriggerVirtualButton[i].isButtonPressed = false;
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