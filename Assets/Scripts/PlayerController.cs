using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isMoving;
    private Vector3 touchPosition;
    [SerializeField]
    private float moveSpeed = 0.25f;
    private Transform player;
    private Camera _mainCamera;
    private float plaeyPositionZ;
    private float totalDistanceToMove;

    void Start()
    {
        player = GetComponent<Transform>();
        _mainCamera = Camera.main;
        plaeyPositionZ = player.transform.position.z;
    }

    //Пользовательский ввод
    private void Update()
    {
        if (Input.touchCount > 0 && isMoving==false)
        {
            Touch touch = Input.GetTouch(0);
            if (!IsPointerOverUI.IsPointerOverUIObject())
            {
                touchPosition = touch.position;
                isMoving = true;
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUI.IsPointerOverUIObject())
            {
                totalDistanceToMove = new Vector2(_mainCamera.ScreenToWorldPoint(touchPosition).x - player.transform.position.x, _mainCamera.ScreenToWorldPoint(touchPosition).y - player.transform.position.y).magnitude;
                touchPosition = Input.mousePosition;
                isMoving = true;
            }
        }

        if (totalDistanceToMove<=0)
            isMoving = false;
    }

    //Передвжение (можно отдельный класс для соблюдения принципов ООП)
    void FixedUpdate()
    {
        if (isMoving == true)
        {
            player.transform.position = Vector3.MoveTowards(new Vector3(player.transform.position.x, player.transform.position.y, plaeyPositionZ), _mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, plaeyPositionZ)), moveSpeed);
            totalDistanceToMove -= moveSpeed/2;
        }
    }
}