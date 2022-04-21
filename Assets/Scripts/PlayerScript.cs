using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Color = UnityEngine.Color;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = 7.0f;     //최초 움직이는 속도
    private Vector3 _moveDirection = Vector3.zero;      //진행 방향
    private SpriteRenderer _spriteRenderer;     //색, 크기를 바꾸기 위한 SpriteRenderer 객체
    private bool isBoost;       //부스터를 사용하고 있는지
    
    public MeterScript boostMeter;      //부스터 게이지 세팅 스크립트 객체
    public float currentBoost;      //현재의 부스터량
    public float maxBoost = 80f;        //최대 부스터량
    public static double Score_count=0;     //스코어
    void Start()        //SpriteRenderer 객체 할당 및 부스터 세팅
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        currentBoost = maxBoost;
        boostMeter.SetMaxBoost(maxBoost);
    }

    private void OnTriggerEnter2D(Collider2D col)       //충돌 함수
    {
        if (transform.localScale.x * 1.1f > col.transform.localScale.x)     //슬라임이 더 클 때
        {
            transform.localScale += col.transform.localScale * 0.15f;       //성장
            if (moveSpeed > 2f)     //슬라임의 속도 저하(최소 2)
                moveSpeed -= col.transform.localScale.x * 3;
            
            Score_count+= col.transform.localScale.x * 100;     //점수 추가
        }
        else
        {
            transform.localScale -= col.transform.localScale * 0.3f;
            if (moveSpeed < 8)
                moveSpeed += col.transform.localScale.x * 3;
            
            Score_count-= col.transform.localScale.x * 100;     //점수 감소
        }

        GameDirector.Count--;       //현재 물고기 객체 수 --
        Destroy(col.GameObject());      //물고기 객체 제거
    }
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //position을 카메라의 뷰포트로
        viewPos.x = Mathf.Clamp01(viewPos.x);   //x, y의 값을 카메라 안으로 클램핑
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //뷰포트를 position으로
        transform.position = worldPos; //적용

        if (Input.GetKeyDown(KeyCode.LeftArrow))    //해당 키를 누르면 슬라임의 방향이 바뀐다
            _spriteRenderer.flipX = true;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            _spriteRenderer.flipX = false;

        if (Input.GetKeyDown(KeyCode.Space))        //스페이스바를 누르는 동안은 부스터 사용
            isBoost = true;
        
        if(Input.GetKeyUp(KeyCode.Space))
            isBoost = false;

        float x = Input.GetAxis("Horizontal");      //수평 입력 값 부드럽게 받기 -1 ~ 1
        float y = Input.GetAxis("Vertical");
        _moveDirection = new Vector3(x, y, 0);      //방향 설정
        
        boostMeter.SetBoost(currentBoost);      //부스터 세팅
        if (isBoost&&currentBoost>0f)       //부스터를 키면
        {
            _spriteRenderer.color=Color.red;        //슬라임이 빨간색으로 변하고
            transform.position += _moveDirection * (moveSpeed * Time.deltaTime) * 2f;       //두배의 속도로 움직인다
            Score_count += 10 * Time.deltaTime;     //부스터를 쓰는 동안 보너스 점수
            currentBoost -= 60 * Time.deltaTime;    //부스터 게이지 감소
        }
        else
        {
            _spriteRenderer.color = Color.white;
            transform.position += _moveDirection * (moveSpeed * Time.deltaTime);
            if(currentBoost<=80)
                currentBoost += 20 * Time.deltaTime;
        }

        if (transform.localScale.x < 0.2f)      //0.2배보다 사이즈가 작아지면 게임 오버
            SceneManager.LoadScene("Over");

        if (transform.localScale.x > 3f)        //3배보다 사이즈가 커지면 게임 승리
            SceneManager.LoadScene("Clear");
    }
}