using UnityEngine;
using UnityEngine.SceneManagement;
using ZeroCombat.Constants;
using ZeroCombat.Data;
using ZeroCombat.Extensions;
using ZeroCombat.Infrastructure.Services;
using ZeroCombat.Services.Input;

namespace ZeroCombat.Player
{
    public class PlayerMove : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        
        private IInputService _inputService;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }
        
        private void Update()
        {
            var movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constant.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0f;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            _characterController.Move(movementVector * (_movementSpeed / 10 * Time.deltaTime));
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentScene() != progress.WorldData.PositionOnLevel.SceneName)
            {
                return;
            }
            
            Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
            Warp(savedPosition);
        }

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.AsUnityVector3().AddY(_characterController.height);
            _characterController.enabled = true;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentScene(), transform.position.AsVectorData());
        }
        
        private static string CurrentScene()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}