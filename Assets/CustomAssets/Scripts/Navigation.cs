
using Unity.XR.CoreUtils;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    protected Vector2 MovementAxis;
    protected bool run;
    protected bool jump;

    protected CharacterController character;
    protected XROrigin rig;

    public float walkSpeed = 5;
    protected float curSpeed;
    public float runSpeed = 10;
    public float acceleration = 2.5f;

    public float gravitySpeed = -9.81f;
    protected float curFallingSpeed;
    public float jumpSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        curSpeed = walkSpeed;
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }
       

    void FixedUpdate()
    {
        horizontalMove();
        verticalMove();
    }

    void horizontalMove()
    {
        //go no slower than walk speed or faster than run speed (if moving)
        if (run)
        {
            curSpeed = runSpeed;
        }
        else
        {
            curSpeed = walkSpeed;
        }
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(MovementAxis.x, 0, MovementAxis.y);
        character.Move(direction * Time.fixedDeltaTime * curSpeed);
    }

    void verticalMove()
    {
        //if the jump button has been pressed and cur falling speed equals gravity speed
        if (jump && curFallingSpeed == gravitySpeed)
        {
            //jump
            curFallingSpeed = jumpSpeed;
        }
        //fall
        curFallingSpeed += Time.fixedDeltaTime * gravitySpeed;
        curFallingSpeed = Mathf.Clamp(curFallingSpeed, gravitySpeed, jumpSpeed);

        //vertical movement
        character.Move(Vector3.up * curFallingSpeed * Time.fixedDeltaTime);
    }
}