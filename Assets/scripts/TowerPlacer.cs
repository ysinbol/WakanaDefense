using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;
    public LayerMask groundLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウスの位置からrayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // groundLayerに対してrayが当たったか判定する
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                // rayが当たった場所にタワーを生成する
                Instantiate(towerPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}