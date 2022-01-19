using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerData
{
    private Area area;
    private Range zoom;

    public CameraControllerData(float areaX, float areaY, float inner, float outer)
    {
        area = new Area(areaX, areaY);
        zoom = new Range(inner, outer);
    }

    public Area GetArea()
    {
        return area;
    }

    public Range GetZoom()
    {
        return zoom;
    }
}
