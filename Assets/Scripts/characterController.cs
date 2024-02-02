using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public static float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _spriteRenderer;
    //oyun ba�lamadan edit�r �zerinden kullanaca��m objeyi g�stermek
    [SerializeField] private GameObject _camera; //SerializeField ba�l�kl� �geler private olmas�na ra�men 
                                                 //edit�rde g�r�lebilir.

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //caching spriteRenderer
        r2d = GetComponent<Rigidbody2D>(); //caching r2d
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }

    //fizik hesaplamalar�n�n hepsi FixedUpdate()'te yap�l�r
    private void FixedUpdate() //unity engine fonksiyonu ; 50fps    
    {
        //r2d.velocity = new Vector2(speed, 0f);
    }

    void Update() //per frame. Fizik hesaplamalar� buradan �nce yap�l�r.
    {
        //bu charPos y�netimi ile herhangi bir fizik eleman� kullanmam�� oluyoruz.
        //sadece pozisyon de�i�ikli�i yapm�� oluyoruz.
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y); //deltaTime; her bir frame aras�ndaki zaman� tutuyor.
        transform.position = charPos; //Hesaplad���m pozisyon karakterime i�lensin.

        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);//value k�sm�na ne yazd���m�z �ok �nemli de�il
                                                        // ��nk� unity hubta animator/inspector k�sm�nda ayarlad�k: greater than 0.01
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        } else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }
    private void LateUpdate()
    {
        //{_camera.transform.position = charPos;}kameram tam olarak karakterin �st�nde. fps oyunlaar�n� d���n
        //_camera.transform.position = new Vector3(charPos.x,charPos.y,charPos.z -1.0f); //kameram karakterimden 1f geride ba�l�yor.
    }
}
