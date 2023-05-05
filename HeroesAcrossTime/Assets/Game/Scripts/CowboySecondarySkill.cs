
public class CowboySecondarySkill : CharacterSkillBase // fires 3 shots in quick succession
{
    [SerializeField] private BulletPoolController _bulletPoolController;
    protected float _skillCooldown = 3f;

    public override void UseSkill(Vector3 targetPosition, Action OnSkillUsed){
        if(!_readyToUse)
            return;
        // use whatever skill this is
        List<GameObject> bullets = new List<GameObject>();

        for(int i = 0; i < 3; i++){
            GameObject bullet = _bulletPoolController.GetBulletToShoot();
            bullets.Add(bullet);
        }
        ShootBullets(bullets);
        
        StartCoroutine(StartSkillCooldown(OnSkillUsed));
    }

    private void ShootBullets(List<GameObject> bullets){
        // shoot the bullets
    }
}
