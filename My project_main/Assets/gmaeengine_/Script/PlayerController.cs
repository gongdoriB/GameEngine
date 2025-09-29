using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private float baseSpeed;
    
    private Animator animator;
    private bool isRunning = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        baseSpeed = moveSpeed;

        if (animator != null)
            Debug.Log("Animator 컴포넌트를 찾았습니다!");
        else
            Debug.LogError("Animator 컴포넌트가 없습니다!");
    }

    void Update()
    {
        // === Shift 달리기 ===
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = baseSpeed * 2f;
            isRunning = true;
            Debug.Log("달리기 모드!");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = baseSpeed;
            isRunning = false;
        }

        // === 이동 ===
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (movement != Vector3.zero)
            transform.Translate(movement * moveSpeed * Time.deltaTime);

        float currentSpeed = movement != Vector3.zero ? moveSpeed : 0f;

        // === 점프 입력 ===
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            Debug.Log("점프!");
        }

        // === 애니메이션 파라미터 전달 ===
        if (animator != null)
        {
            animator.SetFloat("Speed", currentSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
{
        if (animator != null)
        {
            animator.SetBool("Jump", true);
            Debug.Log("점프!");
        }
}
    }

    // Jump 애니메이션 끝나면 Idle/Run으로 복귀
    // 애니메이션 이벤트(Animation Event)에서 호출

}
