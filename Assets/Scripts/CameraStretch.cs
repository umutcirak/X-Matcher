using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStretch : MonoBehaviour
{   
    
    Camera mainCamera;
    Board board;


    void Awake()
    {
        mainCamera = Camera.main;
        board = FindObjectOfType<Board>();

    }

    void Start()
    {
        StretchCamera();
    }   
    

    void StretchCamera()
    {
        // posIndex = (Grid Size - 1) * 0.5
        float size = board.gridSize * 0.55f;
        float posIndex = (board.gridSize - 1) * 0.5f;

        float shiftLeft = board.gridSize / 2.5f;

        Vector3 pos = new Vector3(posIndex - shiftLeft, posIndex, -1f);

        mainCamera.transform.position = pos;

        mainCamera.orthographicSize = size;    
                
    }



}
