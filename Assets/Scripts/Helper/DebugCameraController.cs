using UnityEngine;

/// <summary>
/// WASDで上下左右、マウスホイールで前後、マウスドラッグで回転
/// マウス移動でダミーコントローラーを回転
/// </summary>
public class DebugCameraController : MonoBehaviour
{
    float _camMoveSpeed = 0.2f;
    float _camRotationSpeed = 0.1f;
    Vector2 _camAngle = Vector2.zero;
    Vector2 _lastMousePosition;

    void Update()
    {
        // カメラ移動
        var h = Input.GetAxis("Horizontal") * _camMoveSpeed;
        var v = Input.GetAxis("Vertical") * _camMoveSpeed;
        var z = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(h, v, z);

        // マウスドラッグでカメラ回転
        if (Input.GetMouseButtonDown(1))
        {
            _camAngle = transform.localEulerAngles;
            _lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            _camAngle.y += (Input.mousePosition.x - _lastMousePosition.x) * _camRotationSpeed;
            _camAngle.x += (_lastMousePosition.y - Input.mousePosition.y) * _camRotationSpeed;
            _lastMousePosition = Input.mousePosition;
            transform.localEulerAngles = _camAngle;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 400, 100), "カメラ移動 : WSDA + 右クリックドラッグ\nNavMesh誘導 : 左クリック");
    }
}
