using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController//왜상속? 
{
    //move라는 행동을 할때
    //    좌표값도 이동
    //    걸어가는 애니메이션
    //    걸어가는 소리
    //이걸한데 묶어서 관리할것
    //move라는 이벤트가 실행될때 저 모든것들이 한번씩 실행되도록

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();//재료
        //왜 value가 아니라 moveInput을 따로 저장하나요?
        //아 InputValue형을 Vector2로 바꿔주는형인가봄
        Debug.Log(moveInput);

        CallMoveEvent(moveInput);//그래서 왜 moveInput을 넘겨주나요 바로 value를 넘겨주면 안되나요?

    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();//스크린 기준으로 포지션을 받아옴
                                              //그래서 플레이어가 있는 월드좌표로 변환해야함
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(newAim);

        newAim = (worldPos - (Vector2)transform.position).normalized;//A에서 B를 빼면 B에서 A를 바라보는 방향이 나오는데 우린 방향만 알고싶기때문에 normalized;

        CallLookEvent(newAim);
    }
}
