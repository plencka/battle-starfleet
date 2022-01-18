using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintMaterial : AttachableComponentBase<TintMaterial>, IColorable
{
    private int tintMaterialColorId = 0; 
    private Material _material;
    private Color _color;

    void Start()
    {
        tintMaterialColorId = Shader.PropertyToID("_tintColor");
        _material = GetComponent<Renderer>().material;
        RefreshMaterialColor();
    }

    public Color GetColor()
    {
        return _color;
    }

    public void SetColor(Color newColor)
    {
        _color = newColor;
    }

    void RefreshMaterialColor()
    {
        _material.SetColor(tintMaterialColorId, GetColor());
    }
}
