using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using TMPro;

public class EnemyPattern1 : MonoBehaviour
{
    public float enemySpeed;
    public float limitX;
    public float limitY;
    public float randompointX;
    public Vector3 goalPoint;
    public float playTime;

    private void Start() {
        //업데이트를 통해 플레이전에도 목표물이 움직이게 되는 부분을 방지합니다.
        goalPoint = transform.position;
    }
    private void Update() {
        MoveEnemy();
    }

  // 타켓의 움직임을 통제하는 부분입니다.
    public void RandomMove(){
        //x,y 좌료를 랜덤으로 생성해주는 부분입니다.
        float pointX = Random.Range(-randompointX, randompointX + 1);
        float pointY = Random.Range(2, 6);
        //랜덤좌표입니다. 랜덤한 좌표가 지정한 범위 이외로 벗어나는지 체크합니다.
        Vector3 preGoalPoint = new Vector3(pointX, pointY, 10);
        
        //오브젝트의 위치값에 랜덤좌표를 더해서 지정된 위치 이상으로 이동할시에는 중단시키고, 다시 작업하게 합니다.
        if(Mathf.Abs(transform.position.x + preGoalPoint.x) > limitX || (transform.position.y + preGoalPoint.y) > limitY){
            return;
        }
        //범위 이내일경우 목표지점에 랜덤좌표를 대입합니다.
        goalPoint = preGoalPoint;
        
    }

    public void MoveEnemy(){
        //게임중이 아닐시 시작지점에 목표물을 고정해둔뒤, 중단하게만듭니다.
        if(!GameManager.instance.isPlaying){
            transform.position = new Vector3(0, 3, 10);
            return;
        }
        //게임이 실행되면 MoveTowards로 랜덤좌표로 만든 위치로 이동하게합니다.
        transform.position = Vector3.MoveTowards(transform.position, goalPoint, enemySpeed * Time.deltaTime);

        //원하는 위치까지 이동하게되면 다시 랜덤좌표를 계산합니다.
        if(transform.position == goalPoint){
            RandomMove();
        }
    }




}
