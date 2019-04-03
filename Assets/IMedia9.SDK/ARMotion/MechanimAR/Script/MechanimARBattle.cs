using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class MechanimARBattle : MonoBehaviour
    {

        public MechanimAREventHandler[] MarkerPlayer;
        public MechanimAREventHandler[] MarkerEnemy;
        int idxActivePlayer = 0;
        int idxActiveEnemy = 0;
        bool playerActive = false;
        bool enemyActive = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            for (int i=0; i<MarkerPlayer.Length; i++)
            {
                if (MarkerPlayer[i].ARState3D.isActive)
                {
                    idxActivePlayer = i;
                    playerActive = true;
                }
            }
            for (int i = 0; i < MarkerEnemy.Length; i++)
            {
                if (MarkerEnemy[i].ARState3D.isActive)
                {
                    idxActiveEnemy = i;
                    enemyActive = true;
                }
            }

            if (enemyActive && playerActive)
            {
                Vector3 tempPlayer = MarkerPlayer[idxActivePlayer].ARState3D.TargetObject.transform.position;
                MarkerPlayer[idxActivePlayer].ARState3D.TargetObject.transform.LookAt(
                    new Vector3(MarkerEnemy[idxActiveEnemy].ARState3D.TargetObject.transform.position.x,
                                tempPlayer.y,
                                MarkerEnemy[idxActiveEnemy].ARState3D.TargetObject.transform.position.z)
                    );

                Vector3 tempEnemy = MarkerEnemy[idxActiveEnemy].ARState3D.TargetObject.transform.position;
                MarkerEnemy[idxActiveEnemy].ARState3D.TargetObject.transform.LookAt(
                    new Vector3(MarkerPlayer[idxActivePlayer].ARState3D.TargetObject.transform.position.x,
                                tempPlayer.y,
                                MarkerPlayer[idxActivePlayer].ARState3D.TargetObject.transform.position.z)
                    );
            }
        }
    }
}
