using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _grapplingHook;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform hookShootPoint;
    [SerializeField] private Transform _handPos;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private LayerMask _grappleLayer;
    [SerializeField] private float _maxGrappleDistance;
    [SerializeField] private float _hookSpeed;
    [SerializeField] private Vector3 _offset;
    private bool isShooting, isGrappling;
    private Vector3 _hookPoint;



    private void Start()
    {
        isShooting = false;
        isGrappling = false;
        _lineRenderer.enabled = false;
    }
    // Update is called once per frame
    private void Update()
    {

        if(_grapplingHook.parent == _handPos)
        {
            _grapplingHook.localPosition = new Vector3(0.66f,-0.27f,1.3f);
            _grapplingHook.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetMouseButtonDown(0))
        {
            ShootHook();
        }
        if (isGrappling)
        {
            _grapplingHook.position = Vector3.Lerp(_grapplingHook.position, _hookPoint, _hookSpeed * Time.deltaTime);
            if (Vector3.Distance(_grapplingHook.position, _hookPoint) < 0.5f)
            {
                _controller.enabled = false;
                _playerBody.position = Vector3.Lerp(_playerBody.position, _hookPoint - _offset, _hookSpeed * Time.deltaTime);
                if (Vector3.Distance(_playerBody.position, _hookPoint - _offset) < 0.5f)
                {
                    _controller.enabled = true;
                    isGrappling = false;
                    _grapplingHook.SetParent(_handPos);
                    _lineRenderer.enabled = false;

                }
            }

        }
    }
    private void LateUpdate()
    {
        if (_lineRenderer.enabled)
        {
            _lineRenderer.SetPosition(0, hookShootPoint.position);
            _lineRenderer.SetPosition(1,_handPos.position);
        }
    }

    private void ShootHook()
    {
        if (isShooting || isGrappling) return;
        isShooting = true;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit, _maxGrappleDistance, _grappleLayer))
        {
            _hookPoint = hit.point;
            isGrappling = true;
            _grapplingHook.parent = null;
            _grapplingHook.LookAt(_hookPoint);
            _lineRenderer.enabled = true;
        }




        isShooting = false;


    }
}
