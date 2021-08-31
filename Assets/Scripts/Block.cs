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
    public BlockColor Color { get; private set; }
    void Start()
    {
        Color = GetRandomColor();
        SetSprite();
    }

    
    void Update()
    {
        
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
}
