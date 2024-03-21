using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsBubble : MonoBehaviour
{
    public TextMeshPro textMesh;

    public void Init(int value)
    {
        textMesh.text = $"+{value}";
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
