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
    public float z�plama;
    public Color sar�, pembe, turkuaz, mor;
    //public CircleCollider2D topcollider;
    public string mevcutRenk;
    //public GameObject renkDegistirci;
    public Transform renkDegistirici, RenkliCember, RenkliKare, ColliderKare,ColliderCember;
    public float yukar�, CemberYpozisyonu, KareYpozisyonu, ColliderCemberYpozisyonu, ColliderKareYpozisyonu;
    public TextMeshProUGUI Skortexti,RekorTexti;
    public int skorpuan�int,rekorPuan�Int;
    public AudioSource z�plamasesi;



    private void Start()
    {
        RenkVerme();

        if(PlayerPrefs.HasKey("yuksekskor"))
        {
            rekorPuan�Int = PlayerPrefs.GetInt("yuksekskor");
            RekorTexti.text = "rekor: " + rekorPuan�Int;
        }
        else
        {
            rekorPuan�Int = 0;
        }
    }
    void RenkVerme()
    {

        int renk = Random.Range(1, 5);

        switch (renk)
        {

            case 1:
                //renk = 1;
                srtop.color = sar�;
                mevcutRenk = "sar�";
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
            //rbtop.velocity = new Vector2(0,z�plama);
            rbtop.velocity = Vector2.up * z�plama;
            z�plamasesi.Play();
        }
        Skortexti.text = "Skor: " + skorpuan�int;


    }




    void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.tag != mevcutRenk && temas.tag != "renkdegistirici" && temas.tag != "cemberklonlay�c�" && temas.tag != "kareklonlay�c�" && temas.tag != "baslang�c")
        {
            SceneManager.LoadScene(0);
            Debug.Log("Ge�emedi");
            CemberDonmesi.donmeHizi = 2f;
        }
        if (temas.tag == mevcutRenk)
        {

            Debug.Log("Ge�ti");
        }
        if (temas.tag == "renkdegistirici")
        {
            yukar� += 8;
            RenkVerme();
            renkDegistirici.position = new Vector3(0, yukar�, 1);
            Debug.Log("Renk De�i�ti");
            skorpuan�int++;
            CemberDonmesi.donmeHizi += 0.02f;
            Debug.Log(CemberDonmesi.donmeHizi);

            if(skorpuan�int>rekorPuan�Int)
            {
                rekorPuan�Int = skorpuan�int;
                PlayerPrefs.SetInt("yuksekskor", rekorPuan�Int);
                RekorTexti.text = "rekor: " + rekorPuan�Int;
            }
        }
        if (temas.tag == "cemberklonlay�c�")
        {
            //CemberYpozisyonu += 16;
            //ColliderCemberYpozisyonu += 16;
            RenkliCember.position = new Vector3(0, RenkliCember.position.y+16, 1);
            ColliderCember.position = new Vector3(0, ColliderCember.position.y+16, 1);
            Debug.Log("cember klonlay�c�yla temas etti");

        }
        if (temas.tag == "kareklonlay�c�")
        {
            
            KareYpozisyonu += 16;
            ColliderKareYpozisyonu += 16;
            ColliderKare.position = new Vector3(0, ColliderKareYpozisyonu, 1);
            RenkliKare.position = new Vector3(0, KareYpozisyonu, 1);
            Debug.Log("kare klonlay�c�yla temas etti");

        }

        if(temas.tag =="baslang�c")
        {
            rbtop.velocity = Vector2.up*10;
        }



    }
}



    

