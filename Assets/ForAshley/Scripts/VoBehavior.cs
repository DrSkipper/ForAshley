﻿using UnityEngine;

/**
 * As recommended by Asher Vollmer https://twitter.com/AsherVo/status/461579941159501824
 */
public class VoBehavior : MonoBehaviour
{
	public new GameObject gameObject { get { 
        if (!_gameObject) _gameObject = base.gameObject;
        return _gameObject; 
    } }

	public new Transform transform { get {
			if (!_transform) _transform = base.transform;
			return _transform;
	} }

	public new Renderer renderer { get {
			if (!_renderer) _renderer = base.GetComponent<Renderer>();
			return _renderer;
	} }
	
	public SpriteRenderer spriteRenderer { get {
			if (!_spriteRenderer) _spriteRenderer = base.GetComponent<SpriteRenderer>();
			return _spriteRenderer;
	} }

    public LocalEventNotifier localNotifier {  get {
            if (!_localNotifier)
            {
                _localNotifier = base.GetComponent<LocalEventNotifier>();
                if (!_localNotifier)
                    _localNotifier = base.gameObject.AddComponent<LocalEventNotifier>();
            }
            return _localNotifier;
    } }

    public LayerMask layerMask { get {
            return 1 << this.gameObject.layer;
    } }

    public virtual void OnDestroy()
    {
        if (_localNotifier)
            _localNotifier.RemoveAllListenersForOwner(this);
    }

    /**
     * Private
     */
    private GameObject _gameObject;
    private Transform _transform;
    private Renderer _renderer;
    private SpriteRenderer _spriteRenderer;
    private LocalEventNotifier _localNotifier;
}
