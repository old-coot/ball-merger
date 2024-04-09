using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _sencetivity = 25f;
    [SerializeField] private float _maxPosition = 2.5f;

    private float _xPosition;
    private float _oldInputX;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldInputX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            float delta = Input.mousePosition.x - _oldInputX;
            _oldInputX = Input.mousePosition.x;
            _xPosition += delta * _sencetivity / Screen.width;
            _xPosition = Mathf.Clamp(_xPosition, -_maxPosition, _maxPosition);
            transform.position = new Vector3(_xPosition, transform.position.y, transform.position.z);
        }

    }
}
