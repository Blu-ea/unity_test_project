using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class scroolZoom : MonoBehaviour
{
    public float zoomMax = 16f;
    public float zoomMin = 2f;
    public  float zoomInnitial = 4f;

    private float _zoom;
    private Camera _mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = Camera.main;
        _zoom = zoomInnitial;
        _mainCamera.orthographicSize = _zoom;
    }

    // Update is called once per frame
    void Update()
    {
        _zoom -= Input.mouseScrollDelta.y;
        _zoom = Mathf.Clamp(_zoom, zoomMin, zoomMax);
        _mainCamera.orthographicSize = _zoom;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _zoom);
    }
}
