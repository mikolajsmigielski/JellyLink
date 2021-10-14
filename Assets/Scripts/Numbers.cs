using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TextDirection { Left, Middle, Right}
public class Numbers : MonoBehaviour
{
    [SerializeField]
    Sprite[] Sprites;

    [SerializeField]
    float GridSize = 1f;

    [SerializeField]
    TextDirection TextDirection;

    private int _value = 0;
    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;
            RefreshNumbers();
        }
    }
    List<GameObject> DigitsObjects = new List<GameObject>();
    void Start()
    {
        
    }
    
    
    void Update()
    {
        
    }
    private void RefreshNumbers()
    {
        RemoveDigits();
        
        var digits = Value
            .ToString()
            .Select(c => c.ToString())
            .ToArray();

        for (int i = 0; i < digits.Count(); i++)
        {
            var position = CalculatePosition(i,digits.Count());
            
            var digit = CreateDigit(position, int.Parse(digits[i]));
            DigitsObjects.Add(digit);
        }
    }

    private void RemoveDigits()
    {
        DigitsObjects.ForEach(number => Destroy(number));
        DigitsObjects.Clear();
    }

    private GameObject CreateDigit(Vector3 position, int value)
    {
        var digit = new GameObject();
        digit.transform.parent = transform;
        digit.transform.localPosition = position;

        var sprite = Sprites[value];
        digit.AddComponent<SpriteRenderer>().sprite = sprite;

        return digit;
    }

    private Vector3 CalculatePosition(int i, int NumbersOfDigits )
    {
        var result = 0f;
        if (TextDirection == TextDirection.Left)
        {
            result = i;
        }
        else if (TextDirection == TextDirection.Middle)
        {
            result = i - NumbersOfDigits / 2f + 0.5f; ;
        }
        else if (TextDirection == TextDirection.Right)
        {
            result = i - NumbersOfDigits + 1;
        }
        return Vector3.right * i * GridSize;
    }
}
