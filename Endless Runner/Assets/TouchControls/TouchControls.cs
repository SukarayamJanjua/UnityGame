
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class TouchControls : MonoBehaviourSingleton<TouchControls>
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;

    public delegate void EndTouch (Vector2 position, float time);
    public event StartTouch OnEndTouch;
    #endregion

    private InputMaster inputMaster;

    private Camera mainCamera;
    private void Awake()
    {
        inputMaster = new InputMaster();
        mainCamera = Camera.main;
    }
    
    private void OnEnable()
    {
        inputMaster.Enable();
    }
    private void OnDisable()
    {
        inputMaster.Disable();
    }

    void Start()
    {
        inputMaster.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        inputMaster.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }
    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(mainCamera,inputMaster.Touch.PrimaryPosition.ReadValue<Vector2>()),(float)context.startTime);
       
    }
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(Utils.ScreenToWorld(mainCamera, inputMaster.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }
    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCamera, inputMaster.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}

