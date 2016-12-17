
using UnityEngine;

public class Test : MonoBehaviour
{
  /*
  InputAxisManager manager { get { return InputAxisManager.entity; } }

  void Update()
  {
    int axis = manager.horizontal.axis;
    if (axis == 0) { return; }
    Debug.Log(axis);
  }
  */
}

/*

ゲームの目的
・ボスを倒す

プレイヤーのアクション
・移動：１ターン
・攻撃：１ターン
・アイテムを使う：１ターン

プレイヤーパラメータ
・HP：食事、睡眠で回復
・スタミナ：食事で回復
・攻撃力：武器で増加、耐久値あり
・防御力：防具で増加、耐久値あり

ゲーム仕様
・プレイヤーHP、プレイヤースタミナ
・マイクラ風オープンワールド
・寝る：プレイヤーを待機状態にして強制的にターン経過
・

地形の種類
・歩行
　・草
　・砂
　・木
・水上（歩行不可能）
　・川
　・海
・障害物
　・岩
　・木
　・壁（破壊不可能）

エネミーのAI
・視野がある
　・視野が０＝攻撃されるまで何もしない

エネミーのパラメータ
・HP
・攻撃力

マスクデータ
・落とすアイテム
・落とす確率
・視認範囲＝距離
　・範囲から出ても追跡するかどうかのフラグ

画面比率
・１６：９

カメラ
・９０回転
　・見下ろし角度
　・ズーム

 */
