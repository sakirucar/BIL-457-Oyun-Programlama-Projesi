using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{
    [SerializeField] protected Movement movement;
    [SerializeField] protected Collector collector;
    [SerializeField] private Transform leavePos;
    [SerializeField] private Button leaveButton;
    [SerializeField] private CameraController cameraController;
    private GameObject player;
    protected bool avaliable = true;
    private void Start()
    {
        movement.enabled = false;
        collector.enabled = false;

    }

    public virtual void Leave()
    {
        movement.enabled = false;
        leaveButton.onClick.RemoveAllListeners();
        leaveButton.gameObject.SetActive(false);
        player.transform.position = new Vector3(leavePos.position.x, 0, leavePos.position.z);
        player.SetActive(true);
        cameraController.TargetTransform = player.transform;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && avaliable)
        {
            player = other.gameObject;
            leaveButton.onClick.RemoveAllListeners();
            leaveButton.onClick.AddListener(Leave);
            leaveButton.gameObject.SetActive(true);
            cameraController.TargetTransform = movement.transform;
            player.SetActive(false);
            movement.enabled = true;
            collector.enabled = true;
        }
    }



}
