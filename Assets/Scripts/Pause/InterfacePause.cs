using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一時停止・再開の処理を実装するインターフェイス
/// </summary>
public interface InterfacePause
{
    /// <summary>一時停止のための処理を実装</summary>
    void Pause();
    /// <summary>再開のための処理を実装</summary>
    void Resume();
}
