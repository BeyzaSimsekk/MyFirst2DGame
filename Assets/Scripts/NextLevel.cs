using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int SceneIndex;//baþka b,r sahne çaðýrma yöntemi

    private Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); //caching
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_scene.buildIndex+1); //(SceneIndex) elle doldurman gerekir
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
}
