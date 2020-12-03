using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    NOTA: no definir las colisiones en entity porque 
    laggearia mas el juego, ejemplo: dos Obstaculos colisionando
    constantemente por estar juntos a pesar de que su colision
    no haga nada
*/


public abstract class Entity : MonoBehaviour{
    public bool IsInmortal; //Health can't go under 1HP
    public bool IsInvulnerable; //Health can't be altered
    public bool IsInmovable;
    public bool IsInvisible;
    public bool IsGrounded;

    public float MaxHealth;
    [SerializeField]
    private float health;
    public float Health{
        get{
            return health;
        }set{
            if (IsInmortal){
                if (value < 1){
                    health = 1;
                }
                else{
                    health = value;
                }
            }
            else{
                if (value <= 0){
                //Method die
                health = 0;
                die();
                }else{
                    health = value;
                }
            }
        }
    }
    //Armor and Magic resist are %s
    // (-inf, 100]
    [SerializeField]
    private int armor;
    public int Armor{
        get{
            return Armor;
        }set{
            if(value >= 100){
                Armor = 100;
            }else{
                Armor = value;
            }
        }
    }
    // (-inf, 100]
    [SerializeField]
    private int magicResist;
    public int MagicResist{
        get{
            return magicResist;
        }set{
            if(value >= 100){
                magicResist = 100;
            }else{
                magicResist = value;
            }
        }
    }

    /*Movement Handle*/
    //This is a unary vector representing only movement direction
    private Vector3 movementDirection;
    public Vector3 MovementDirection{
        get{
            return movementDirection;
        }set{
            movementDirection = Vector3.Normalize(value);
        }
    }
    public float speed;
        

//Methods
    //Called when receiving damage from others
    protected void receiveDamage(DamageType type, float quantity){
        if (!IsInvulnerable){
            switch (type){
            case DamageType.PhysicalDamage:
                Health -= quantity*(1 - Armor/100);
                break;

            case DamageType.MagicalDamage:
                Health -= quantity*(1 - MagicResist/100);
                break;

            case DamageType.HibridDamage:
                Health -= quantity*(0.5f - Armor/200) +
                            quantity*(0.5f - MagicResist/200);
                break;

            case DamageType.TrueDamage:
                Health -= quantity;
                break;

            default:
                //Error
                break;
            }
        }
        
    }

    abstract protected void spawn();

    /*Function for Entity Behaviour. Does nothing in obstacle
    Entities, Will be the input controller for Player, the
    AI for NPCs...*/
    virtual protected void control(){}

    virtual protected void die(){
        Destroy(gameObject);
    }

    //Trigger collision functions(to be overWritten by childs
    //If needed):
    //These will called from the TriggerCollider object
    virtual public void EnterColision(Collider other){}
    virtual public void StayColision(Collider other){}
    virtual public void ExitColision(Collider other){}

    

//Unity Functions:

    // Start is called before the first frame update
    void Start(){
        spawn();
    }

    // Update is called once per frame
    void FixedUpdate(){
        control();
    }

    

}
