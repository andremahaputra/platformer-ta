using Cinemachine;
using UnityEngine;
using VContainer.Unity;

class CameraController : IStartable
{
    private CinemachineVirtualCamera vcam;

    public CameraController () {

    }

    public void SetVirtualCamera (CinemachineVirtualCamera cam) {
        this.vcam = cam;
    }

    public void SetTarget (Transform target) {
        if (vcam == null)  throw new System.Exception("Virtual camera is not yet set.");
        vcam.Follow = target;
    }   

    public void Start()
    {
        throw new System.NotImplementedException();
    }
}