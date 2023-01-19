using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yatch : Vehicle
{
    [SerializeField] private StashDischarger discharger;
    private Vector3 startPos;
    private Quaternion startRot;
    private void Start()
    {
        movement.enabled = false;
        collector.enabled = false;
        startPos = discharger.transform.position;
        startRot = discharger.transform.rotation;
    }
    public override void Leave()
    {
        avaliable = false;
        DOVirtual.DelayedCall(.6f, () => 
        {
            discharger.Discharge();
            avaliable = true;
            base.Leave();
        });
        discharger.transform.DOMove(startPos, .5f);
        discharger.transform.DORotateQuaternion(startRot, .35f);
        
    }

}
