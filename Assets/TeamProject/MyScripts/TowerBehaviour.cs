using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {

    private Material mat;
    public bool isColliding;
    private Color myColor;

    public bool isPlaced = false;

    private float _fireRate = 0.5f;
    private float canFire = 0;

    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform gunPosition;

    [SerializeField]
    private List<GameObject> enemies;

    // Use this for initialization
    void Awake () {
        mat = GetComponent<Renderer>().material;
	}
    void Start()
    {


        enemies = new List<GameObject>();
        myColor = new Color32(0x59, 0xB4, 0x65, 0xFF);
        gameObject.GetComponent<Renderer>().material.color = myColor;
    }
	
	// Update is called once per frame
	void Update () {
        if (enemies.Count > 0 && (enemies[0].transform.position - this.gameObject.transform.position).sqrMagnitude < 150.0f && enemies[0].GetComponent<EnemyController>().isDead != true)
        {
            //this.transform.LookAt(enemies[0].transform.position);
            if (Time.time > canFire && isPlaced == true)
            {
                
                Shoot();

            }
        }
    }

    void Shoot()
    {
        
        //projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, enemies[0].transform.position, 10f);
        
            
        if (enemies[0] != null)
        {
            Instantiate(projectile, gunPosition.transform.position, Quaternion.LookRotation(enemies[0].transform.position));
            projectile.GetComponent<ProjectileBehaviour>().enemy = enemies[0];
            canFire = Time.time + _fireRate;
        }
            
            
        

    }



    public void SetOpaque()
    {
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        mat.SetInt("_ZWrite", 1);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.DisableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = -1;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag != "floor")
        {
            isColliding = true;
        }

        if (col.transform.tag == "Base")
        GetComponent<Renderer>().material.color = Color.red;

    if (col.transform.tag == "enemy" && !enemies.Contains(col.gameObject))
    {
        enemies.Add(col.gameObject);
    }
    
}
    void OnTriggerStay(Collider col)
    {
        if(col.transform.tag =="enemy" && col.GetComponent<EnemyController>().isDead == true )
        {
            enemies.Remove(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        isColliding = false;  
        GetComponent<Renderer>().material.color = Color.green;
        gameObject.GetComponent<Renderer>().material.color = myColor;

        if (col.transform.tag == "enemy" && enemies.Contains(col.gameObject))
        {
            enemies.Remove(col.gameObject);
        }
    }
}
