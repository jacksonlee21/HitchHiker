using UnityEngine;

public static class CameraZoom
{
    public static void ZoomIn(float zoomLevel)
    {
        Camera.main.orthographicSize = zoomLevel;

    }
    public static void ZoomIn()
    {
        Camera.main.orthographicSize = 2.5f;

    }

    public static void ZoomOut(float zoomLevel)
    {
        Camera.main.orthographicSize = zoomLevel;

    }

    public static void ZoomOut()
    {
        Camera.main.orthographicSize = 3.5f;

    }
}