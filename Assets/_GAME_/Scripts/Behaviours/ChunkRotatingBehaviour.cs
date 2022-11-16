using Cinemachine;
using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ChunkRotatingBehaviour : MonoBehaviour
{

    [SerializeField] private CinemachineSmoothPath _path;
    public float ChunkRotationSpeed= 10f;
    private float _positionOnPath =0f;
    [SerializeField] private bool _isAbleToMove = false;

    public void GetThePosition(float posOnPath)
    {
        _positionOnPath= posOnPath;
    }

   

    private void Update()
    {
        transform.position = _path.EvaluatePositionAtUnit(_positionOnPath, CinemachinePathBase.PositionUnits.Distance);
        transform.rotation = _path.EvaluateOrientationAtUnit(_positionOnPath, CinemachinePathBase.PositionUnits.Distance);

        if (_isAbleToMove)
        {
        _positionOnPath += ChunkRotationSpeed * Time.deltaTime;

        }

        if (_positionOnPath > _path.PathLength)
        {
            Destroy(gameObject);
        }
    }


}
