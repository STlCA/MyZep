using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    // 쳐다보기를 맡은 파트들을 모아놓은 구역(팀)
    // 이 쳐다보기를 맡은 팀에서 필요할거 같은걸 미리 가져오기

    private TopDownCharacterController _controller; //식당책임자

    [SerializeField] private SpriteRenderer characterRenderer;//요리할것


    private void Awake() //밑으로 들어갈 식당을 구하기 //내가 요리할 것 정하기
    {
        _controller = GetComponent<TopDownCharacterController>();//나라는 오브젝트에 TopDownController와 TopDownMovement가 달려있어야함

    }

    private void Start() //식당의 쉐프가 요리지시를 내림
    {
        _controller.OnLookEvent += OnAim;//코스요리에 OnAim이라는메뉴파트가 포함되어있어서 재료를 줬음
                                         //OnLookEvent쉐프가 재료를 주며 OnAim을 만들라고함
                                         //근데 얜 재료손질이 필요없어서 재료를 받자마자 요리해서 제출가능
    }

    private void OnAim(Vector2 direction)//OnAim파트 //OnAim파트가 맡은 메뉴의 레시피
    {
        //근데 얜 재료손질이 필요없어서 바로 만들어서 제출
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

    }
}
