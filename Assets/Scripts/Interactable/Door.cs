using UnityEngine;


public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject LDoor_GameObj;
    [SerializeField] private GameObject RDoor_GameObj;     
    private Vector3 LDoorTarget;
    private Vector3 RDoortTarget;
    private bool canMove;
    private Collider doorsCollider;

    public string GetDesctiption()
    {
        return "open";
    }

    public void Interacted()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canMove = true;
        }
    }

// Use this for initialization
    void Start()
    {
        canMove = false;
        LDoorTarget = new Vector3(13f, LDoor_GameObj.transform.position.y, LDoor_GameObj.transform.position.z);
        RDoortTarget = new Vector3(-13f, RDoor_GameObj.transform.position.y, RDoor_GameObj.transform.position.z);
        doorsCollider = GetComponent<Collider>();
    }   

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            LDoor_GameObj.transform.localPosition = Vector3.MoveTowards(LDoor_GameObj.transform.position, LDoorTarget, 5f * Time.deltaTime);
            RDoor_GameObj.transform.localPosition = Vector3.MoveTowards(RDoor_GameObj.transform.position, RDoortTarget, 5f * Time.deltaTime);
        }
        
        if(LDoor_GameObj.transform.position.x >= 13 && RDoor_GameObj.transform.position.x <= -13)
        {
            canMove = false;
            doorsCollider.isTrigger = true;
            Destroy(this);
        }
    }
}