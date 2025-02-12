using UnityEngine;

public class Durian : MonoBehaviour, IWeapon, ILevelup
{
    private Monster monster;
    public WeaponData durianData;
    public PlayerData playerData;
    private GameObject durian;
    private Rigidbody2D rigid;
    public float speed;
    public float angleSpeed;
    private Vector2 movePos;
    private Vector2 verticalNormalVec;
    private Vector2 horizontalNormalVec;
    public float levelUpSize;
    public void Attack()
    {
        durian = GameObject.FindWithTag("WeaponPos").transform.Find("DurianPos").gameObject;
        durian.SetActive(true);
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movePos = new Vector2(speed, speed);
        horizontalNormalVec = new Vector2(-1, 0);
        verticalNormalVec = new Vector2(0, -1);
        rigid.AddTorque(angleSpeed);
    }

    private void Update()
    {
        rigid.velocity = movePos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        switch (collision.tag)
        {
            case "AngleSideX":
                Vector2 incomingVector = movePos.normalized;
                Vector2 reflectXVector = Vector2.Reflect(incomingVector, horizontalNormalVec);
                movePos = reflectXVector.normalized * speed;
                break;

            case "AngleSideY":
                Vector2 incomingYVector = movePos.normalized;
                Vector2 reflectYVector = Vector2.Reflect(incomingYVector, verticalNormalVec);
                movePos = reflectYVector.normalized * speed;
                break;
            case "Monster":
                monster = collision.gameObject.GetComponent<Monster>();
                monster.monsterHealth -= durianData.Atk * playerData.Atk;
                break;

        }
    }

    public void LevelUp()
    {
        durianData.Level++;
        transform.localScale += new Vector3(levelUpSize, levelUpSize, 0);
        durian.SetActive(false);
        durian.SetActive(true);
    }
}
