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
    public Material AimMarkerMaterial;  //変化させるマーカーのマテ
    public Texture Pointer_Hit;
    public Texture Pointer_Out;
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
                    Debug.Log("クリックした！");
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
            //aimMarkerGm.SetActive(false);
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == "LaserArea")
        {
            Debug.Log("エリアに当たっている");

            AimMarkerMaterial.SetTexture("_MainTex", Pointer_Hit);
            AimMarkerMaterial.SetTexture("_EmissionMap", Pointer_Hit);
            AimMarkerMaterial.color = new Color32(0, 100, 100,255);

            Color AimMakerEmissionColor = new Color32(0, 96, 191,255);
            AimMarkerMaterial.SetColor("_EmissionColor",AimMakerEmissionColor);

            rayarea = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "LaserArea")
        {
            Debug.Log("エリアを外れた");

            AimMarkerMaterial.SetTexture("_MainTex", Pointer_Out);
            AimMarkerMaterial.SetTexture("_EmissionMap", Pointer_Out);
            AimMarkerMaterial.color = new Color32(200, 30, 30,255);

            Color AimOutEmissionColor = new Color32(191, 10, 20,255);
            AimMarkerMaterial.SetColor("_EmissionColor", AimOutEmissionColor);

            rayarea = false;
        }
    }

}
