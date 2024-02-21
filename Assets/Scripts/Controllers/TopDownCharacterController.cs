using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    //TopDownCharacterController = 식당총책임자 // 한개만있어야함

    //PlayerInputController = 카운터
    //OnMove = 코스메뉴 주문
    //InputValue = 주문한 코스메뉴의 재료

    //CallMoveEvent = 재료를 받아서 식당으로 가지고옴
    //OnMoveEvent = 코스요리에 있는 메뉴파트들에게 만들게끔 지시

    //TopDownMovement = 움직임을 맡은 팀

    public delegate void OnMoveDel(Vector2 direction);//대리자
    public OnMoveDel OnMoveEvent;//대리자를 쉐프로 임명 = A코스 담당 쉐프
    
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
