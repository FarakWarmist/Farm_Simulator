using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _distance; // La distance entre la camera et le palyer

    private void Start()
    {
        if ( _playerTransform != null)
        {
            _distance = transform.position - _playerTransform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerTransform != null)
        {
           transform.position = _playerTransform.position + _distance;
        }
    }
}
