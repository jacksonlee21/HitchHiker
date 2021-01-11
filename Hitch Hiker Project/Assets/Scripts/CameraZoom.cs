using UnityEngine;

public static class CameraZoom
{
    public static void ZoomIn(float zoomLevel)
    {
        Camera.main.orthographicSize = zoomLevel;
        Debug.Log("1");
    }
    public static void ZoomIn()
    {
        Camera.main.orthographicSize = 2.5f;
        Debug.Log("2");
    }

    public static void ZoomOut(float zoomLevel)
    {
        Camera.main.orthographicSize = zoomLevel;
        Debug.Log("3");
    }

    public static void ZoomOut()
    {
        Camera.main.orthographicSize = 3.5f;
        Debug.Log("4");
    }
}
