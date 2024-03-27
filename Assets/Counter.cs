using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _delay = 0.5f;

    private IEnumerator _coroutine;
    private float _counter;
    private bool _isActive = false;

    private void Start()
    {
        _text.text = "Bla-Bla";
        _coroutine = Coroutine();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isActive)
            {
                StopCoroutine(_coroutine);
                _isActive = false;
            }
            else
            {
                StartCoroutine(_coroutine);
                _isActive = true;
            }
        }
    }

    private IEnumerator Coroutine()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            _text.text = _counter.ToString();
            _counter++;
            yield return wait;
        }
    }
}