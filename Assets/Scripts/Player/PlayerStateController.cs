using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateController : MonoBehaviour
{
    public SkillState _playerSkillState;
    public AttributeMagicState _playerAttributeMagicState;
    // Start is called before the first frame update
    void Start()
    {
        _playerAttributeMagicState = AttributeMagicState.Fier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>Player��skill�g�p�̏�Ԃ��Ǘ�����r�b�g�t���O�ł�</summary>
    [Flags]
    public enum SkillState
    {
        /// <summary>�U����UP�X�L��</summary>
        AttackPowerUp = 1 << 0,
        /// <summary>HP�񕜃X�L��</summary>
        HPRecovery = 1 << 1,
        /// <summary>�_���[�W0�V�[���h�����X�L��</summary>
        ShieldOn = 1 << 2,
    }

    /// <summary>�@Player�̌��ݎg�p���Ă��閂�@�����̊Ǘ��p </summary>
    public enum AttributeMagicState
    {
        /// <summary>�Α���</summary>
        Fier,
        /// <summary>�X����</summary>
        Ice,
        /// <summary>������</summary>
        Wind,
        /// <summary>������</summary>
        Thunder,
    }
}
