using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 grapplePoint;
    public LayerMask grappable;
    public Transform hookPoint, camera,player;
    public float maxDistance;
    private SpringJoint joint;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }
    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position,direction: camera.forward,out hit, maxDistance))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(a: player.position, b: grapplePoint);
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 1.5f;

            line.positionCount = 2;
        }
        
    }

    void DrawRope()
    {
        if (!joint) return;

        line.SetPosition(index: 1, grapplePoint);
        line.SetPosition(index: 0, hookPoint.position);
    }

    void StopGrapple()
    {
        line.positionCount = 0;
        Destroy(joint);
    }

}
