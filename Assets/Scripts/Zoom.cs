using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Zoom : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector3 dragOrigin;
    [SerializeField] private float zoomStep, minCamSize, maxCamSize;
    [SerializeField] private SpriteRenderer mapRenderer;

    private float mapMinx, mapMaxX, mapMinY, mapMaxY;
    public bool is1920;

    public TextMeshProUGUI textTesting, maxSize;

    private void Awake()
    {
        CalculateMapBounds();
        CalculateMaxZoomSize();
    }

    private void CalculateMapBounds()
    {
        mapMinx = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;
        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }

    private void CalculateMaxZoomSize()
    {
        float mapWidth = mapRenderer.bounds.size.x;
        float mapHeight = mapRenderer.bounds.size.y;
        float screenAspect = Settings.width / (float)Settings.height;
        float mapAspect = mapWidth / mapHeight;

        if (screenAspect >= mapAspect)
        {
            maxCamSize = mapHeight / 2f;
        }
        else
        {
            float targetWidth = mapHeight * screenAspect;
            maxCamSize = targetWidth / (2f * cam.aspect);
        }
    }

    private void Update()
    {
        if (Settings.isInSettings == false && Settings.isInMainMenu == false)
        {
            PanCamera();

            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                ZoomIn();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
            {
                ZoomOut();
            }
        }

        if (Settings.changeRes == true)
        {
            cam.transform.position = new Vector3(0, -18, -10f);
            cam.orthographicSize = 14f;

            StartCoroutine(wait());
            Settings.changeRes = false;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        CalculateMapBounds();
        CalculateMaxZoomSize();
        //maxSize.text = "" + maxCamSize;
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }
    }

    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize); // Use a small minimum zoom size

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, 0.1f, maxCamSize); // Use a small minimum zoom size

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinx + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
