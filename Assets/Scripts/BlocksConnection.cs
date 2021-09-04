using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlocksConnection : MonoBehaviour
{
    List<Block> ConnectedBlocks = new List<Block>();
    private LineRenderer LineRenderer;
    private Board Board;

    private void Awake()
    {
        LineRenderer = GetComponent<LineRenderer>();
        Board = GetComponent<Board>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            FinishConnection();

    }

    
    public void Connect(Block block)
    {
        if (!Input.GetMouseButton(0))
            return;
        if (ConnectedBlocks.Contains(block))
            return;
        block.IsConnected = true;
        ConnectedBlocks.Add(block);
        RefreshConnector();
    }
    private void FinishConnection()
    {
        ConnectedBlocks.ForEach(block => block.IsConnected = false);
        ConnectedBlocks.Clear();
        RefreshConnector();
        
    }
    private void RefreshConnector()
    {
        var points = ConnectedBlocks
            .Select(block => Board.GetBlockPosition(block.X, block.Y))
            .Select(pos => (Vector3)pos + Vector3.back * 2f)
            .ToArray();
        LineRenderer.positionCount = points.Length;
        LineRenderer.SetPositions(points);
    }
}
