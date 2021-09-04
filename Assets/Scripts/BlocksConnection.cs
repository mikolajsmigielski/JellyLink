using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksConnection : MonoBehaviour
{
    List<Block> ConnectedBlocks = new List<Block>();
    bool IsConnecting = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void StartConnection(Block block)
    {
        IsConnecting = true;
    }
    public void Connect(Block block)
    {
        if (IsConnecting == false)
            return;
        if (ConnectedBlocks.Contains(block))
            return;
        block.IsConnected = true;
        ConnectedBlocks.Add(block);
    }
    public void FinishConnection()
    {
        ConnectedBlocks.ForEach(block => block.IsConnected = false);
        ConnectedBlocks.Clear();
        IsConnecting = false;
    }
}
