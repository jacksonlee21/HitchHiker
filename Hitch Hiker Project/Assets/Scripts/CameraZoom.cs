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

    public static void Center(Transform player, float x)
    {
        float calcX = Mathf.Abs((player.position.x - x)/2);
        Debug.Log(calcX);
        Camera.main.transform.position -= new Vector3(calcX, 0, 0); 
    }
    public static void ResetCamera()
    {
        Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, -5); 
    }
}