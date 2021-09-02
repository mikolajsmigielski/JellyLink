using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum BlockColor { Red, Green, Blue, Yellow, Purple, White}

[System.Serializable]
class BlockType
{
    public BlockColor Color;
    public Sprite Sprite;

}

public class Block : MonoBehaviour
{
    [SerializeField]
    BlockType[] BlockTypes;

    private Board Board;
    public int X { get; private set; }
    public int Y { get; private set; }

    public BlockColor Color { get; private set; }
    private Vector3 TargetPosition;

    private void Awake()
    {
        Board = FindObjectOfType<Board>();
    }
    void Start()
    {
        
        Color = GetRandomColor();
        SetSprite();
    }

    

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, TargetPosition, Time.deltaTime * 5f);
    }
    public static BlockColor GetRandomColor()
    {
        var values = System.Enum.GetValues(typeof(BlockColor));
        var index = Random.Range(0, values.Length);
        return (BlockColor)values.GetValue(index);
    }
    private void SetSprite()
    {
        var sprite = BlockTypes.First(type => type.Color == Color).Sprite;
        GetComponent<SpriteRenderer>().sprite = sprite;

    }
    public void Configure(int x, int y)
    {
        X = x;
        Y = y;
        TargetPosition = Board.GetBlockPosition(x, y);
    }
}
