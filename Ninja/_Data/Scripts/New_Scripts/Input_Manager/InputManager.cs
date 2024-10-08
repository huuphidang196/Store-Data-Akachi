using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEJumpPlayer
{
    public abstract void PressJump();

}
public interface IEAttackThrowPlayer
{
    public abstract void PressAttackThrow();

}
public class InputManager : SurMonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    [SerializeField] protected bool _Press_Left = false;
    public bool Press_Left => _Press_Left;

    [SerializeField] protected bool _Press_Right = false;
    public bool Press_Right => _Press_Right;

    [SerializeField] protected bool _Press_Jump = false;
    public bool Press_Jump => _Press_Jump;

    [SerializeField] protected bool _Press_Attack_Throw = false;
    public bool Press_Attack_Throw => _Press_Attack_Throw;

    [SerializeField] protected bool _Press_Attack_Dashing = false;
    public bool Press_Attack_Dashing => _Press_Attack_Dashing;

    [SerializeField] protected bool _Press_Hiden_Mode = false;
    public bool Press_Hiden_Mode => _Press_Hiden_Mode;

    [SerializeField] protected bool isRiviving;
    public bool IsRiviving => isRiviving;

    [SerializeField] protected IEJumpPlayer _IEJump_Player;
    //  [SerializeField] protected IEAttackThrowPlayer _IEAttack_Throw_Player;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only InputManager was allowed existed");

        _instance = this;
    }

    public virtual void SetInterfaceJumpPlayer(IEJumpPlayer eJumpPlayer)
    {
        this._IEJump_Player = eJumpPlayer;
    }
    public virtual void SetInterfaceAttackThrowPlayer(IEAttackThrowPlayer attackThrowPlayer)
    {
        // this._IEAttack_Throw_Player = attackThrowPlayer;
    }
    protected override void Start()
    {
        base.Start();
        Application.targetFrameRate = 60;

    }
    protected virtual void Update()
    {
        // Kiểm tra phím mũi tên lên
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Mũi tên lên được nhấn");
            this.PointerJumpDown();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Debug.Log("Mũi tên lên được nhấn");
            this.PointerJumpUp();
        }

        // Kiểm tra phím mũi tên trái
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("Mũi tên trái được nhấn");
            this.PointerLeftDown();
        }
        // Kiểm tra phím mũi tên trái
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //Debug.Log("Mũi tên trái được nhấn");
            this.PointerLeftUp();
        }

        // Kiểm tra phím mũi tên phải
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("Mũi tên phải được nhấn");
            this.PointerRightDown();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //Debug.Log("Mũi tên phải được nhấn");
            this.PointerRightUp();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("Mũi tên phải được nhấn");
            this.PointerAttackThrowDown();
            PlayerCtrl.Instance.PlayerAttack.PerformAttackThrowShuriken();
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Mũi tên phải được nhấn");
            this.PointerAttackDashingDown();
        }
    }
    //Left
    public virtual void PointerLeftDown()
    {
        this._Press_Left = true;
        this._Press_Right = false;
    }
    public virtual void PointerLeftUp()
    {
        this._Press_Left = false;
    }

    //Right
    public virtual void PointerRightDown()
    {
        this._Press_Left = false;
        this._Press_Right = true;
    }
    public virtual void PointerRightUp()
    {
        this._Press_Right = false;
    }

    //Jump
    public virtual void PointerJumpDown()
    {
        if (this._Press_Hiden_Mode) return;
        this._Press_Jump = true;
        this._IEJump_Player?.PressJump();
    }
    public virtual void PointerJumpUp()
    {
        this._Press_Jump = false;
    }

    //Attack Throw
    public virtual void PointerAttackThrowDown()
    {
        if (this._Press_Hiden_Mode) return;

        this._Press_Attack_Throw = true;
        //   Debug.Log("Press Attack throw");
    }

    public virtual void PointerAttackThrowPresAndUp()
    {
        this._Press_Attack_Throw = false;
    }

    //Attack Dashing
    public virtual void PointerAttackDashingDown()
    {
        if (this._Press_Hiden_Mode) return;

        this._Press_Attack_Dashing = true;
        //   Debug.Log("Press Attack throw");
    }

    public virtual void PointerAttackDashingPresAndUp()
    {
        this._Press_Attack_Dashing = false;
    }

    //Hiden
    public virtual void PointerHidenModeSkillDown()
    {
        if (this._Press_Hiden_Mode)
        {
            this.PointerHidenModeSkillPresAndUp();
            return;
        }
        this._Press_Hiden_Mode = true;
    }

    public virtual void PointerHidenModeSkillPresAndUp()
    {
        this._Press_Hiden_Mode = false;
    }

    //Riviving
    public virtual void PlayerRiviveAgain()
    {
        this.isRiviving = true;
        //   Debug.Log("Press Attack throw");
    }

    public virtual void PlayerRiviveAgainCompleted()
    {
        this.isRiviving = false;
    }

    //Dead
    public virtual void SetFalseAllBoolWhenPlayerDead()
    {
        this.PointerAttackDashingPresAndUp();
        this.PointerAttackThrowPresAndUp();
        this.PointerHidenModeSkillPresAndUp();
        this.PointerJumpUp();
    }       
        
}
