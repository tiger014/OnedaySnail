using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// レイを照射、ボタン操作で NavMeshAgent を誘導
/// Use Mouse オンでマウスカーソル追従式
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class GuidePointer : MonoBehaviour
{
    public float laserDistance = 100f;
    public LineRenderer lineRenderer;
    public Transform aimMarker;
    public GameObject aimMarkerGm;
    public NavMeshAgent navMeshAgent;
    public bool useMouse;
    public bool rayarea;

    [HideInInspector, SerializeField] int _rayTargetLayer = 0;
    int _rayMaskLayer;
    Camera _editorCamera;

    void Start()
    {
        lineRenderer.useWorldSpace = true;
        _rayMaskLayer = 1 << _rayTargetLayer;
        if (useMouse)
        {
            _editorCamera = GetComponentInParent<Camera>();
        }
    }

    void Update()
    {
        var rayStart = transform.position;
        var rayEnd = rayStart + transform.forward * laserDistance;
        var aimAngle = Quaternion.identity;
        Ray ray;

        if (useMouse)
        {
            ray = _editorCamera.ScreenPointToRay(Input.mousePosition);
        }
        else
        {
            ray = new Ray(rayStart, transform.forward);
        }

        if (Physics.Raycast(ray, out RaycastHit hit, laserDistance, _rayMaskLayer))
        {
            rayEnd = hit.point;
            aimAngle = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }

        aimMarker.position = rayEnd - (transform.forward * 0.05f);
        aimMarker.rotation = aimAngle;
        lineRenderer.SetPosition(0, rayStart);
        lineRenderer.SetPosition(1, rayEnd);

        if (rayarea)
        {
            aimMarkerGm.SetActive(true);

            if (useMouse)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    navMeshAgent.destination = rayEnd;
                }
            }
            else
            {
                if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                {
                    navMeshAgent.destination = rayEnd;
                }
            }
        }
        else
        {
            aimMarkerGm.SetActive(false);
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == "LaserArea")
        {
            Debug.Log("エリアに当たっている");

            rayarea = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "LaserArea")
        {
            Debug.Log("エリアを外れた");

            rayarea = false;
        }
    }

}
