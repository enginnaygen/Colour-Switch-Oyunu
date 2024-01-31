using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TopHareketi : MonoBehaviour
{
    public Rigidbody2D rbtop;
    public SpriteRenderer srtop;
    public float zýplama;
    public Color sarý, pembe, turkuaz, mor;
    //public CircleCollider2D topcollider;
    public string mevcutRenk;
    //public GameObject renkDegistirci;
    public Transform renkDegistirici, RenkliCember, RenkliKare, ColliderKare,ColliderCember;
    public float yukarý, CemberYpozisyonu, KareYpozisyonu, ColliderCemberYpozisyonu, ColliderKareYpozisyonu;
    public TextMeshProUGUI Skortexti,RekorTexti;
    public int skorpuanýint,rekorPuanýInt;
    public AudioSource zýplamasesi;



    private void Start()
    {
        RenkVerme();

        if(PlayerPrefs.HasKey("yuksekskor"))
        {
            rekorPuanýInt = PlayerPrefs.GetInt("yuksekskor");
            RekorTexti.text = "rekor: " + rekorPuanýInt;
        }
        else
        {
            rekorPuanýInt = 0;
        }
    }
    void RenkVerme()
    {

        int renk = Random.Range(1, 5);

        switch (renk)
        {

            case 1:
                //renk = 1;
                srtop.color = sarý;
                mevcutRenk = "sarý";
                break;
            case 2:
                //renk = 2;
                srtop.color = pembe;
                mevcutRenk = "pembe";
                break;
            case 3:
                //renk = 3;
                srtop.color = turkuaz;
                mevcutRenk = "turkuaz";
                break;
            case 4:
                //renk = 4;
                srtop.color = mor;
                mevcutRenk = "mor";
                break;
        }
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //rbtop.velocity = new Vector2(0,zýplama);
            rbtop.velocity = Vector2.up * zýplama;
            zýplamasesi.Play();
        }
        Skortexti.text = "Skor: " + skorpuanýint;


    }




    void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.tag != mevcutRenk && temas.tag != "renkdegistirici" && temas.tag != "cemberklonlayýcý" && temas.tag != "kareklonlayýcý" && temas.tag != "baslangýc")
        {
            SceneManager.LoadScene(0);
            Debug.Log("Geçemedi");
            CemberDonmesi.donmeHizi = 2f;
        }
        if (temas.tag == mevcutRenk)
        {

            Debug.Log("Geçti");
        }
        if (temas.tag == "renkdegistirici")
        {
            yukarý += 8;
            RenkVerme();
            renkDegistirici.position = new Vector3(0, yukarý, 1);
            Debug.Log("Renk Deðiþti");
            skorpuanýint++;
            CemberDonmesi.donmeHizi += 0.02f;
            Debug.Log(CemberDonmesi.donmeHizi);

            if(skorpuanýint>rekorPuanýInt)
            {
                rekorPuanýInt = skorpuanýint;
                PlayerPrefs.SetInt("yuksekskor", rekorPuanýInt);
                RekorTexti.text = "rekor: " + rekorPuanýInt;
            }
        }
        if (temas.tag == "cemberklonlayýcý")
        {
            //CemberYpozisyonu += 16;
            //ColliderCemberYpozisyonu += 16;
            RenkliCember.position = new Vector3(0, RenkliCember.position.y+16, 1);
            ColliderCember.position = new Vector3(0, ColliderCember.position.y+16, 1);
            Debug.Log("cember klonlayýcýyla temas etti");

        }
        if (temas.tag == "kareklonlayýcý")
        {
            
            KareYpozisyonu += 16;
            ColliderKareYpozisyonu += 16;
            ColliderKare.position = new Vector3(0, ColliderKareYpozisyonu, 1);
            RenkliKare.position = new Vector3(0, KareYpozisyonu, 1);
            Debug.Log("kare klonlayýcýyla temas etti");

        }

        if(temas.tag =="baslangýc")
        {
            rbtop.velocity = Vector2.up*10;
        }



    }
}



    

