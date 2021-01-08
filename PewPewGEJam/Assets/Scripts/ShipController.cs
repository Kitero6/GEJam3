using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float _speed = 0f;
    public float _shootTimer = 0f;
    public float _switchTimer = 0f;
    public bool _isCloneHorizontallyFlipped = false;
    public Transform _muzzleTransform = null;
    public Transform _topLeftPosOfPlayerZone = null;
    public Transform _topLeftPosOfCloneZone = null;
    public Vector2 _playZoneSize = Vector2.zero;

    Vector2 _position = Vector2.zero;
    float _shootCooldown = 0f;
    float _switchCooldown = 0f;
    bool _isClone = false;
    ETypeShoot _currentType = ETypeShoot.A;
    bool _keyChangeColorLock = false;
    ShipController _clone = null;

    public bool IsClone { set { _isClone = value; } }
    public ETypeShoot CurrentType { set { _currentType = value; } }

    void Start()
    {
        if (!_isClone)
        {
            _clone = Instantiate<ShipController>(this);
            _clone.IsClone = true;
            _clone.CurrentType = ETypeShoot.B;

            _clone.UpdateColor();
        }

        _position = new Vector2(_playZoneSize.x / 2.0f, -_playZoneSize.y / 2.0f);
        _shootCooldown = 0f;
    }

    void Update()
    {
        if (!_isClone)
        {
            UpdateMovement();

            UpdateChangeType();
        }

        UpdateShoot();
    }


    void UpdateMovement()
    {
        // Update our ship
        Vector2 frameMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        _position += frameMove * Time.fixedDeltaTime * _speed;

        // Clamp the position of the player to the playzone
        _position.x = Mathf.Clamp(_position.x, 0.0f, _playZoneSize.x);
        _position.y = Mathf.Clamp(_position.y, -_playZoneSize.y, 0.0f);

        // Place the player
        transform.position = _topLeftPosOfPlayerZone.position + new Vector3(_position.x, _position.y, 0f);

        // Update the clone
        if (_clone != null)
        {
            Vector2 clonePosition = Vector2.zero;
            if (_isCloneHorizontallyFlipped)
            {
                // The offset of the player from the left border is its x position
                // To mirror the player have to set 0 being right so x = width - offset   
                clonePosition = new Vector2(_playZoneSize.x - _position.x, _position.y);
            }
            else
            {
                clonePosition = _position;
            }
            _clone.transform.position = _topLeftPosOfCloneZone.position + new Vector3(clonePosition.x, clonePosition.y, 0f);
        }
    }

    void UpdateChangeType()
    {
        _switchCooldown -= Time.deltaTime;

        float changeColor = Input.GetAxisRaw("ChangeColor");
        if (changeColor > 0f && !_keyChangeColorLock)
        {
            if (_switchCooldown <= 0f)
            {
                ETypeShoot tmpType = _currentType;
                _currentType = _clone._currentType;
                _clone.CurrentType = tmpType;

                UpdateColor();

                _switchCooldown = _switchTimer;
            }

            _keyChangeColorLock = true;
        }
        else if (changeColor == 0f && _keyChangeColorLock)
        {
            _keyChangeColorLock = false;
        }
    }

    void UpdateColor()
    {
        // Get the sprite renderer
        SpriteRenderer spr = GetComponent<SpriteRenderer>();

		//ToDo add sprites
        // Update the sprite
        //spr.sprite = TypeManager.Instance.GetPlayerSprite(_currentType);

        // Also update the clone
        _clone?.UpdateColor();
    }

    void UpdateShoot()
    {
        _shootCooldown -= Time.deltaTime;
        if (_shootCooldown <= 0f && Input.GetAxisRaw("Shoot") > 0f)
        {
            GameObject go = Instantiate(TypeManager.Instance.GetPlayerShoot(_currentType), _muzzleTransform.position, _muzzleTransform.rotation);
            Destroy(go, 2.0f);

            _shootCooldown = _shootTimer;
        }
    }
}
