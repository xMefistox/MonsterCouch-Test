using Common;
using MonsterCouchTest.Zenject.Signals;
using System;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer; 
    [SerializeField]
    private float _movementSpeed = 0.2f;
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private AudioClip _defeatClip;
    [SerializeField]
    private GameObject _player;
    
    private bool _caught = false;

    [Inject]
    private SignalBus _signalBus;
    private AudioManager _audioManager;

    public void OnActive()
    {
        gameObject.SetActive(true);
    }

    internal void Init(GameObject player, SignalBus signalBus, AudioManager audioManager)
    {
        _signalBus = signalBus;
        _player = player;
        _audioManager = audioManager;

    }

    internal void OnRelease()
    {
        _spriteRenderer.color = Color.black;
        _audioManager.PlayAudio(_defeatClip);
    }

    internal void SetPlayer(GameObject player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        if (_caught)
        {
            return;
        }
        Vector2 direction = (transform.position - _player.transform.position).normalized * _movementSpeed;
        direction += UnityEngine.Random.insideUnitCircle * 0.3f;
        _rigidbody.MovePosition(_rigidbody.position + direction * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _player)
        {
            _caught = true;
            _signalBus.Fire<EnemyDefeatedSignal>(new EnemyDefeatedSignal(this));
        }
    }
}
