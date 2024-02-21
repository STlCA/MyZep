using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    // 움직임을 맡은 파트들을 모아놓은 구역(팀)
    // 이 움직임을 맡은 팀에서 필요할거 같은걸 미리 가져오기
    
    private TopDownCharacterController _controller; //식당책임자

    private Vector2 _movementDirection = Vector2.zero; //재료
    private Rigidbody2D _rigidbody2D;//요리할것

    private void Awake() //밑으로 들어갈 식당을 구하기 //내가 요리할 것 정하기
    {
        _controller = GetComponent<TopDownCharacterController>();//나라는 오브젝트에 TopDownController와 TopDownMovement가 달려있어야함
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start() //식당의 쉐프가 요리지시를 내림
    {
        _controller.OnMoveEvent += Move;//코스요리에 Move라는메뉴파트가 포함되어있어서 재료를 줬음
                                        //OnMoveEvent쉐프가 재료를 주며 Move를 만들라고함
    }

    private void FixedUpdate()//재료손질과 요리파트가 나뉘어있을때 사용
    {
        //물리법칙을 적용하고 업데이트를 하려면 fixed사용
        ApplyMovement(_movementDirection);//손질된 재료로 레시피대로 요리 후 제출
    }

    private void Move(Vector2 dirction)//Move파트 //Move파트가 맡은 메뉴
    {
        _movementDirection = dirction;//재료 손질
    }

    private void ApplyMovement(Vector2 direction)//레시피
    {
        direction *= 5;

        //transform.position//transform은 신의 힘 //rigidbody는 물리법칙
        _rigidbody2D.velocity = direction; //velocity = 방향, 속도 //direction방향으로 5라는 만큼 이동
    }
}
