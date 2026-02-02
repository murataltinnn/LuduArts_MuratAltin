using UnityEngine;

namespace MuratAltin.Runtime.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        #region Fields
        [Header("Movement Settings")]
        [SerializeField] private float m_MoveSpeed = 5f;
        [SerializeField] private float m_MouseSensitivity = 2f;

        private CharacterController m_Controller;
        private float m_XRotation = 0f;
        #endregion

        private void Awake()
        {
            m_Controller = GetComponent<CharacterController>();
            
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            HandleRotation();
            HandleMovement();
        }

        private void HandleRotation()
        {
            float mouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity;

            m_XRotation -= mouseY;
            m_XRotation = Mathf.Clamp(m_XRotation, -90f, 90f);

            Camera.main.transform.localRotation = Quaternion.Euler(m_XRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        private void HandleMovement()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            m_Controller.Move(move * m_MoveSpeed * Time.deltaTime);
        }
    }
}