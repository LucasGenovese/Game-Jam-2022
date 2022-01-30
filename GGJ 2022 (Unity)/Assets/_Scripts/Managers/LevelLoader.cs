using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{



    [Header("Extras")]
    [SerializeField] private Animator _animator;
    [SerializeField] private float _transitionTime = 1f;


    private void Start()
    {
        if (_animator == null)
        {
            _animator = GetComponentInChildren<Animator>();
        }

        GameManager.Instance.LevelLoader = this;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    private IEnumerator LoadLevel(string sceneName)
    {
        // Play Animation
        _animator.SetTrigger("StartCrossfade");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(sceneName);
    }


}
