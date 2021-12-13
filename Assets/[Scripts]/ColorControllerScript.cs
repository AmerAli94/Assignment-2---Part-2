using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColorControllerScript : MonoBehaviour
{

    public Color platformColor;

    private List<SpriteRenderer> tileSpriteRenderers;
    // Start is called before the first frame update
    void Start()
    {
        tileSpriteRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();
        SetColor();
    }

    public void SetColor()
    {
        foreach(var renderer in tileSpriteRenderers)
        {
            renderer.material.SetColor("_Color", platformColor);
        }
    }

    public void SetColor(Color Color)
    {
        foreach (var renderer in tileSpriteRenderers)
        {
            renderer.material.SetColor("_Color", platformColor);
        }
    }
}
