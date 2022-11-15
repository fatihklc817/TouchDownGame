using Cinemachine;
using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ChunkRotatingBehaviour : MonoBehaviour
{

    [SerializeField] private CinemachineSmoothPath _path;
    [SerializeField] private float _speed=2f;
    private float _positionOnPath =0;

   

    private void Update()
    {
        _positionOnPath += _speed * Time.deltaTime;
        transform.position = _path.EvaluatePositionAtUnit(_positionOnPath, CinemachinePathBase.PositionUnits.Distance);
        transform.rotation = _path.EvaluateOrientationAtUnit(_positionOnPath, CinemachinePathBase.PositionUnits.Distance);

        if (_positionOnPath > _path.PathLength)
        {
            Destroy(gameObject);
        }
    }


}
