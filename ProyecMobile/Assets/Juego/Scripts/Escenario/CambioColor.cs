using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioColor : MonoBehaviour
{
    public Renderer _renderer;

    public void CambiarColor(Color color)
    {
        _renderer.sharedMaterial.SetColor("_Color", color);
    }
}
