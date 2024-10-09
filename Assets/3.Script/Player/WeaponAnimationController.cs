using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationController : MonoBehaviour
{
    // 무기 애니메이션 프리팹 배열 (도끼, 곡괭이, 물뿌리개, 호미 등)
    public GameObject[] weaponPrefabs;

    // 현재 선택된 무기의 트리거 이름을 저장하는 변수
    private string currentWeaponTrigger;

    // 애니메이션이 재생 중인지 확인하는 변수
    private bool isAnimationPlaying;

    // 플레이어가 현재 고정된 위치를 저장하는 변수
    private Vector3 fixedPosition;

    // 플레이어의 Animator 컴포넌트를 저장하는 변수
    private Animator playerAnimator;

    // 스크립트가 처음 시작될 때 호출되는 메서드 (초기 설정)
    private void Start()
    {
        // Animator 컴포넌트를 가져와서 저장
        playerAnimator = GetComponent<Animator>();

        // 초기에는 애니메이션이 재생 중이 아님
        isAnimationPlaying = false;
    }

    // 현재 무기 트리거를 설정하는 메서드
    public void SetWeaponTrigger(string triggerName)
    {
        currentWeaponTrigger = triggerName; // 현재 선택된 트리거를 저장
    }

    // 무기 애니메이션을 실행하는 메서드
    public void PlayWeaponAnimation()
    {
        // 트리거가 설정되어 있지 않거나, 이미 애니메이션이 재생 중이면 실행하지 않음
        if (currentWeaponTrigger == null || isAnimationPlaying)
            return;

        // 플레이어의 마지막 이동 방향을 가져옴
        float lastMoveX = playerAnimator.GetFloat("LastMoveX");
        float lastMoveY = playerAnimator.GetFloat("LastMoveY");

        // 무기 애니메이션을 플레이어가 바라보는 방향에 맞춰 생성
        Vector3 weaponPosition = transform.position + new Vector3(lastMoveX, lastMoveY, 0);

        // 현재 선택된 무기 애니메이션을 생성 (인덱스에 따라 선택)
        GameObject weapon = Instantiate(weaponPrefabs[GetWeaponIndex()], weaponPosition, Quaternion.identity);

        // 무기 애니메이션의 방향을 설정 (왼쪽, 오른쪽, 위, 아래)
        if (lastMoveX < 0)
        {
            weapon.transform.localScale = new Vector3(-1, 1, 1); // 왼쪽 방향
        }
        else if (lastMoveX > 0)
        {
            weapon.transform.localScale = new Vector3(1, 1, 1); // 오른쪽 방향
        }
        else if (lastMoveY < 0)
        {
            weapon.transform.rotation = Quaternion.Euler(0, 0, 0); // 아래쪽 방향
        }
        else if (lastMoveY > 0)
        {
            weapon.transform.rotation = Quaternion.Euler(0, 0, 180); // 위쪽 방향
        }

        // 일정 시간이 지나면 무기 애니메이션을 삭제
        Destroy(weapon, 0.5f);

        // 애니메이션이 재생 중임을 표시
        isAnimationPlaying = true;

        // 애니메이션이 끝나면 호출될 메서드 설정 (0.5초 후)
        Invoke("EndAnimation", 0.5f);
    }

    // 현재 선택된 무기에 따른 인덱스를 반환하는 메서드
    private int GetWeaponIndex()
    {
        switch (currentWeaponTrigger)
        {
            case "Axe":
                return 0; // 도끼
            case "Pick":
                return 1; // 곡괭이
            case "Water":
                return 2; // 물뿌리개
            case "Slice":
                return 3; // 슬래시
            case "Hoe":
                return 4; // **호미 추가**
            default:
                return 0; // 기본값은 도끼로 설정
        }
    }

    // 애니메이션이 끝났을 때 호출되는 메서드
    private void EndAnimation()
    {
        isAnimationPlaying = false; // 애니메이션이 끝났음을 표시
    }
}
