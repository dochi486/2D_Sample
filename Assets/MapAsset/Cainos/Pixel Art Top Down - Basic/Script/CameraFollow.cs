using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector2 offset; //offset도 필요 없을 것 같긴한데
        
        //todo: 카메라 y값은 고정되어 있고 플레이어를 따라서 x축으로만 움직이도록 수정
        //->지금은 아예 고정 상태..
        void Start()
        {
            var camera = GetComponent<Camera>();

            target = Player.instance.transform;

            offset = target.position - transform.position;
        }
        void Update()
        {
            var cameraPos = GetComponent<Camera>().transform.position;
            cameraPos.y = 0;
            cameraPos.x = target.position.x;

            transform.position = cameraPos; //카메라의 y값을 항상 0으로

        }
    }
}
