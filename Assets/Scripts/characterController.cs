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
    //oyun baþlamadan editör üzerinden kullanacaðým objeyi göstermek
    [SerializeField] private GameObject _camera; //SerializeField baþlýklý ögeler private olmasýna raðmen 
                                                 //editörde görülebilir.

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //caching spriteRenderer
        r2d = GetComponent<Rigidbody2D>(); //caching r2d
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }

    //fizik hesaplamalarýnýn hepsi FixedUpdate()'te yapýlýr
    private void FixedUpdate() //unity engine fonksiyonu ; 50fps    
    {
        //r2d.velocity = new Vector2(speed, 0f);
    }

    void Update() //per frame. Fizik hesaplamalarý buradan önce yapýlýr.
    {
        //bu charPos yönetimi ile herhangi bir fizik elemaný kullanmamýþ oluyoruz.
        //sadece pozisyon deðiþikliði yapmýþ oluyoruz.
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y); //deltaTime; her bir frame arasýndaki zamaný tutuyor.
        transform.position = charPos; //Hesapladýðým pozisyon karakterime iþlensin.

        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);//value kýsmýna ne yazdýðýmýz çok önemli deðil
                                                        // çünkü unity hubta animator/inspector kýsmýnda ayarladýk: greater than 0.01
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
        //{_camera.transform.position = charPos;}kameram tam olarak karakterin üstünde. fps oyunlaarýný düþün
        //_camera.transform.position = new Vector3(charPos.x,charPos.y,charPos.z -1.0f); //kameram karakterimden 1f geride baþlýyor.
    }
}
