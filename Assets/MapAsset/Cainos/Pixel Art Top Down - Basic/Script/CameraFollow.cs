using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset; //offset도 필요 없을 것 같긴한데

        public BoxCollider2D moveableArea;

        [SerializeField]float minY, maxY;

        
        void Start()
        {
            var camera = GetComponent<Camera>();

            float height = camera.orthographicSize;
            target = Player.instance.transform;

            offset = target.position - transform.position;

            //카메라의 포지션 y가 박스컬라이더 범위 밖으로 나가지 않게

            minY = height / 2 + moveableArea.transform.position.z + moveableArea.size.y - moveableArea.size.y / 2;
            maxY = -height / 2 + moveableArea.transform.position.z + moveableArea.size.y + moveableArea.size.y / 2;

            //카메라 포지션 x는 음수 양수 이동 가능



        }

        public float lerp = 0.05f;
        void LateUpdate()
        {

            var newPos = target.position - offset;

            newPos.y = Mathf.Min(newPos.y, maxY);
            newPos.y = Mathf.Max(newPos.y, minY);

            transform.position = Vector3.Lerp(transform.position, newPos, lerp);

        }
    }
}
