using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using Zenject;

namespace TopDown.Input
{
    public class TopDownMouse : OnScreenControl
    {
        protected override string controlPathInternal { get => _controlPath; set => _controlPath = value; }

        [InputControl(layout = "Vector2")]
        [SerializeField] private string _controlPath;

        private Camera _camera;

        [Inject]
        public void Construct(Camera camera)
        {
            _camera = camera;
        }

        private void Update()
        {
            var aimTarget = GetMouseWorldPos();
            Vector2 aimDirection = (aimTarget - transform.position).normalized;

            SendValueToControl(aimDirection);
        }
        private Vector3 GetMouseWorldPos()
        {
            var mouse = Mouse.current;

            Vector3 mousePos = mouse.position.ReadValue();
            mousePos.z = transform.position.z;

            return _camera.ScreenToWorldPoint(mousePos);
        }
    }
}
