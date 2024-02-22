using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    //TopDownCharacterController = 식당총책임자 식당 // 한개만있어야함

    //PlayerInputController = 카운터
    //OnMove = A코스메뉴 주문
    //OnLook = B코스메뉴 주문
    //InputValue = 주문한 코스메뉴의 재료

    //CallMoveEvent = 재료를 받아서 식당으로 가지고옴
    //OnMoveEvent = 쉐프가 코스요리에 있는 메뉴파트들에게 만들게끔 지시

    //팀이 만들어질때 기본형(TopDownCharacterController)이 먼저 만들어지고 팀이 만들어짐
    //TopDownMovement = 움직임을 맡은 팀
    //TopDownAimRotation = 쳐다보기를 맡은 팀

    //가게가 지어질 때 내가 원하는 코스에 대리자지원자를 받아서 쉐프로 임명
    public delegate void OnMoveDel(Vector2 direction);//대리자
    public OnMoveDel OnMoveEvent;//대리자를 쉐프로 임명 = A코스 담당 쉐프
    //public event OnMoveDel OnMoveEvent; -> event를 붙이면 노예계약같은 느낌
    //public이여서 다른곳에서 실행이 가능했음
    //근데 event를 붙이면 얘가 존재하는 이곳에서만 실행이 가능함
    //물론 메뉴 추가하는건 다른곳에서도 가능함

    //public delegate void OnMoveDel(Vector2 direction);//대리자구하는게 귀찮으면
    //public event Action<Vector2> OnMoveEvent;로 사용가능 //익명대리자(이름없는대리자)
    // 위에가 void 반환값이 없으면 Action 반환값이 있으면 Func

    public delegate void OnLookDel(Vector2 direction);//대리자2
    public OnLookDel OnLookEvent;//B코스 담당 쉐프


    public void CallMoveEvent(Vector2 direction)//재료값 , 재료값을 받아오는곳? playerinput의 value값
    {
        OnMoveEvent?.Invoke(direction);//재료가 왔으면 요리를 해야하므로 이 코스요리의 각 메뉴의 담당파트들에 재료 및 지시전달
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
