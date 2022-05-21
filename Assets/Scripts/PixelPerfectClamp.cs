using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectClamp
{
    public Vector2 Clamp(Vector2 moveVector, float pixelsPerUnit)
    {
        Vector2 vectorInPixels = new Vector2(
            Mathf.RoundToInt(moveVector.x * pixelsPerUnit),
            Mathf.RoundToInt(moveVector.y * pixelsPerUnit)
        );

        // Debug.Log("Clamp X: " + vectorInPixels.x + " into " + vectorInPixels.x / pixelsPerUnit);
        // Debug.Log("Clamp Y: " + vectorInPixels.y + " into " + vectorInPixels.y / pixelsPerUnit);

        return vectorInPixels / pixelsPerUnit;
    }
}
