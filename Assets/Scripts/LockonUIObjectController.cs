using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockonUIObjectController : MonoBehaviour
{
    /// <summary>mainCameraの位置</summary>
    Transform _mcTransform;
    RectTransform _rectTransform;
    PlayerLockon _playerLockon;
    /// <summary>MainCameraからロックオンしているEnemyGOまでのベクトルを保管するための変数</summary>
    Vector3 _dir;
    /// <summary>MainCameraからロックオンしているEnemyGOまでのベクトルを保管するための変数</summary>
    [SerializeField, Header("カメラとLockonUICanvasの距離調整用"), Tooltip("割合として使うため0～1に、1に近づくにつれこのオブジェクトがカメラから離れていく"), Range(0, 1f)] float _lockonUIdistance;

    Image _lockonImage;
    // Start is called before the first frame update
    void Start()
    {
        _mcTransform = Camera.main.GetComponent<Transform>();
        _playerLockon = FindObjectOfType<PlayerLockon>();
        _rectTransform = GetComponent<RectTransform>();
        _lockonImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_playerLockon.IsLockon)
        {
            _lockonImage.enabled = true;
            //MainCameraからロックオンしているEnemyGOの向きを取得
            if (_playerLockon.TargetPos != null)
            {
                _dir = _playerLockon.TargetPos.position - _mcTransform.position;
            }

            //このゲームオブジェクトのCanvasをカメラ方向に向ける
            _rectTransform.forward = -_dir;

            //_dirベクトル線上にこのgoを置く
            //新しいベクトルvectorEndpointの終点をこのgoを置く予定の場所とし、終点は_dirベクトルの割合で調整する
            Vector3 vectorEndpoint = _dir * _lockonUIdistance;

            //MainCameraのワールド座標のベクトルとMainCameraからこのgoを置く予定の場所までのベクトルを足して
            //このgoを置く予定の場所のワールド座標を求め、transformに代入
            _rectTransform.position = _mcTransform.position + vectorEndpoint;
            
        }
        else
        {
            //ロックオンしていない時は見えないようにする
            _lockonImage.enabled = false;
        }
    }
}
