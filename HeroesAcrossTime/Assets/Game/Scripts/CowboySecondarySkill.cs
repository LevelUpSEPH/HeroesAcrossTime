
public class CowboySecondarySkill : CharacterSkillBase // fires 3 shots in quick succession
{
    [SerializeField] private BulletPoolController _bulletPoolController;
    protected float _skillCooldown = 3f;

    public override void UseSkill(Vector3 targetPosition, Action OnSkillUsed){
        
        GameObject bullet1 = _bulletPoolController.GetBulletToShoot();
        GameObject bullet2 = _bulletPoolController.GetBulletToShoot();
        GameObject bullet3 = _bulletPoolController.GetBulletToShoot();

    }
}
