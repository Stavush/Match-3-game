using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDesign : MonoBehaviour
{
    public enum DesignType
    {
        BLUE,
        CHOCOLATE,
        GREEN,
        ORANGE,
        PINK,
        PURPLE,
        RED,
        ANY,
        COUNT
    }

    [System.Serializable]
    public struct DesignSprite
    {
        public DesignType design;
        public Sprite sprite;
    }

    private SpriteRenderer sprite;
    public DesignSprite[] designSprites;
    private Dictionary<DesignType, Sprite> designSpriteDict;

    private DesignType design;

    public DesignType Design
    {
        get { return design; }
        set { SetDesign(value); }
    }

    public int DesignSpritesAmount
    {
        get { return designSprites.Length; }
    }

    private void Awake()
    {
        sprite = transform.Find("tileImg").GetComponent<SpriteRenderer>();
        designSpriteDict = new Dictionary<DesignType, Sprite>();

        for(int i = 0; i < designSprites.Length; i++)
        {
            if (!designSpriteDict.ContainsKey(designSprites[i].design))
            {
                designSpriteDict.Add(designSprites[i].design, designSprites[i].sprite);
                
            }
        }
    }

    public void SetDesign(DesignType newDesign)
    {
        design = newDesign;
        if (designSpriteDict.ContainsKey(newDesign))
        {
            sprite.sprite = designSpriteDict[newDesign];
        }
    }
}
