using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerData
{
    public Area area;
    public Range zoom;

    public CameraControllerData(float areaX, float areaY, float inner, float outer)
    {
        area = new Area(areaX, areaY);
        zoom = new Range(inner, outer);
    }
}
