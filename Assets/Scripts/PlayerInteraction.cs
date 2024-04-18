using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
    public void Hover();
}

public class PlayerInteraction : MonoBehaviour
{
    private Camera cam;
    [SerializeField] float detectDistance = 4;
    private RaycastHit hit;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Detect();
    }


    private void Detect()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, detectDistance)){
            //WHERE ALL THE DETECTION LOGIC SHOULD GO
            if(hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Hover();
                if(Input.GetKeyDown(KeyCode.E) )
                {
                    interactObj.Interact();
                }
            }
        }
        else
        {
            UIManager.Instance.InteractTextOff();
        }
    }
}
